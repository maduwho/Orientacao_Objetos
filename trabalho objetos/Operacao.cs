using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_objetos
{
    internal class Operacao
    {
        public double valor;
        public string tipo;
        public DateTime data;

        public Operacao(double valor, string tipo)
        {
            this.valor = valor;
            this.tipo = tipo;
            this.data = DateTime.Now;
        }

        public static void Transferir(ContaModel conta1, ContaModel conta2, double valor, string tipo, bool log = true)
        {
            conta1.Sacar(valor);
            Operacao transacao1 = new Operacao(-valor, tipo);
            conta2.Depositar(valor);
            Operacao transacao2 = new Operacao(valor, tipo);

            conta1.extrato.Add(transacao1);
            conta2.extrato.Add(transacao2);
            if (log)
            {
                Console.WriteLine("Transferência efetuada!");
            }
        }

        public static void RecarregarCelular(ContaModel conta1)
        {
            Console.WriteLine("Selecione sua operadora:\n1-TIM\n2-VIVO\n3-CLARO\n4-OI\n5-LariCel");
            int operadora = Convert.ToInt32(Console.ReadLine());

            do
            {
                Console.WriteLine("Digite o seu número de celular:");
                long celular = Convert.ToInt64(Console.ReadLine());
                if (celular < 10000000000)
                {
                    Console.WriteLine("Número inválido!");
                }
                else
                {
                    break;
                }

            } while (true);

            Console.WriteLine("Selecione o valor desejado:\n1-R$15\n2-R$20\n3-R$50\n4-R$100");
            int valor;
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    valor = 15;
                    break;

                case 2:
                    valor = 20;
                    break;

                case 3:
                    valor = 50;
                    break;

                case 4:
                    valor = 100;
                    break;

                default:
                    valor = 0;
                    break;
            }

            conta1.Sacar(valor);
            Operacao transacao1 = new Operacao(-valor, "Recarga de celular!");
            conta1.extrato.Add(transacao1);
            Console.WriteLine("Recarga Efetuada!");
        }

        public static void RealizarEmprestimo(int RendaMensal)
        {
            if ( RendaMensal > 500)
            {
                
            }
        }
    }
}
