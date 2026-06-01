using System;

public class ValidadorDominio
{
    public static bool Validar(string dominio)
    {
        if (string.IsNullOrWhiteSpace(dominio))
            return false;

        dominio = dominio.Trim();

        return dominio.Contains(".")
               && !dominio.StartsWith(".")
               && !dominio.EndsWith(".");
    }
    // Esse string.Is... é a classe de onde vem o método IsNul...
    // Trim serve para remover espaços laterais.
}