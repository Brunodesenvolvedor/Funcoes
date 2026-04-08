using System;

public class AcrescentaHTTPS
{
    public static string acrescentaHTTPS(string dominio)
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




/*
1. Receber o texto do usuário
Pode ser domínio ou URL completa
2. Normalizar a entrada (muito importante)

Usuário pode digitar:

google.com
www.google.com
https://google.com

👉 você precisa garantir que vire uma URL válida

Ex:

se não tiver http:// ou https://
→ adicionar https://

Se não tiver protocolo:
tenta com https://
Se falhar:
tenta com http://



*/