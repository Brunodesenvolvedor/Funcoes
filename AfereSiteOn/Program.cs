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

/* 
Funcionamento geral do program: 

1. Recebe um dominio (string) do usuário.
2. Chama a classe de validação de domínio: se ela retornar falsa o programa estanca; se retornar true, avança.
3. Se avançou, ele chama a função que acrescenta HTTP no domínio e retorna a string para o program.
4. O program executa a função Testa URL, o coração do app. 
5. A função faz uma requisição HTTP, com um tempo limite, para o endereço que o usuário informou.
6. Se o site redirecionou, chamamos a função Acrescenta HTTPS, que troca o HTTP para HTTPS, e tentamos de novo.
7. Sinalizamos que funcionou ou não.
Por enquanto, faltam testes finais.
Depois dessa função, vou criar uma que estude o redirecionamento e o registre.
/*
