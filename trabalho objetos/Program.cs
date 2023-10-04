using System.ComponentModel.Design;
using System.Globalization;

namespace trabalho_objetos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string[] operacoes = { "GERAL", "PIX", "DÉBITO", "CRÉDITO" };

            if (ContaModel.List.Count == 0 )
            {
                ContaModel.List.Add(new ContaModel("Ricardo", 23, 1234, 5));
                ContaModel.List.Add(new ContaModel("Madu", 20, 6789, 0));
                ContaModel.List.Add(new ContaModel("Bruno", 23, 3216, 7));
                ContaModel.List.Add(new ContaModel("Jadina", 23, 7894, 2));
                ContaModel.List.Add(new ContaModel("Victor", 17, 1597, 6));
                for (int i = 0; i < 50; i++)
                {
                     Operacao.Transferir(ContaModel.List[new Random().Next(0,4)], ContaModel.List[new Random().Next(0,4)], new Random().Next(10,300), operacoes[new Random().Next(1,operacoes.Length)],false);
                }
            }

            //RecarregarCelular(contas[0]);
            //contas[3].MostrarExtrato(); 
            foreach (ContaModel conta in ContaModel.List)
            {
                conta.MostrarSaldo();
            }

            do
            {
                
                ContaModel selecao = Menu.MenuLogin(ContaModel.List);
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

                        ContaModel beneficiario = Menu.MenuLogin(ContaModel.List);
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


            BancoDeDados.WriteFile(ContaModel.List);
        }
        
        
             
    }   
}