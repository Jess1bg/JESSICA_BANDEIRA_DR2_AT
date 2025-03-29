using System;
using System.IO;

class Produto
{
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }
}

class Program
{
    static void Main()
    {
        string caminhoArquivo = "estoque.txt";
        Produto[] produtos = new Produto[5];
        int totalProdutos = 0;

        while (true)
        {
            Console.WriteLine("\n=== ESTOQUE ===");
            Console.WriteLine("1. Inserir Produto");
            Console.WriteLine("2. Listar Produtos");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": // Inserir Produto
                    if (totalProdutos >= 5)
                    {
                        Console.WriteLine("\nLimite de produtos atingido (máx. 5)!");
                        break;
                    }

                    Console.Write("\nNome do Produto: ");
                    string nome = Console.ReadLine();

                    Console.Write("Quantidade: ");
                    int quantidade = int.Parse(Console.ReadLine());

                    Console.Write("Preço Unitário (R$): ");
                    decimal preco = decimal.Parse(Console.ReadLine());

                    // Adiciona ao array
                    produtos[totalProdutos] = new Produto
                    {
                        Nome = nome,
                        Quantidade = quantidade,
                        Preco = preco
                    };
                    totalProdutos++;

                    // Salva no arquivo
                    using (StreamWriter sw = File.AppendText(caminhoArquivo))
                    {
                        sw.WriteLine($"{nome},{quantidade},{preco:F2}");
                    }

                    Console.WriteLine("\nProduto cadastrado com sucesso!");
                    break;

                case "2": // Listar Produtos
                    if (!File.Exists(caminhoArquivo) || File.ReadAllText(caminhoArquivo).Length == 0)
                    {
                        Console.WriteLine("\nNenhum produto cadastrado.");
                        break;
                    }

                    Console.WriteLine("\n=== PRODUTOS CADASTRADOS ===");
                    using (StreamReader sr = new StreamReader(caminhoArquivo))
                    {
                        string linha;
                        while ((linha = sr.ReadLine()) != null)
                        {
                            string[] dados = linha.Split(',');
                            Console.WriteLine($"Produto: {dados[0]} | Quantidade: {dados[1]} | Preço: R$ {decimal.Parse(dados[2]):F2}");
                        }
                    }
                    break;

                case "3": // Sair
                    Console.WriteLine("\nEncerrando o sistema...");
                    return;

                default:
                    Console.WriteLine("\nOpção inválida!");
                    break;
            }
        }
    }
}