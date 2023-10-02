using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_objetos
{
    internal class Conta
    {
        public string Nome;
        public int Idade;
        public int Num_da_conta;
        public int Num_verificador;
        public double Saldo;
        public List<Operacao> extrato;

        public void MostrarExtrato(string tipo = "GERAL")
        {
            Console.WriteLine($"O extrato de {Nome} é ");

            
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
            Console.WriteLine($"O saldo de {Nome} é R${Saldo}");
        }

        public void Sacar(double valor)
        {
            Saldo -= valor; 
        }

        public void Depositar(double valor)
        {
            Saldo += valor;
        }


        public Conta(string nome, int idade, int num_da_conta, int num_verificador) 
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Num_da_conta = num_da_conta;
            this.Num_verificador = num_verificador;
            this.Saldo = new Random().Next(100,1000);
            this.extrato = new List<Operacao>();
        }
    }
}
