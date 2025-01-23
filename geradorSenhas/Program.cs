
using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "bkp.TXT";

        while (true)
        {
            Console.WriteLine("=== Gerador de Senhas ===");
            Console.WriteLine("1. Gerar nova senha");
            Console.WriteLine("2. Recuperar senhas geradas");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    GerarSenha(filePath);
                    break;
                case "2":
                    RecuperarSenhas(filePath);
                    break;
                case "3":
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void GerarSenha(string filePath)
    {
        Console.Write("Informe o tamanho da senha desejada: ");
        if (!int.TryParse(Console.ReadLine(), out int tamanho) || tamanho <= 0)
        {
            Console.WriteLine("Tamanho inválido. Tente novamente.");
            return;
        }

        Console.Write("Incluir números? (s/n): ");
        bool incluirNumeros = Console.ReadLine()?.Trim().ToLower() == "s";

        Console.Write("Incluir letras? (s/n): ");
        bool incluirLetras = Console.ReadLine()?.Trim().ToLower() == "s";

        Console.Write("Incluir caracteres especiais (@, !, #, -)? (s/n): ");
        bool incluirEspeciais = Console.ReadLine()?.Trim().ToLower() == "s";

        string senha = GerarSenhaAleatoria(tamanho, incluirNumeros, incluirLetras, incluirEspeciais);

        if (string.IsNullOrEmpty(senha))
        {
            Console.WriteLine("Não foi possível gerar a senha com as opções fornecidas.");
            return;
        }

        Console.WriteLine($"Senha gerada: {senha}");

        SalvarSenha(filePath, senha);
    }

    static string GerarSenhaAleatoria(int tamanho, bool incluirNumeros, bool incluirLetras, bool incluirEspeciais)
    {
        StringBuilder caracteres = new StringBuilder();

        if (incluirNumeros) caracteres.Append("0123456789");
        if (incluirLetras) caracteres.Append("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");
        if (incluirEspeciais) caracteres.Append("@!#-");

        if (caracteres.Length == 0) return null;

        Random random = new Random();
        StringBuilder senha = new StringBuilder();

        for (int i = 0; i < tamanho; i++)
        {
            int indice = random.Next(caracteres.Length);
            senha.Append(caracteres[indice]);
        }

        return senha.ToString();
    }

    static void SalvarSenha(string filePath, string senha)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(senha);
            }
            Console.WriteLine("Senha salva com sucesso em bkp.TXT.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar a senha: {ex.Message}");
        }
    }

    static void RecuperarSenhas(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                string[] senhas = File.ReadAllLines(filePath);
                Console.WriteLine("=== Senhas Geradas ===");
                foreach (string senha in senhas)
                {
                    Console.WriteLine(senha);
                }
            }
            else
            {
                Console.WriteLine("Nenhuma senha encontrada.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao recuperar senhas: {ex.Message}");
        }
    }
}
