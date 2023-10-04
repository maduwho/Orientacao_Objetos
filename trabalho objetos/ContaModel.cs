using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_objetos
{
    internal class ContaModel
    {
        public static List<Conta> List = BancoDeDados.OpenFile(new List<Conta>());

        public static void Create ()
        {
            Conta novaConta = new Conta(1 , new Random().Next(0, 9));
            ContaModel.List.Add(novaConta);
        }

        public static void Read ()
        {

        }

        public static void Update ()
        {

        }

        public static void Delete ()
        {

        }


    }
}
