using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_objetos
{
    internal class Menu
    {
        public static ContaModel MenuLogin(List<ContaModel> contas)
        {
            do
            {
                Console.Write("Digite sua conta: ");
                int num_da_conta;
                try
                {
                    num_da_conta = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
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
                foreach (ContaModel conta in contas)
                {
                    if (conta.Num_da_conta == num_da_conta && conta.Num_verificador == num_do_verificador)
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
                }
                catch (Exception ex)
                {
                    opcao = 0;
                }

            } while (opcao < 1 || opcao > 4);
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

    }
}
