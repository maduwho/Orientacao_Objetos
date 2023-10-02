using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_objetos
{
    internal class Transacao
    {
        public double valor;
        public string tipo;
        public DateTime data;

        public Transacao(double valor, string tipo)
        {
            this.valor = valor;
            this.tipo = tipo;
            this.data = DateTime.Now;
        }




    }
}
