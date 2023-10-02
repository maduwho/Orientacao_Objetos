using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_objetos
{
    internal class Conta
    {
        public string nome;
        public int idade;
        public int num_da_conta;
        public int num_verificador;
        public double saldo;
        public List<Transacao> extrato;

        public void MostrarExtrato(string tipo = "GERAL")
        {
            Console.WriteLine($"O extrato de {nome} é ");

            
            foreach (Transacao item in extrato)
            {
                if (tipo == "GERAL" || tipo == item.tipo)
                {
                    Console.WriteLine($"{item.tipo}\tR${item.valor}\t{item.data.ToString("dd/MM/yy HH:mm")}");

                }
            }

        }
        public void MostrarSaldo()
        {
            Console.WriteLine($"O saldo de {nome} é R${saldo}");
        }

        public void Sacar(double valor)
        {
            saldo -= valor; 
        }

        public void Depositar(double valor)
        {
            saldo += valor;
        }
        
    
        public Conta(string nome, int idade, int num_da_conta, int num_verificador)
        {
            this.nome = nome;
            this.idade = idade;
            this.num_da_conta = num_da_conta;
            this.num_verificador = num_verificador;
            this.saldo = new Random().Next(100,1000);
            this.extrato = new List<Transacao>();
        }
    }
}
