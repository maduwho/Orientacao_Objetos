using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_objetos
{
    internal class Menu
    {

        public static int MenuSelecionarConta(string currentText = "", int i = 0, ConsoleKeyInfo key = new ConsoleKeyInfo())
        {
            int itensPorPagina = 10;
            switch (key.Key)
            {
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    currentText += "0";
                    break;
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    currentText += "1";
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    currentText += "2";
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    currentText += "3";
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    currentText += "4";
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    currentText += "5";
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    currentText += "6";
                    break;
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    currentText += "7";
                    break;
                case ConsoleKey.D8:
                case ConsoleKey.NumPad8:
                    currentText += "8";
                    break;
                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    currentText += "9";
                    break;
                case ConsoleKey.UpArrow:
                    i--;
                    if (i < 0) i = 0;
                    break;
                case ConsoleKey.DownArrow:
                    i++;
                    if (i >= ContaModel.List.Count - itensPorPagina) i = Math.Max(0, ContaModel.List.Count - itensPorPagina);
                    break;
                case ConsoleKey.Backspace:
                    if (currentText.Length > 0)
                    {
                        currentText = currentText.Substring(0, (currentText.Length - 1));
                    }
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    if (currentText.Equals("")) { currentText = "0"; }
                    return Convert.ToInt32(currentText);
                case ConsoleKey.Escape:
                    System.Environment.Exit(1);
                    return -1;
            }

            Console.Clear();
            Console.WriteLine("------------------------------------------------------------");
            Console.Write("\tDigite o numero da sua conta: " + currentText + "\n");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Numero da Conta\t\tCliente");
            for (int k = 0; k < itensPorPagina; k++)
            {
                try
                {
                    Console.WriteLine(ContaModel.List[i + k].Num_da_conta + "-" + ContaModel.List[i + k].Num_verificador + "\t\t\t" + ContaModel.List[i + k].Nome);
                }
                catch{ }
            }
            Console.WriteLine("------------------------------------------------------------");

            return MenuSelecionarConta(currentText, i, Console.ReadKey());

        }

        public static void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Selecione a opção desejada:");
            Console.WriteLine("1- Saldo");
            Console.WriteLine("2- Extrato");
            Console.WriteLine("3- Transferências");
            Console.WriteLine("4- Recarga de celular");
            Console.WriteLine("5- Gerar Transferências");
            Console.WriteLine("0- Sair");
            switch (Console.ReadLine()) {
                case "0":
                    return;
                case "1":
                    Console.Clear();
                    ContaModel.List[Login.AccountIndex].MostrarSaldo();
                    Console.WriteLine("Pressione um tecla para continuar.");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.Clear();
                    ContaModel.List[Login.AccountIndex].MostrarExtrato();
                    Console.WriteLine("Pressione um tecla para continuar.");
                    Console.ReadLine();
                    break;
                case "3":
                    Console.Clear();
                    Conta contaBeneficiaria = ContaModel.BuscarConta();
                    Operacao.Transferir(ContaModel.List[Login.AccountIndex], contaBeneficiaria);
                    Console.WriteLine("Pressione um tecla para continuar.");
                    Console.ReadLine();
                    break;
                case "4":
                    Console.Clear();
                    Operacao.RecarregarCelular(ContaModel.List[Login.AccountIndex]);
                    Console.WriteLine("Pressione um tecla para continuar.");
                    Console.ReadLine();
                    break;
                case "5":
                    Console.Clear();
                    SetupDeDados.CriarTransferenciaAleatoria(50);
                    break;
            }

            MenuPrincipal();

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
