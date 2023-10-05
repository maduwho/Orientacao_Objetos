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

        public static void Create (string nome = null, string cpf = null)
        {
            int numeroDaConta = ContaModel.List.Count + 1;
            int numeroVerificador = new Random().Next(0, 9);

            Conta novaConta = new Conta(numeroDaConta, numeroVerificador, nome, cpf);
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
