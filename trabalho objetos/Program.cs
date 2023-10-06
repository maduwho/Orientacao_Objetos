using System.ComponentModel.Design;
using System.Globalization;

namespace trabalho_objetos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SetupDeDados.CriarContaAleatoria(15);

            Login.Logar();

            Menu.MenuPrincipal();

            BancoDeDados.WriteFile(ContaModel.List);

        }
        
        
             
    }   
}