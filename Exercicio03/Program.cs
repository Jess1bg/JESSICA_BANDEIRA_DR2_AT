using System;

class Calculadora
{
    static void Main()
    {
        Console.WriteLine("Calculadora");
        Console.WriteLine();

        // Para solicitar os números
        double num1 = LerNumero("Digite o primeiro número: ");
        double num2 = LerNumero("Digite o segundo número: ");
        Console.WriteLine();
        Console.WriteLine("Escolha a operação que deseja realizar:");
        Console.WriteLine("1 - Soma");
        Console.WriteLine("2 - Subtração");
        Console.WriteLine("3 - Multiplicação");
        Console.WriteLine("4 - Divisão");
        Console.WriteLine();

        // Para solicitar a operação
        int operacao = LerOperacao();
        Console.WriteLine();

        // Calcular e exibir o resultado
        CalcularExibir(num1, num2, operacao);
    }

    // Método para ler números válidos
    static double LerNumero(string mensagem)
    {
        double numero;
        while (true)
        {
            Console.Write(mensagem);
            if (double.TryParse(Console.ReadLine(), out numero))
            {
                return numero;
            }
            Console.WriteLine("Este número é inválido! Tente novamente.");
        }
    }

    // Método para ler a operação (1 a 4)
    static int LerOperacao()
    {
        int operacao;
        while (true)
        {
            Console.Write("Digite o numero da operação: ");
            if (int.TryParse(Console.ReadLine(), out operacao) && operacao >= 1 && operacao <= 4)
            {
                return operacao;
            }
            Console.WriteLine("Operação inválida! Digite 1, 2, 3 ou 4.");
        }
    }

    // Método para calcular a operação e exibir o resultado
    static void CalcularExibir(double num1, double num2, int operacao)
    {
        double resultado = 0;
        string simbolo = "";
        bool operacaoValida = true;

        switch (operacao)
        {
            case 1: // Soma
                resultado = num1 + num2;
                simbolo = "+";
                break;
            case 2: // Subtração
                resultado = num1 - num2;
                simbolo = "-";
                break;
            case 3: // Multiplicação
                resultado = num1 * num2;
                simbolo = "*";
                break;
            case 4: // Divisão
                if (num2 != 0)
                {
                    resultado = num1 / num2;
                    simbolo = "/";
                }
                else
                {
                    Console.WriteLine("Erro: Voc^não pode realizar uma divisão por zero!");
                    operacaoValida = false;
                }
                break;
        }

        if (operacaoValida)
        {
            Console.WriteLine($"Resultado: {num1} {simbolo} {num2} = {resultado}");
        }
    }
}