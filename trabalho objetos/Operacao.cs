using System;
using System.Collections.Concurrent;
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
        public static string[] operacoes = { "GERAL", "PIX", "DÉBITO", "CRÉDITO" };
        public double valor;
        public string tipo;
        public DateTime data;

        public Operacao(double valor, string tipo)
        {
            this.valor = valor;
            this.tipo = tipo;
            this.data = DateTime.Now;
        }

        public static void Transferir(Conta conta1, Conta conta2, double valor = 0, string tipo = "PIX", bool log = true)
        {
            if (valor == 0)
            {
                Console.Write("Digite o valor da transferência: ");
                try {
                    valor = Convert.ToDouble(Console.ReadLine());
                } catch
                {
                }
            }

            if(conta1.Saldo >= valor)
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
            } else
            {
                Console.WriteLine("Saldo Insuficiente!");
            }

        }

        public static void RecarregarCelular(Conta conta1)
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
            int emprestimo;
            switch (RendaMensal)
            {
                case < 1000:
                    emprestimo = 0;
                    break;

                case < 2000:
                    emprestimo = 5000;
                    break;

                case < 5000:
                    emprestimo = 10000;
                    break;

                case < 10000:
                    emprestimo = 30000;
                    break;

                case < 50000:
                    emprestimo = 500000;
                    break;

                case >= 50000:
                    emprestimo = 1000000;
                    break;

                default: emprestimo = 0;
                    break;   

            }

            emprestimo -= ContaModel.List[Login.AccountIndex].Emprestimo;
            string text = emprestimo == 0 ? "Indisponível" : "R$"+emprestimo.ToString();
            Console.WriteLine($"Sua renda mensal é de {ContaModel.List[Login.AccountIndex].RendaMensal}");
            Console.WriteLine($"O empréstimo disponível é de: {text}");
            Console.Write("Digite a quantidade desejada: ");
            int valor = Convert.ToInt32(Console.ReadLine());
            if (valor <= emprestimo)
            {

                ContaModel.List[Login.AccountIndex].Depositar(valor);
                Operacao transacao1 = new Operacao(-valor, "Empréstimo!");
                ContaModel.List[Login.AccountIndex].Emprestimo += valor;

                ContaModel.List[Login.AccountIndex].extrato.Add(transacao1);
                Console.WriteLine("Empréstimo efetuado!");
            }
            else
            {
                Console.WriteLine("Empréstimo recusado!");
            }

        }
    }
}
