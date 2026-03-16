using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;


/* Para cada método que envia um bool, posso pegar esse bool
e transformar numa mensagem ou num ok numa lista de erros 
possíveis, como "caracteres inválidos, mais de onze ou menos*/

public class ValidaCPF (string CPF)
{  

    public bool TudoCerto ()
    {
        if 
        (
        TemOnzeCaracteres(CPF) &&
        ApenasNumeros(CPF) &&
        NaoSequencial(CPF) &&
        VerificaDigitoUm(CPF) &&
        VerificaDigitoDois(CPF)
        )
        {
            return true;
        }
        return false;
    }

    // Verifica o número de caracteres
    private bool TemOnzeCaracteres(string CPF)
    {
        if (CPF.Length == 11)
        { 
            return true;
        }
    
        else 
        {
            return false;
        }
    }

    // Verifica se há apenas números
    private bool ApenasNumeros(string CPF)
    {
        foreach (char c in CPF)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }

    // Verifica se os números são iguais ao primeiro
    private bool NaoSequencial(string CPF)
    {
        char primeiro = CPF[0];

        foreach (char c in CPF)
        {
            if (c != primeiro)
            {
                return true;
            }
        }
        return false;
    }

    private bool VerificaDigitoUm(string CPF)
    { 
        int soma = 0;

        for (int inic = 0; inic < 9; inic++)
        {
            int numero = CPF[inic] - '0';
            int peso = 10 - inic;
            soma += numero * peso;
        }

        int resto = soma % 11;
        int digito;

        if (resto < 2)
        {
            digito = 0;
        }
        else
        {
            digito = 11 - resto;
        }

        if (digito != CPF[9] - '0')
        {
            return false;
        }

        /*Essa conversão do CPF (string )para int é feita pela 
        tabela interna do char, em que cada caractere, em ordem
        crescente, representa um número: 0 é 48, 1 é 49... Assim,
        inic menos zero significa o char correspondente à posição 
        menos o valor correspondente de zero (48)
        */

        return true;
    }

    private bool VerificaDigitoDois(string CPF)
    { 
        int soma = 0;

        for (int inic = 0; inic < 10; inic++)
        {
            int numero = CPF[inic] - '0';
            int peso = 11 - inic;
            soma += numero * peso;
        }

        int resto = soma % 11;
        int digito;

        if (resto < 2)
        {
            digito = 0;
        }
        else
        {
            digito = 11 - resto;
        }

        if (digito != CPF[10] - '0')
        {
            return false;
        }

        return true;
    }

}
