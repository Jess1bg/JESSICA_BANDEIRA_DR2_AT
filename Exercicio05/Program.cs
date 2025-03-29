using System;

class TempoFormatura
{
    static void Main()
    {
        // Defina sua data de formatura manualmente aqui (ano, mês, dia)
        DateTime dataFormatura = new DateTime(2026, 12, 15);

        Console.WriteLine("Tempo para Formatura\n");
        DateTime dataAtual = LerDataAtual();

        if (dataAtual > dataFormatura)
        {
            Console.WriteLine("\nParabéns! Você já deveria estar formado!");
        }
        else
        {
            CalcularTempoRestante(dataAtual, dataFormatura);
        }
    }

    static DateTime LerDataAtual()
    {
        while (true)
        {
            Console.Write("Digite a data atual (dd/MM/yyyy): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime data) && data <= DateTime.Today)
            {
                return data;
            }
            Console.WriteLine("\nErro: Esta data é inválida! Use o formato dd/MM/yyyy e certifique-se que não é futura.\n");
        }
    }

    static void CalcularTempoRestante(DateTime dataAtual, DateTime dataFormatura)
    {
        // Ajustando para cálculo preciso de meses/anos
        int anos = dataFormatura.Year - dataAtual.Year;
        int meses = dataFormatura.Month - dataAtual.Month;
        int dias = dataFormatura.Day - dataAtual.Day;

        if (dias < 0)
        {
            meses--;
            dias += DateTime.DaysInMonth(dataAtual.Year, dataAtual.Month);
        }
        if (meses < 0)
        {
            anos--;
            meses += 12;
        }

        // Exibição formatada
        Console.Write($"\nFaltam ");
        if (anos > 0) Console.Write($"{anos} ano(s), ");
        if (meses > 0) Console.Write($"{meses} mes(es) e ");
        Console.Write($"{dias} dia(s) para sua formatura!");

        // Mensagem especial para quem se forma em menos de 6 meses
        if (meses < 6 && anos == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\nVocê esta pertinho da reta final! Parabens, se prepare para a formatura!");
            Console.ResetColor();
        }
    }
}