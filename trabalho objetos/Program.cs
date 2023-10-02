using System.ComponentModel.Design;
using System.Globalization;

namespace trabalho_objetos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Conta> contas = new List<Conta>();
            contas.Add(new Conta("Ricardo", 23, 1234, 5));
            contas.Add(new Conta("Madu", 20, 6789, 0));
            contas.Add(new Conta("Bruno", 23, 3216, 7));
            contas.Add(new Conta("Jadina", 23, 7894, 2));

            string[] operacoes = { "GERAL", "PIX", "DÉBITO", "CRÉDITO" };
            for (int i = 0; i < 50; i++)
            {
                 Transferir(contas[new Random().Next(0,4)], contas[new Random().Next(0,4)], new Random().Next(10,300), operacoes[new Random().Next(1,operacoes.Length)],false);
            }

            //RecarregarCelular(contas[0]);
            //contas[3].MostrarExtrato(); 
            foreach (Conta conta in contas)
            {
                conta.MostrarSaldo();
            }


            do
            {
                
                Conta selecao = MenuLogin(contas);
                switch (MenuOpcoes())
                {
                    case 1:
                        selecao.MostrarSaldo();
                        break;
                    case 2:
                        selecao.MostrarExtrato(operacoes[MenuExtrato() - 1]);
                        break;
                    case 3:
                        string tipo = operacoes[MenuTransferencia()];

                        Conta beneficiario = MenuLogin(contas);
                        int valor;
                        try
                        {
                            Console.Write("Digite o valor da transferencia: ");
                            valor = Convert.ToInt32(Console.ReadLine());
                        }catch (Exception ex)
                        {
                            valor = 0;
                        }
                        Transferir(selecao, beneficiario, valor, tipo);
                        break;
                    case 4:
                        RecarregarCelular(selecao);
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }while (true);

        } 

        public static Conta MenuLogin(List<Conta> contas)
        {
            do
            {
                Console.Write("Digite sua conta: ");
                int num_da_conta;
                try
                {
                    num_da_conta = Convert.ToInt32(Console.ReadLine());
                }catch (Exception ex)
                {
                    num_da_conta = 0;
                }
                Console.Write("Digite seu digito verificador: ");
                int num_do_verificador;
                try
                {
                    num_do_verificador = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    num_do_verificador = 0;
                }
                foreach (Conta conta in contas)
                {
                    if(conta.num_da_conta == num_da_conta && conta.num_verificador == num_do_verificador)
                    {
                        return conta;
                    }
                }
                Console.Clear();
                Console.WriteLine("Conta inexistente");


            } while (true);
            
        }

        public static int MenuOpcoes()
        {
            int opcao;
            do
            {
                Console.WriteLine("Selecione a opção desejada:");
                Console.WriteLine("1- Saldo");
                Console.WriteLine("2- Extrato");
                Console.WriteLine("3- Transferências");
                Console.WriteLine("4- Recarga de celular");
                try
                {
                    opcao = Convert.ToInt32(Console.ReadLine());
                }catch(Exception ex)
                {
                    opcao=0;
                }               

            }while (opcao < 1 || opcao > 4);
            return opcao;
        }

        public static int MenuTransferencia()
        {
            int opcao;
            do
            {
                Console.WriteLine("Selecione a opção desejada:");
                Console.WriteLine("1- PIX");
                Console.WriteLine("2- DEBITO");
                Console.WriteLine("3- CRÉDITO");
                try
                {
                    opcao = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    opcao = 0;
                }

            } while (opcao < 1 || opcao > 3);
            return opcao;
        }

        public static int MenuExtrato()
        {
            int opcao;
            do
            {
                Console.WriteLine("Selecione a opção desejada:");
                Console.WriteLine("1- GERAL");
                Console.WriteLine("2- PIX");
                Console.WriteLine("3- DEBITO");
                Console.WriteLine("4- CRÉDITO");
                try
                {
                    opcao = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    opcao = 0;
                }

            } while (opcao < 1 || opcao > 4);
            return opcao;
        }

        public static void Transferir(Conta conta1, Conta conta2, double valor, string tipo, bool log = true)
        {
            conta1.Sacar(valor);
            Transacao transacao1 = new Transacao(-valor, tipo);
            conta2.Depositar(valor);
            Transacao transacao2 = new Transacao(valor, tipo);

            conta1.extrato.Add (transacao1);
            conta2.extrato.Add (transacao2);
            if (log) 
            { 
                Console.WriteLine("Transferência efetuada!");
            }
        }

        public static void RecarregarCelular(Conta conta1)
        {
            Console.WriteLine("Selecione sua operadora:\n1-TIM\n2-VIVO\n3-CLARO\n4-OI\n5-LariCel");
            int operadora = Convert.ToInt32(Console.ReadLine());

            do
            {
                Console.WriteLine("Digite o seu número de celular:");
                long celular = Convert.ToInt64(Console.ReadLine());
                if (celular < 10000000000)
                {
                    Console.WriteLine("Número inválido!");
                }else
                {
                    break;
                }

            } while (true);

            Console.WriteLine("Selecione o valor desejado:\n1-R$15\n2-R$20\n3-R$50\n4-R$100");
            int valor;
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                    case 1:
                    valor = 15; 
                    break;

                    case 2:
                    valor = 20;
                    break; 
                
                    case 3:
                    valor = 50;
                    break;

                    case 4:
                    valor = 100;
                    break;

                    default: valor = 0;
                    break;
            }
            

            conta1.Sacar(valor);
            Transacao transacao1 = new Transacao(-valor, "Recarga de celular!");
            conta1.extrato.Add(transacao1);
            Console.WriteLine("Recarga Efetuada!");
        }
    }   
}