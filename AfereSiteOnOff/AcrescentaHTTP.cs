using System;

public class AcrescentaHTTP
{
    public static string substituiHTTPS(string dominio) 
    {
        return dominio.Replace("https://", "http://");
    }
}