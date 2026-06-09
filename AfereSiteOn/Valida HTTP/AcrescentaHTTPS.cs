using System;

public class AcrescentaHTTPS
{
    public static string retornoHTTPS(string dominio)
    {
        if (!temHTTPS(dominio))
        {
            return addHTTPS(dominio);
        }
        else
        {
            return dominio;
        }
    }

    private static string addHTTPS(string dominio)
    {
        dominio = "https://" + dominio;
        return dominio;
    }

    private static bool temHTTPS(string dominio)
    {
        return dominio.StartsWith("https://");
        // Método que verifica se a string começa com "https://" e retorna um bool
    }
}