using System;
using System.IO;
using System.Collections.Generic;

class Contato // Representa um contato
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
}
abstract class ContatoFormatter // Base para formatadores
{
    public abstract void ExibirContatos(List<Contato> contatos);
}

class MarkdownFormatter : ContatoFormatter // Formatador Markdown
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("\n## Lista de Contatos\n");
        foreach (var contato in contatos)
        {
            Console.WriteLine($"- **Nome:** {contato.Nome}");
            Console.WriteLine($"- 📞 Telefone: {contato.Telefone}");
            Console.WriteLine($"- 📧 Email: {contato.Email}\n");
        }
    }
}

class TabelaFormatter : ContatoFormatter // Formatador de Tabela
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine("| Nome           | Telefone       | Email            |");
        Console.WriteLine("----------------------------------------");

        foreach (var contato in contatos)
        {
            Console.WriteLine($"| {contato.Nome,-15} | {contato.Telefone,-14} | {contato.Email,-16} |");
        }

        Console.WriteLine("----------------------------------------");
    }
}

class RawTextFormatter : ContatoFormatter // Formatador de Texto Puro
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("\n=== CONTATOS CADASTRADOS ===");
        foreach (var contato in contatos)
        {
            Console.WriteLine($"Nome: {contato.Nome} | Telefone: {contato.Telefone} | Email: {contato.Email}");
        }
    }
}

class Program
{
    private const string CaminhoArquivo = "contatos.txt";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== AGENDA DE CONTATOS ===");
            Console.WriteLine("1 - Adicione um novo contato");
            Console.WriteLine("2 - Ver lista de contatos");
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
                    Console.WriteLine("\nOpção inválida!");
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

            using (StreamWriter sw = File.AppendText(CaminhoArquivo))
            {
                sw.WriteLine($"{nome},{telefone},{email}");
            }

            Console.WriteLine("\nCadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nERRO: {ex.Message}");
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

            var contatos = new List<Contato>();
            using (StreamReader sr = new StreamReader(CaminhoArquivo))
            {
                string linha;
                while ((linha = sr.ReadLine()) != null)
                {
                    string[] dados = linha.Split(',');
                    if (dados.Length == 3)
                    {
                        contatos.Add(new Contato
                        {
                            Nome = dados[0],
                            Telefone = dados[1],
                            Email = dados[2]
                        });
                    }
                }
            }

            Console.WriteLine("\nEscolha o formato de exibição que deseja visualizar:");
            Console.WriteLine("1 - Markdown");
            Console.WriteLine("2 - Tabela");
            Console.WriteLine("3 - Texto Puro");
            Console.Write("Opção: ");

            string formato = Console.ReadLine();
            ContatoFormatter formatter;

            switch (formato)
            {
                case "1":
                    formatter = new MarkdownFormatter();
                    break;
                case "2":
                    formatter = new TabelaFormatter();
                    break;
                case "3":
                    formatter = new RawTextFormatter();
                    break;
                default:
                    Console.WriteLine("\nEste formato é inválido! Visualização alterada para texto puro.");
                    formatter = new RawTextFormatter();
                    break;
            }

            formatter.ExibirContatos(contatos);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nERRO: {ex.Message}");
        }
    }
}