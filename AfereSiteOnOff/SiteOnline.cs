using System;

Console.WriteLine("Digite o endereço do site a partir do domínio\n" +
                  "Use o seguinte formato: google.com");

/* 

como o program vai funcionar: 

ele vai receber um dominio do usuário, uma string
vai chamar a classe de validação de domínio, se ela retornar falsa estanca, se retornar true, avança

chama a acrescenta HTTPS, ela vai verificar se tem https, se tiver, retorna a string, se não tiver, acrescenta e retorna a string

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