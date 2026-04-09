using System;
using System.Net.Http;
using System.Threading.Tasks;

public class TestaURL
{
    public static async Task<bool> TestarUrl(string url)
    /* async diz que o método: pode usar await e vai executar de forma assíncrona (não bloqueia o programa)*/
    {
        using (HttpClient client = new HttpClient())
        {
            var resposta = await client.GetAsync(url);

            return resposta.IsSuccessStatusCode;
            /* 
            - using garante que o objeto HttpClient seja descartado após o uso, evitando vazamentos de recursos;
            - HttpClient faz requisições HTTP (como um navegador); 
            - await espera o processo desenrolar;
            - getAsync tenta acessar a URL e retorna uma resposta do tipo HttpResponseMessage com informações como status code, headers e content;
            - IsSuccessStatusCode verifica se o status da resposta é 200-299, ou seja, se o site está online, e retorna um bool;
            */
        }
    }
}
