using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;


namespace trabalho_objetos
{
    internal class ContaModel : ICrud
    {
        public static List<Conta> List = BancoDeDados.OpenFile(new List<Conta>());
        protected string conectionString = "Server=localhost;Database=BANCO;User=root;Password=root;";
        public static Conta BuscarConta()
        {
            while (true)
            {

                int loginDigitado = Menu.MenuSelecionarConta();

                foreach (Conta conta in ContaModel.List)
                {
                    int loginIterado = conta.NUM_DA_CONTA * 10 + conta.NUM_VERIFICADOR;
                    if (loginDigitado == loginIterado)
                    {
                        return conta;
                    }
                }
            }
        }

        public static Conta CreateConta (string nome = null, string cpf = null)
        {
            int numeroDaConta = ContaModel.List.Count + 1;
            int numeroVerificador = new Random().Next(0, 9);

            Conta novaConta = new Conta();
                  novaConta.Popular(numeroDaConta, numeroVerificador, nome, cpf);
            ContaModel.List.Add(novaConta);
            return novaConta;
        }
        private int Execute(string sql, object obj)
        {
            using (MySqlConnection con = GetConnection())
            {
                return con.Execute(sql, obj);
            }
        }
        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(conectionString);
        }

        private int GetIndex()
        {
            Read();
            Console.WriteLine("Digite o id para continuar");
            return Convert.ToInt32(Console.ReadLine());
        }

        public void Create()
        {

            Conta conta = CreateConta();
            string sql = "INSERT INTO CONTA VALUE (NULL, @NOME, @NUM_DA_CONTA, @NUM_VERIFICADOR, @CPF)";
            int linhas = this.Execute(sql, conta);
            Console.WriteLine($"Conta inserido - {linhas} linhas afetadas");

        }

        public void Read ()
        {
            using (MySqlConnection Con = GetConnection())
            {
                string sql = "SELECT * FROM CONTA";
                IEnumerable<Conta> contas = Con.Query<Conta>(sql);
                foreach (var conta in contas)
                {
                    Console.WriteLine($"{conta.ID} - Número da conta: {conta.NUM_DA_CONTA}-{conta.NUM_VERIFICADOR} - Nome: {conta.NOME} - CPF: {conta.CPF}");
                }
            }
        }

        public void Update ()
        {
            Conta conta = ContaModel.List[Menu.MenuSelecionarConta()];
            conta.AtualizarConta();
            string sql = "UPDATE CONTA SET NOME = @NOME, NUM_DA_CONTA = @NUM_DA_CONTA, NUM_VERIFICADOR = @NUM_VERIFICADOR, CPF = @CPF WHERE ID = @ID";
            int linhas = this.Execute(sql, conta);
            Console.WriteLine($"Conta atualizado - {linhas} linhas afetadas");
        }

        public void Delete ()
        {
            Conta conta = ContaModel.List[Menu.MenuSelecionarConta()];
            var parameters = new { ID = conta.ID };
            string sql = "DELETE FROM BANCO WHERE ID = @ID";
            this.Execute(sql, parameters);
            Console.WriteLine("Conta excluido com sucesso");
        }


    }
}
