// See https://aka.ms/new-console-template for more information
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
    

        

        Console.WriteLine("Insira a quantidade de caracteres que deseja em sua senha: (Máximo 10 e mínimo 4)");
        if (int.TryParse(Console.ReadLine(), out int caracteres))
        {
            if (caracteres < 4 || caracteres > 10)
            {
                Console.WriteLine("Erro: O número de caracteres deve ser entre 4 e 10.");
                return;
            }

            Console.WriteLine("Você deseja adicionar números na sua senha? (sim/não)");
            string numeros = Console.ReadLine();
            Console.WriteLine("Você deseja adicionar letras na senha? (sim/não)");
            string letras = Console.ReadLine();
            Console.WriteLine("Você deseja adicionar caracteres especiais? (sim/não)");
            string especiais = Console.ReadLine();
            if (numeros != "sim" && letras != "sim" && especiais != "sim")
            {
                Console.WriteLine("Erro: Você deve escolher pelo menos uma opção.");
                return;
            }

            string senha = "";
            Random random = new Random();
            string listaNumeros = "0123456789";
            string listaLetras = "abcdefghijklmnopqrstuvwxyz";
            string listaCaracteres = "@#!.-_";
            for (int i = 0; i < caracteres; i++)
            {
                if (numeros == "sim" && senha.Length < caracteres)
                {
                    senha += listaNumeros[random.Next(listaNumeros.Length)];
                }

                if (letras == "sim" && senha.Length < caracteres)
                {
                    senha += listaLetras[random.Next(listaLetras.Length)];
                }

                if (especiais == "sim" && senha.Length < caracteres)
                {
                    senha += listaCaracteres[random.Next(listaCaracteres.Length)];
                }
            }

            Console.WriteLine("A sua senha é: " + senha);

            
            string caminhoArquivo = "senhas.txt";

            try
            {
                
                using (StreamWriter escritor = new StreamWriter(caminhoArquivo, append: true))
                {
                    escritor.WriteLine($"Senha gerada em {DateTime.Now}: {senha}");
                }

                Console.WriteLine($"Senha salva com sucesso no arquivo '{caminhoArquivo}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar a senha: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Erro: Insira um número válido.");
        }
    }
}           
