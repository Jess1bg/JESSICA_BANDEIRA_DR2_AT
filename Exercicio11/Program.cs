using System;
using System.IO;

class GerenciadorContatos
{
    private const string CaminhoArquivo = "contatos.txt";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== AGENDA TELEFONICA ===");
            Console.WriteLine("1 - Adicionar novo contato");
            Console.WriteLine("2 - Listar contatos cadastrados");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarContato();
                    break;
                case "2":
                    ListarContatos();
                    break;
                case "3":
                    Console.WriteLine("\nEncerrando programa...");
                    return;
                default:
                    Console.WriteLine("\nEsta opção é inválida! Tente outra vez.");
                    break;
            }
        }
    }

    static void AdicionarContato()
    {
        try
        {
            Console.Write("\nNome: ");
            string nome = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            // Validação básica
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(telefone))
            {
                Console.WriteLine("\nERRO: Nome e telefone são obrigatórios!");
                return;
            }

            // Formato: Nome,Telefone,Email
            using (StreamWriter sw = File.AppendText(CaminhoArquivo))
            {
                sw.WriteLine($"{nome},{telefone},{email}");
            }

            Console.WriteLine("\nContato cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nERRO ao cadastrar: {ex.Message}");
        }
    }

    static void ListarContatos()
    {
        try
        {
            if (!File.Exists(CaminhoArquivo) || new FileInfo(CaminhoArquivo).Length == 0)
            {
                Console.WriteLine("\nNenhum contato cadastrado.");
                return;
            }

            Console.WriteLine("\n=== CONTATOS CADASTRADOS ===");
            using (StreamReader sr = new StreamReader(CaminhoArquivo))
            {
                string linha;
                while ((linha = sr.ReadLine()) != null)
                {
                    string[] dados = linha.Split(',');
                    if (dados.Length >= 3) // Para garantir que tenha nome, telefone e email
                    {
                        Console.WriteLine($"Nome: {dados[0]} | Telefone: {dados[1]} | Email: {dados[2]}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nERRO ao ler contatos: {ex.Message}");
        }
    }
}