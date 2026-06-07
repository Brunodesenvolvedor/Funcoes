using System;
using System.Net.Http;
using System.Threading.Tasks;

public class TestaURL
{
    private static readonly HttpClient client = new HttpClient
    {
        Timeout = TimeSpan.FromSeconds(5)
    };
    /*
    - static faz com que exista apenas uma instância de HttpClient para toda a classe;
    - readonly impede que o objeto seja substituído depois de criado;
    - reutilizar HttpClient é mais eficiente e evita problemas de conexão e desperdício de recursos;
    - Timeout define o tempo máximo de espera pela resposta;
    */

    public static async Task<bool> Testar(string url)
    /*
    - async diz que o método pode usar await e vai executar de forma assíncrona
    (não bloqueia o programa enquanto não completa a operação);
    - Task<bool> representa uma operação assíncrona cujo resultado final será um bool;
    */
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Head, url);

            var resposta = await client.SendAsync(request);
            /*
            - HttpRequestMessage permite montar manualmente uma requisição HTTP;
            - HttpMethod.Head pede apenas os cabeçalhos da página, sem baixar o conteúdo;
            - SendAsync envia a requisição usando o HttpClient;
            - await espera a resposta chegar sem travar o programa;
            */

            if (!resposta.IsSuccessStatusCode)
            {
                resposta = await client.GetAsync(url);
            }
            /*
            - alguns sites não aceitam HEAD corretamente;
            - se a resposta não for bem-sucedida, tenta GET;
            - GetAsync baixa a página normalmente e serve como plano B;
            */

            return resposta.IsSuccessStatusCode;
            /*
            - IsSuccessStatusCode verifica se o status HTTP está entre 200 e 299;
            - se estiver, retorna true;
            - caso contrário, retorna false;
            */
        }
        catch (HttpRequestException)
        {
            Console.WriteLine("Erro de requisição (DNS, conexão, SSL, etc)");
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
        - HttpRequestException captura erros relacionados à requisição HTTP
        (DNS não encontrado, sem internet, SSL inválido, conexão recusada etc.);
        - TaskCanceledException normalmente aparece quando o tempo limite é excedido;
        - Exception captura qualquer erro não previsto;
        */
    }
}