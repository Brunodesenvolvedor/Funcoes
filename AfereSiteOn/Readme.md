Essa função busca verificar se um site está ou não online.

O Funcionamento geral do program é o seguinte: 

1. Ele recebe um dominio (string) do usuário.
2. Depois, chama — dentro de um while — a função de validação de domínio.
3. Se ela retornar false, o programa retorna ao começo; se retornar true, avança.
4. Se avançou, ele chama a função que acrescenta HTTP no domínio e retorna a string para o program.
5. O program executa a função Testa URL, o coração do app. 
6. A função faz uma requisição HTTP, com um tempo limite, para o endereço que o usuário informou.
7. Se o site redirecionou, chamamos a função Acrescenta HTTPS, que troca o HTTP para HTTPS, e tentamos de novo.
8. Sinalizamos que funcionou ou não

Por enquanto, faltam testes finais.
Depois dessa função, vou criar uma que estude o redirecionamento e o registre.
