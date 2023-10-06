using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_objetos
{
    class SetupDeDados
    {
        public static void CriarContaAleatoria(int quantidade = 0)
        {
            string[] nomes = {
                "Ana", "Carlos", "Maria", "Pedro", "Lúcia", "José", "Isabela", "Rafael", "Patrícia", "Lucas",
                "Amanda", "Bruno", "Clara", "Daniel", "Eduarda", "Fernando", "Gabriela", "Hugo", "Ingrid", "Jorge",
                "Karen", "Leonardo", "Mariana", "Nathan", "Olivia", "Paulo", "Quitéria", "Ricardo", "Sofia", "Thiago",
                "Maria Eduarda", "Andrele", "Erotides", "João"
            };
            string[] sobrenomes = {
                "Silva", "Santos", "Pereira", "Ferreira", "Almeida", "Ribeiro", "Oliveira", "Costa", "Gonçalves", "Rodrigues",
                "Martins", "Lima", "Araújo", "Fernandes", "Carvalho", "Gomes", "Nascimento", "Mendes", "Barbosa", "Teixeira",
                "Machado", "Cardoso", "Dias", "Sousa", "Correia", "Ramos", "Cavalcanti", "Dantas", "Castro", "Vieira", "de Souza",
                "Schmidt", "Müller", "Schneider", "Fischer", "Weber", "Schulz", "Becker", "Hoffmann", "Koch", "Bauer", "Mees",
                "Rossi", "Russo", "Ferrari", "Esposito", "Bianchi", "Romano", "Colombo", "Ricci", "Marino", "Greco", "da Silva", "Pereira", 
                "Lauth", "Oecksler", "Montibeller"
            };

            do
            {
                string nomeAleatorio = nomes[new Random().Next(0, nomes.Count())] + " "
                                     + sobrenomes[new Random().Next(0, nomes.Count())] + " "
                                     + sobrenomes[new Random().Next(0, nomes.Count())];

                string cpfAleatorio = "";
                for (int i = 0; i < 11; i++)
                {
                    cpfAleatorio += new Random().Next(0, 10).ToString();
                }

                ContaModel.Create(nomeAleatorio, cpfAleatorio);

                quantidade--;
            } while (quantidade > 0);
            //ContaModel.List.Add(new Conta("Ricardo", 23, 1234, 5));
            //ContaModel.List.Add(new Conta("Madu", 20, 6789, 0));
            //ContaModel.List.Add(new Conta("Bruno", 23, 3216, 7));
            //ContaModel.List.Add(new Conta("Jadina", 23, 7894, 2));
            //ContaModel.List.Add(new Conta("Victor", 17, 1597, 6));
        }

        public static void CriarTransferenciaAleatoria(int quantidade = 0)
        {
            do
            {
                Conta contaAleatoria1 = ContaModel.List[new Random().Next(0, ContaModel.List.Count)];
                Conta contaAleatoria2 = ContaModel.List[new Random().Next(0, ContaModel.List.Count)];

                int valorAleatorio = new Random().Next(10, 300);
                string tipoOperacao = Operacao.operacoes[new Random().Next(1, Operacao.operacoes.Length)];

                Operacao.Transferir(contaAleatoria1, contaAleatoria2, valorAleatorio, tipoOperacao, false);

                quantidade--;
            } while (quantidade > 0);

        }

    }
}
