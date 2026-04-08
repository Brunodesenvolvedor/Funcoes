using System;

public class AcrescentaHTTP
{
    public static string acrescentaHTTP(string dominio)
    {
        if (!temHTTP(dominio))
        {
            return addHTTP(dominio);
        }
        else
        {
            return dominio;
        }
    }

    private static string addHTTP(string dominio)
    {
        dominio = "http://" + dominio;
        return dominio;
    }

    private static bool temHTTP(string dominio)
    {
        return dominio.StartsWith("http://");
        // Método que verifica se a string começa com "http://" e retorna um bool
    }

}

