using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_objetos
{
    internal class Login
    {

        public static void Logar()
        {
            //TODO: While para tentar até ter sucesso.
            bool login = false;
            while (!login)
            {
                
                int loginDigitado = Menu.MenuLogin();

                foreach (Conta conta in ContaModel.List)
                {
                    int loginIterado = conta.Num_da_conta * 10 + conta.Num_verificador;
                    if (loginDigitado == loginIterado)
                    {
                        login = true;
                    }
                }
            }
        }

    }
}
