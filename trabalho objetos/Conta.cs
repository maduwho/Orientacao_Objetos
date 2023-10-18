using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_objetos
{
    internal class Conta
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public string CPF { get; set; }
        public int NUM_DA_CONTA { get; set; }
        public int NUM_VERIFICADOR { get; set; }
        public double Saldo { get; set; }
        public int RendaMensal { get; set; }
        public int Emprestimo { get; set; }
        public List<Operacao> extrato { get; set; }


        public void Popular(int num_da_conta, int num_verificador, string nome = null, string cpf = null)
        {


            if (nome == null)
            {
                Console.Write("Digite o nome da Conta: ");
                nome = Console.ReadLine();
            }

            if (cpf == null)
            {
                Console.Write("Digite o CPF: ");
                cpf = Console.ReadLine();
            }
            this.ID = ContaModel.List.Count + 1;
            this.NOME = nome;
            this.CPF = cpf;
            this.NUM_DA_CONTA = num_da_conta;
            this.NUM_VERIFICADOR = num_verificador;
            this.Saldo = new Random().Next(100,1000);
            this.extrato = new List<Operacao>();
            this.RendaMensal = new Random().Next(10,100)*100;
            this.Emprestimo = 0;
        }
        public void MostrarExtrato(string tipo = "GERAL")
        {
            Console.WriteLine($"O extrato de {NOME} é ");

            
            foreach (Operacao item in extrato)
            {
                if (tipo == "GERAL" || tipo == item.tipo)
                {
                    Console.WriteLine($"{item.tipo}\tR${item.valor}\t{item.data.ToString("dd/MM/yy HH:mm")}");

                }
            }

        }
        public void MostrarSaldo()
        {
            Console.WriteLine($"O saldo de {NOME} é R${Saldo}");
        }

        public void Sacar(double valor)
        {
            Saldo -= valor; 
        }

        public void Depositar(double valor)
        {
            Saldo += valor;
        }

        public void AtualizarConta()
        {
            Console.Write($"Digite o novo nome da Conta para substituir {NOME}: ");
            NOME = Console.ReadLine();
            Console.Write($"Digite a nova Renda Mensal: ");
            RendaMensal =Convert.ToInt32(Console.ReadLine());
        }


    }
}
