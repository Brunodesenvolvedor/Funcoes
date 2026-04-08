using System;

Console.WriteLine("Digite o endereço do site a partir do domínio\n" +
                  "Use o seguinte formato: google.com");

/* criei duas classes, uma valida se há https e, caso não haja, acrescenta um; a segunda faz o mesmo com http. No program, vamos chamar o método de uma classe e, caso falhe, chamamos o método da outra (http)*/

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