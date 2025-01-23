
using System;

class GeradorDeSenha
{
    static void Main()
    {
    
        Console.Write("Quantos caracteres deseja para a senha? ");
        int tamanho = int.Parse(Console.ReadLine());

        
        Console.Write("Incluir letras (sim/não)? ");
        bool incluirLetras = Console.ReadLine().Trim().ToLower() == "sim";

        Console.Write("Incluir números (sim/não)? ");
        bool incluirNumeros = Console.ReadLine().Trim().ToLower() == "sim";

        Console.Write("Incluir símbolos (sim/não)? ");
        bool incluirSimbolos = Console.ReadLine().Trim().ToLower() == "sim";

       
        string senha = GerarSenha(tamanho, incluirLetras, incluirNumeros, incluirSimbolos);

       
        Console.WriteLine($"Sua senha gerada é: {senha}");
    }

    static string GerarSenha(int tamanho, bool incluirLetras, bool incluirNumeros, bool incluirSimbolos)
    {
        
        string letrasMaiusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string letrasMinusculas = "abcdefghijklmnopqrstuvwxyz";
        string numeros = "0123456789";
        string simbolos = "!@#$%^&*()-_=+[]{}|;:,.<>?/";
        
        string caracteresPermitidos = "";

     
        if (incluirLetras)
            caracteresPermitidos += letrasMaiusculas + letrasMinusculas;
        if (incluirNumeros)
            caracteresPermitidos += numeros;
        if (incluirSimbolos)
            caracteresPermitidos += simbolos;

       
        if (string.IsNullOrEmpty(caracteresPermitidos))
        {
            throw new Exception("É necessário incluir pelo menos um tipo de caractere.");
        }

        Random random = new Random();
        char[] senhaArray = new char[tamanho];

      
        for (int i = 0; i < tamanho; i++)
        {
            senhaArray[i] = caracteresPermitidos[random.Next(caracteresPermitidos.Length)];
        }

        return new string(senhaArray);
    }
}

{
  public static void RecuperarSenhas()
    {
        string caminhoBackup = "bkp.txt";
        if (File.Exists(caminhoBackup))
        {
            try
            {
                string[] senhas = File.ReadAllLines(caminhoBackup); 
                Console.WriteLine("Senhas recuperadas do backup:");
                foreach (var senha in senhas)
                {
                    Console.WriteLine(senha); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler o arquivo de backup: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Não há senhas salvas no backup.");
        }
    }

    static void Main()
    {
        Console.WriteLine("Gerador de Senhas Seguras");

        while (true)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Gerar nova senha");
            Console.WriteLine("2 - Recuperar senhas do backup");
            Console.WriteLine("3 - Sair");
            Console.Write("Digite a opção: ");
            int opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
               
                Console.Write("Informe o tamanho da senha: ");
                int tamanho = int.Parse(Console.ReadLine());

                Console.Write("Incluir letras (s/n): ");
                bool incluirLetras = Console.ReadLine().ToLower() == "s";

                Console.Write("Incluir números (s/n): ");
                bool incluirNumeros = Console.ReadLine().ToLower() == "s";

                Console.Write("Incluir símbolos (s/n): ");
                bool incluirSimbolos = Console.ReadLine().ToLower() == "s";

                string senha = GerarSenha(tamanho, incluirLetras, incluirNumeros, incluirSimbolos);
                Console.WriteLine($"Senha gerada: {senha}");

                Console.Write("Deseja salvar essa senha no backup? (s/n): ");
                if (Console.ReadLine().ToLower() == "s")
                {
                     salvarembackup(senha);
                }
            }
            else if (opcao == 2)
            {
                
                RecuperarSenhas();
            }
            else if (opcao == 3)
            {
                
                Console.WriteLine("Saindo...");
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }
    }
}
