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
                 Operacao.Transferir(contas[new Random().Next(0,4)], contas[new Random().Next(0,4)], new Random().Next(10,300), operacoes[new Random().Next(1,operacoes.Length)],false);
            }

            //RecarregarCelular(contas[0]);
            //contas[3].MostrarExtrato(); 
            foreach (Conta conta in contas)
            {
                conta.MostrarSaldo();
            }

            do
            {
                
                Conta selecao = Menu.MenuLogin(contas);
                switch (Menu.MenuOpcoes())
                {
                    case 1:
                        selecao.MostrarSaldo();
                        break;
                    case 2:
                        selecao.MostrarExtrato(operacoes[Menu.MenuExtrato() - 1]);
                        break;
                    case 3:
                        string tipo = operacoes[Menu.MenuTransferencia()];

                        Conta beneficiario = Menu.MenuLogin(contas);
                        int valor;
                        try
                        {
                            Console.Write("Digite o valor da transferencia: ");
                            valor = Convert.ToInt32(Console.ReadLine());
                        }catch (Exception ex)
                        {
                            valor = 0;
                        }
                        Operacao.Transferir(selecao, beneficiario, valor, tipo);
                        break;
                    case 4:
                        Operacao.RecarregarCelular(selecao);
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }while (true);

        }
   
    }   
}