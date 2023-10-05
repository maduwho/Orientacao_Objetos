using System.ComponentModel.Design;
using System.Globalization;

namespace trabalho_objetos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            foreach (Conta conta in ContaModel.List)
            {
                conta.MostrarSaldo();
            }
            
            do
            {
                
                Conta selecao = Menu.MenuLogin(ContaModel.List);
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

                        Conta beneficiario = Menu.MenuLogin(ContaModel.List);
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