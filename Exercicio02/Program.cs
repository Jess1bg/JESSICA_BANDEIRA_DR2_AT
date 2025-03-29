using System;

class CifradorDeNome
{
    static void Main()
    {
        Console.Write("Digite seu nome completo: ");
        string nomeOriginal = Console.ReadLine();

        string nomeCifrado = CifrarNome(nomeOriginal, 2);

        Console.WriteLine($"Nome original: {nomeOriginal}");
        Console.WriteLine($"Nome cifrado: {nomeCifrado}");
    }

    static string CifrarNome(string nome, int deslocamento)
    {
        char[] caracteres = nome.ToCharArray();

        for (int i = 0; i < caracteres.Length; i++)
        {
            // Ignora espaços e caracteres que não sejam alfabéticos para evitar erros
            if (char.IsLetter(caracteres[i]))
            {
                char letraOriginal = caracteres[i];
                char letraCifrada = DeslocarLetra(letraOriginal, deslocamento);
                caracteres[i] = letraCifrada;
            }
        }

        return new string(caracteres);
    }

    static char DeslocarLetra(char letra, int deslocamento)
    {
        // Determina a base (A-Z ou a-z)
        int baseAlfabeto = char.IsUpper(letra) ? 'A' : 'a';

        // O alfabeto tem 26 letras, o operador % calcula o resto da divisão, garantindo que o resultado sempre esteja entre 0 e 25.
        int posicaoOriginal = letra - baseAlfabeto;
        int posicaoCifrada = (posicaoOriginal + deslocamento) % 26; 

        // Para os casos onde o deslocamento é negativo
        if (posicaoCifrada < 0)
        {
            posicaoCifrada += 26;
        }

        return (char)(baseAlfabeto + posicaoCifrada);
    }
}