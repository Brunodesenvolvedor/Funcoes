using System;

public class ValidaCpf
{
    private string _cpf;

    public ValidaCpf(string cpf)
    {
        _cpf = cpf;
    }

    public string TudoCerto()
    {
        if (!CpfNaoVazio())
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
    }

    private bool SemSequenciaCrescente()
    {
        for (int i = 0; i < _cpf.Length - 1; i++)
        {
            int atual = _cpf[i] - '0';
            int proximo = _cpf[i + 1] - '0';

            if (atual + 1 == proximo)
            {
                return false;
            }
        }
        return true;
    }

    private bool SemSequenciaDecrescente()
    {
        for (int i = 0; i < _cpf.Length - 1; i++)
        {
            int atual = _cpf[i] - '0';
            int proximo = _cpf[i + 1] - '0';

            if (atual - 1 == proximo)
            {
                return false;
            }
        }
        return true;
    }

    private bool TodosIguais()
    {
        char primeiro = _cpf[0];
        foreach (char c in _cpf)
        {
            if (c != primeiro)
            {
                return false;
            }
        }
        return true;
    }

    private bool CpfNaoVazio()
    {
        return !string.IsNullOrEmpty(_cpf);
    }

    private bool TemOnzeCaracteres()
    {
        return _cpf.Length == 11;
    }

    private bool ApenasNumeros()
    {
        foreach (char c in _cpf)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }

    private bool NaoSequencial()
    {
        char primeiro = _cpf[0];

        foreach (char c in _cpf)
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
            int numero = _cpf[inic] - '0';
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

        if (digito != _cpf[9] - '0')
        {
            return false;
        }

        return true;
    }

    private bool VerificaDigitoDois()
    {
        int soma = 0;

        for (int inic = 0; inic < 10; inic++)
        {
            int numero = _cpf[inic] - '0';
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

        if (digito != _cpf[10] - '0')
        {
            return false;
        }

        return true;
    }
}