using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

string dominio = "";

bool prosseguir = false;

while (!prosseguir)
{
    Console.WriteLine("Digite o endereço do site a partir do domínio");
    Console.WriteLine("Use o seguinte formato: google.com");

    dominio = Console.ReadLine() ?? "";

    bool dominioOk = ValidaDominio.validaDominio(dominio);

    if (dominioOk)
    {
        prosseguir = true;
    }
    else
    {
        Console.WriteLine("O domínio é inválido.");
    }
}

string dominioComHTTP = AcrescentaHTTP.Acrescentar(dominio);

ResultadoTeste resultadoHTTP =
    await TestaURL.Testar(dominioComHTTP);

// Se o HTTP respondeu diretamente, informamos isso.

if (resultadoHTTP.Sucesso)
{
    Console.WriteLine("O site respondeu diretamente via HTTP.");
}

// Se houve redirecionamento ou falha, tentamos HTTPS.

if (!resultadoHTTP.Sucesso || resultadoHTTP.Redirecionado)
{
    string dominioComHTTPS =
        AcrescentaHTTPS.retornoHTTPS(dominio);

    ResultadoTeste resultadoHTTPS =
        await TestaURL.Testar(dominioComHTTPS);

    if (resultadoHTTPS.Sucesso)
    {
        if (resultadoHTTP.Redirecionado)
        {
            Console.WriteLine("O site redirecionou automaticamente para o formato HTTPS:");
            Console.WriteLine(
                resultadoHTTP.UrlRedirecionamento ??
                dominioComHTTPS);
        }

        Console.WriteLine("O site está online via HTTPS.");
    }
    else if (resultadoHTTPS.Redirecionado)
    {
        Console.WriteLine("O endereço HTTPS respondeu com um redirecionamento para:");
        Console.WriteLine(resultadoHTTPS.UrlRedirecionamento);
    }
    else
    {
        Console.WriteLine("O site não respondeu nem via HTTP nem via HTTPS.");
    }
}

