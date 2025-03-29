class Funcionario
{
    // Dados do funcionario
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public decimal SalarioBase { get; set; }

    // Para inicializar os dados
    public Funcionario(string nome, string cargo, decimal salarioBase)
    {
        Nome = nome;
        Cargo = cargo;
        SalarioBase = salarioBase;
    }

    // Calcula o salário
    public virtual decimal CalcularSalario()
    {
        return SalarioBase; // Retorna o salário sem bônus
    }

    // Exibe os dados
    public void ExibirDados()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Cargo: {Cargo}");
        Console.WriteLine($"Salário: R$ {CalcularSalario():F2}");
    }
}

class Gerente : Funcionario
{
    // Repassa os dados para a classe base (Funcionario)
    public Gerente(string nome, decimal salarioBase)
        : base(nome, "Gerente", salarioBase)
    {
        // O cargo é fixo como "Gerente".
    }

    // Sobrescreve o método de cálculo para adicionar o bonus de 20%
    public override decimal CalcularSalario()
    {
        return SalarioBase * 1.20m; // Bônus
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== FUNCIONÁRIOS CADASTRADOS ===");

        Funcionario funcionarioComum = new Funcionario(
            "Matheus Silva",
            "Arquiteto Junior",
            5000.00m
        );
        funcionarioComum.ExibirDados();

        // Cria um gerente (com bônus automático)
        Gerente gerente = new Gerente(
            "Maria Clara",
            8000.00m
        );
        gerente.ExibirDados();
    }
}