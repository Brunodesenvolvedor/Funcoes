using System;
using System.Net.Http;
using System.Threading.Tasks;

public class TestaURL
{
    public static async Task<bool> TestarUrl(string url)
    /* 
    - async diz que o método pode usar await e vai executar de forma assíncrona (não bloqueia o programa não 
    completa a operação)
    - Task indica que uma operação que ainda está acontecendo vai retornar um bool
    */
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(5);

                var resposta = await client.GetAsync(url);

                return resposta.IsSuccessStatusCode;
                /* 
                - using garante que o objeto HttpClient seja descartado após o uso, evitando vazamentos de recursos;
                - HttpClient faz requisições HTTP (como um navegador); 
                - await espera o processo desenrolar;
                - getAsync tenta acessar a URL e retorna uma resposta do tipo HttpResponseMessage com informações como status code, headers e content;
                - IsSuccessStatusCode verifica se o status da resposta é 200-299 (ou seja, se o site está online), depois retorna um bool;
                */
            }
        }
        catch (HttpRequestException)
        {
            Console.WriteLine("Erro de requisição (DNS, conexão, etc)");
            return false;
        }
        catch (TaskCanceledException)
        {
            Console.WriteLine("Timeout");
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
            return false;
        }
        /* 
         HttpRequestException captura erros relacionados à requisição HTTP (DNS não encontrado
         sem internet, conexão recusada, servidor inacessível, SSL inválido etc.) 
         TaskCanceledException pega erros quando a operação excede o tempo limite (timeout) ou a tarefa foi cancelada
         */
    }
}