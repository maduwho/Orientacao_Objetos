using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace trabalho_objetos
{
    internal class Crud
    {
        private static string path = "conta.txt";
        public static void WriteFile(List<Conta> data)
        {
            try
            {
                string json = JsonSerializer.Serialize(data);
                File.WriteAllText(Crud.path, json);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"\nErro ao salvar arquivo de dados.\n*Err: {ex.Message}");
            }
        }
        public static List<Conta> OpenFile(List<Conta> data)
        {

            try
            {
                string json = File.ReadAllText(Crud.path);
                data = JsonSerializer.Deserialize<List<Conta>>(json);
            }
            catch (System.IO.FileNotFoundException)
            {
                data = new List<Conta>();
                WriteFile(data);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"\nErro ao ler arquivo de dados.\n*Err: {ex.Message}");
            }

            return data;
        }

    }
}
