using System;

class JogoAdivinhacao
{
    static void Main()
    {
        Random random = new Random();
        int numeroSecreto = random.Next(1, 51); // Permite gerar numeros de 1 a 50
        int tentativasRestantes = 5;
        bool acertou = false;

        Console.WriteLine("=== BEM VINDO AO JOGO DA ADIVINHAÇÃO ===");
        Console.WriteLine($"A sua missão é adivinhar o número secreto (entre 1 e 50). Você tem {tentativasRestantes} tentativas.\n");

        while (tentativasRestantes > 0 && !acertou)
        {
            Console.Write($"Tentativa #{6 - tentativasRestantes}: Digite um número: ");

            try
            {
                int palpite = int.Parse(Console.ReadLine());

                if (palpite < 1 || palpite > 50)
                {
                    Console.WriteLine("ERRO: O número deve estar entre 1 e 50!\n");
                    continue;
                }

                if (palpite == numeroSecreto)
                {
                    acertou = true;
                    Console.WriteLine("\nPARABÉNS! Você acertou!");
                }
                else
                {
                    tentativasRestantes--;
                    Console.WriteLine(palpite < numeroSecreto ? "O número secreto é MAIOR!" : "O número secreto é MENOR!");
                    Console.WriteLine($"Tentativas restantes: {tentativasRestantes}\n");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("ERRO: Por favor digite apenas números inteiros!\n");
            }
        }

        if (!acertou)
        {
            Console.WriteLine($"\n Você perdeu! O número secreto era: {numeroSecreto}");
        }
    }
}