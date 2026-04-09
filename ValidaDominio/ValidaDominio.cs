using System;

public class ValidaDominio
{
    public static bool validaDominio(string dominio)
    {
        return !string.IsNullOrWhiteSpace(dominio)
               && dominio.Contains(".")
               && !dominio.StartsWith(".")
               && !dominio.EndsWith(".");
    }
}