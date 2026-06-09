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

/*
 * Se o HTTP respondeu diretamente,
 * informamos isso.
 */
if (resultadoHTTP.Sucesso)
{
    Console.WriteLine("O site respondeu diretamente via HTTP.");
}

/*
 * Se houve redirecionamento ou falha,
 * tentamos HTTPS.
 */
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

// se der ok, sinalizar o ok e não seguir
// se não der, fazer o teste com o htttps


/* 

como o program vai funcionar: 

ele vai receber um dominio do usuário, uma string
vai chamar a classe de validação de domínio, se ela retornar falsa estanca, se retornar true, avança

chama a acrescenta HTTP, ela vai verificar se tem http, se tiver, retorna a string, se não tiver, acrescenta e retorna a string

chama a função testa URL, usando o https, e coloca o resultado numa variável. Caso dê certo, encerra o programa com o resultado (repensar, posso aplicar varios testes). Caso dê errado, avança

chama a função acrescenta HTTP, ela vai substituir o https por http e retornar a string

chama a função testa URL, agora usando o http


    O que já fiz:

  . criei uma classe para validar o dominio, ela precisa ser chamada primeiro no program, assim não preciso validar 
    se ele vem vazio nas validações http/https.

  . criei duas classes, uma valida se há https e, caso não haja, acrescenta um; a segunda substitui o https por http.


 */

/*
1. Receber o texto do usuário
Pode ser domínio ou URL completa


3. Validar minimamente
não pode ser vazio
precisa ter formato aceitável (ex: conter um ponto)
4. Fazer requisição HTTP
tentar acessar o endereço
5. Interpretar resposta
✔️ Sucesso (200–299)

→ site online

⚠️ Erro (404, 500…)

→ site existe, mas com problema

❌ Falha (exceção)

→ site offline ou inválido

6. Tratar exceções
erro de DNS
timeout
URL inválida
7. Mostrar resultado

Pontos importantes (nível mais realista)
🔸 Nem todo site aceita requisição
pode bloquear bot
🔸 Alguns redirecionam
HTTP → HTTPS
🔸 Pode demorar
usar timeout

Ideias de evolução (isso aqui vira projeto forte)
testar vários sites em sequência
medir tempo de resposta
mostrar status code (200, 404…)
salvar histórico
transformar em API


*/