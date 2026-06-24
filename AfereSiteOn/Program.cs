using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

string dominio = "";
bool prosseguir = false;

while (!prosseguir)

    Console.WriteLine("Testa endereço/n");
    Console.WriteLine("Digite o endereço do site a partir do domínio");
    Console.WriteLine("Use o seguinte formato: google.com");

    dominio = Console.ReadLine() ?? "";

    Console.Clear();

    bool dominioOk = ValidaDominio.validaDominio(dominio);

    if (dominioOk)
    {
        prosseguir = true;
    }
    else
    {
        Console.WriteLine("O domínio é inválido. Tente novamente.\n");
    }
}

string dominioComHTTP = AcrescentaHTTP.Acrescentar(dominio);

// Recebe o 'bool' da função
bool sucessoHTTP = await TestaURL.Testar(dominioComHTTP);

if (sucessoHTTP)
{
    Console.WriteLine("O site respondeu diretamente via HTTP.");
}
// II: HTTP Falhou -> Segue com HTTPS
else
{
    Console.WriteLine("Tentativa em HTTP sem resposta. Tentando conexão segura HTTPS...");

    string dominioComHTTPS = AcrescentaHTTPS.retornoHTTPS(dominio);
    bool sucessoHTTPS = await TestaURL.Testar(dominioComHTTPS);

    if (sucessoHTTPS)
    {
        Console.WriteLine("O site está online via HTTPS.");
    }
    else
    {
        Console.WriteLine("O site não respondeu nem via HTTP nem via HTTPS.");
    }
}
