using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

public class ValidaCPF
{
    private string CPF;

    public ValidaCPF(string cpf)
    {
        CPF = cpf;
    }
    /* Método construtor */

    public string TudoCerto ()
    {
        if (!CPFNaoVazio())
        {
            return ("CPF não pode ser vazio");
        }
        if (!TemOnzeCaracteres())
        {
            return ("CPF deve ter 11 caracteres");
        }
        if (!ApenasNumeros())
        {
            return ("CPF deve ter apenas números");
        }
        if (!NaoSequencial())
        {
            return ("CPF não deve ser sequencial");
        }
        if (!SemSequenciaCrescente())
        {
            return ("CPF não pode ser uma sequência crescente");
        }
        if (!SemSequenciaDecrescente())
        {
            return ("CPF não pode ser uma sequência decrescente");
        }
        if (!VerificaDigitoUm())
        {
            return ("Primeiro dígito inválido");
        }
        if (!VerificaDigitoDois())
        {
            return ("Segundo dígito inválido");
        }
        return ("CPF válido");
        /* como o return vem depois dos if, não é preciso indicar
        else */
    }

    private bool SemSequenciaCrescente()
    {
        for (int i = 0; i < CPF.Length - 1; i++)
        {
            int atual = CPF[i] - '0';
            int proximo = CPF[i + 1] - '0';

            if (atual + 1 == proximo)
            {
                return false;
            }
        }
        return true;
    }
    
    private bool SemSequenciaDecrescente()
    {
        for (int i = 0; i < CPF.Length - 1; i++)
        {
            int atual = CPF[i] - '0';
            int proximo = CPF[i + 1] - '0';

            if (atual - 1 == proximo)
            {
                return false;
            }
        }
        return true;
    }

    private bool TodosIguais()
    {
        char primeiro = CPF[0];
        foreach (char c in CPF)
        {
            if (c != primeiro)
            {
                return false;
            }
        }
        return true;
    }

    private bool CPFNaoVazio()
    {
        return !string.IsNullOrEmpty(CPF);
    }

    // Verifica o número de caracteres
    private bool TemOnzeCaracteres()
    {
        return CPF.Length == 11;
    }

    // Verifica se há apenas números
    private bool ApenasNumeros()
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
    private bool NaoSequencial()
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

    private bool VerificaDigitoUm()
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

    private bool VerificaDigitoDois()
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
