using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite um email para validar:");
        string email = Console.ReadLine();

        ValidaEmail validador = new ValidaEmail(email);

        string resultado = validador.Validar();
        Console.WriteLine(resultado);

        if (resultado == "E-mail válido")
        {
            Console.WriteLine("Email válido ✅");
        }
        else
        {
            Console.WriteLine("Email inválido ❌");
        }
    }
}