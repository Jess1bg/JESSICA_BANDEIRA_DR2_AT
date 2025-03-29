using System;

class ContaBancaria
{
    public string Titular { get; set; } // Publico
    private decimal _saldo; // Privado

    public void Depositar(decimal valor) // Deposita um valor na conta, desde que seja positivo.
    {
        if (valor <= 0)
        {
            Console.WriteLine("\nO valor do depósito deve ser positivo!");
        }
        else
        {
            _saldo += valor;
            Console.WriteLine($"\nDepósito de R$ {valor:F2} realizado com sucesso!");
        }
    }

    public void Sacar(decimal valor) // Saca um valor da conta, se houver saldo suficiente.
    {
        if (valor <= 0)
        {
            Console.WriteLine("\nO valor do saque deve ser positivo!");
        }
        else if (valor > _saldo)
        {
            Console.WriteLine("\nSaldo insuficiente para realizar o saque!");
        }
        else
        {
            _saldo -= valor;
            Console.WriteLine($"\nSaque de R$ {valor:F2} realizado com sucesso!");
        }
    }

    public void ExibirSaldo() // Exibe o saldo atual formatado.
    {
        Console.WriteLine($"\nSaldo atual: R$ {_saldo:F2}");
    }
}

class Program
{
    static void Main() // Método principal que gerencia o menu interativo do banco digital.
    {
        Console.WriteLine("=== BANCO DIGITAL ===");

        // Criação da conta
        ContaBancaria conta = new ContaBancaria();
        Console.Write("\nDigite o nome do titular: ");
        conta.Titular = Console.ReadLine();

        // Menu interativo
        while (true)
        {
            Console.WriteLine("\nOpções:");
            Console.WriteLine("1 - Depositar");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Exibir Saldo");
            Console.WriteLine("4 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("\nDigite o valor do depósito: R$ ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal valorDeposito))
                    {
                        conta.Depositar(valorDeposito);
                    }
                    else
                    {
                        Console.WriteLine("\nValor inválido!");
                    }
                    break;

                case "2":
                    Console.Write("\nDigite o valor do saque: R$ ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal valorSaque))
                    {
                        conta.Sacar(valorSaque);
                    }
                    else
                    {
                        Console.WriteLine("\nValor inválido!");
                    }
                    break;

                case "3":
                    conta.ExibirSaldo();
                    break;

                case "4":
                    Console.WriteLine("\nSaindo do sistema...");
                    return;

                default:
                    Console.WriteLine("\nOpção inválida!");
                    break;
            }
        }
    }
}