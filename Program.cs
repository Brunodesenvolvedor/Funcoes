using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== TESTE MANUAL ===");
        Console.Write("Digite um número de celular: ");
        string numero = Console.ReadLine();

        try
        {
            ValidaNumeroDeCelular validador = new ValidaNumeroDeCelular(numero);
            string resultado = validador.TudoCerto();

            Console.WriteLine(resultado);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }

        Console.WriteLine("\n=== TESTE AUTOMÁTICO ===");

        string[] testes =
        {
            "11987654321",      // válido
            "(11)98765-4321",   // válido com máscara
            "12345678901",      // sequência
            "11999999999",      // repetição
            "1198765432",       // menos de 11
            "00987654321",      // DDD inválido
            "11a87654321",      // letra
            "11912345678"       // começa com 1 depois do DDD
        };

        foreach (var teste in testes)
        {
            try
            {
                ValidaNumeroDeCelular validador = new ValidaNumeroDeCelular(teste);
                string resultado = validador.TudoCerto();

                Console.WriteLine($"{teste} -> {resultado}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{teste} -> Erro: {ex.Message}");
            }
        }
    }
}

// testar a validação de numero de celular