using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_objetos
{
    internal class Login
    {
        public static int AccountIndex;
        public static void Logar()
        {
            Conta contaLogin = ContaModel.BuscarConta();

            Login.AccountIndex = ContaModel.List.IndexOf(contaLogin);
        }

    }
}
