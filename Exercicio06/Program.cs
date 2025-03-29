using System;

class Aluno
{
    // Propriedades da classe
    public string Nome { get; set; }
    public string Matricula { get; set; }
    public string Curso { get; set; }
    public double MediaNotas { get; set; }

    // Método para exibir dados do aluno
    public void ExibirDados()
    {
        Console.WriteLine("\n--- Dados do Aluno ---");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Matrícula: {Matricula}");
        Console.WriteLine($"Curso: {Curso}");
        Console.WriteLine($"Média: {MediaNotas:F1}");
        Console.WriteLine($"Situação: {VerificarAprovacao()}");
    }

    // Método para verificar aprovação
    public string VerificarAprovacao()
    {
        return MediaNotas >= 7 ? "Aprovado" : "Reprovado";
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Cadastro de Aluno\n");

        Aluno aluno = new Aluno
        {
            Nome = "Carla Diaz",
            Matricula = "3650021",
            Curso = "Engenharia Mecânica",
            MediaNotas = 8.5
        };

        aluno.ExibirDados();
    }
}