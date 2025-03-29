using System;

class ProximoAniversario
{
    static void Main()
    {

        DateTime dataNascimento = LerDataNascimento();
        DateTime hoje = DateTime.Today;

        DateTime proximoAniversario = CalcularProximoAniversario(dataNascimento, hoje);
        int diasRestantes = (proximoAniversario - hoje).Days;

        ExibirResultado(diasRestantes, proximoAniversario);
    }

    static DateTime LerDataNascimento()
    {
        while (true)
        {
            Console.Write("Qual a sua data de nascimento (dd/mm/aaaa)? ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dataNascimento) && dataNascimento < DateTime.Today)
            {
                Console.WriteLine(); // Espaço
                return dataNascimento;
            }
            Console.WriteLine("\nEsta data é inválida! Por favor use o formato dd/mm/aaaa e lembre-se a data nao pode ser futura.\n");
        }
    }

    static DateTime CalcularProximoAniversario(DateTime dataNascimento, DateTime hoje)
    {
        int anoAtual = hoje.Year;
        DateTime aniversarioEsteAno = new DateTime(anoAtual, dataNascimento.Month, dataNascimento.Day);

        if (aniversarioEsteAno < hoje)
        {
            // Para desconsidera o aniversário do ano atual se ja tiver passado, com isso se considera a partir do próximo ano
            return new DateTime(anoAtual + 1, dataNascimento.Month, dataNascimento.Day);
        }
        else
        {
            return aniversarioEsteAno;
        }
    }

    static void ExibirResultado(int diasRestantes, DateTime proximoAniversario)
    {
        Console.WriteLine($"Seu próximo aniversário é: {proximoAniversario:dd/MM/yyyy}");

        if (diasRestantes < 7)
        {   // Mensagem destacada
            Console.ForegroundColor = ConsoleColor.Yellow; 
            Console.WriteLine($"\nFALTAM APENAS {diasRestantes} DIAS! JÁ COMEÇOU A PREPARAR A FESTA? NÃO ESQUEÇA DE ME CONVIDAR!\n");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine($"\nFaltam {diasRestantes} dias para seu próximo aniversário.");
        }
    }
}