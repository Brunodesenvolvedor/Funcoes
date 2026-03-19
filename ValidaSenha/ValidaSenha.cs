using System;

/* A senha deve ter pelo menos: uma letra maiúscula, uma letra minúscula, um número, 
um caractere especial (!@#$%...), além disso, não pode ter espaços, nem caracteres repetidos 
em sequência (aaa, 111) */

/*

1. Retornar múltiplos erros

em vez de parar no primeiro

*/

public class ValidaSenha
{
    private string _senha;

    public ValidaSenha(string senha)
    {
        _senha = senha;
    }

    public string TudoCerto()
    {
        if (!SenhaNaoVazia())
        {
            return ("A senha não pode ser vazia");
        }
        if (!TemPeloMenosOitoCaracteres())
        {
            return ("A senha precisa ter 8 caracteres");
        }
        if (!SemEspaco())
        {
            return ("A senha não pode conter espaços");
        }
        if (!SemTodosIguais())
        {
            return ("Os caracteres não podem ser todos iguais");
        }
        if (!TemPeloMenosUmNumero())
        {
            return ("A senha precisa ter pelo menos um número");
        }
        if (!TemPeloMenosUmCaractereEspecial())
        {
            return ("A senha precisa ter pelo menos um caractere especial");
        }
        if (!TemLetraMaiuscula())
        {
            return ("A senha precisa ter pelo menos uma letra maiúscula");
        }
        if (!TemLetraMinuscula())
        {
            return ("A senha precisa ter pelo menos uma letra minúscula");
        }
        if (!SemSequenciaCrescente())
        {
            return ("A senha não pode ser uma sequência crescente");
        }
        if (!SemSequenciaDecrescente())
        {
            return ("A senha não pode ser uma sequência decrescente");
        }
        if (!SemRepeticaoSequencial())
        {
            return "A senha não pode ter caracteres repetidos em sequência";
        }
        return ("Senha válida");
    }

    private bool SenhaNaoVazia()
    {
        return !string.IsNullOrEmpty(_senha);
    }

    private bool TemPeloMenosOitoCaracteres()
    {
        return _senha.Length >= 8;
    }

    private bool TemPeloMenosUmNumero()
    {
        foreach (char c in _senha)
        {
            if (char.IsDigit(c))
            {
                return true;
            }
        }

        return false;
    }

    private bool TemPeloMenosUmCaractereEspecial()
    {
        foreach (char c in _senha)
        {
            if (!char.IsLetterOrDigit(c))
            {
                return true;
            }
        }
        return false;
    }

    private bool SemEspaco()
    {
        foreach (char c in _senha)
        {
            if (char.IsWhiteSpace(c))
            {
                return false;
            }
        }
        return true;
    }

    private bool SemSequenciaDecrescente()
    {
        for (int i = 0; i < _senha.Length - 1; i++)
        {
            if (
                (char.IsDigit(_senha[i]) && char.IsDigit(_senha[i + 1])) ||
                (char.IsLetter(_senha[i]) && char.IsLetter(_senha[i + 1]))
            )
            {
                if (_senha[i] - 1 == _senha[i + 1])
                    return false;
            }
        }
        return true;
    }

    private bool SemSequenciaCrescente()
    {
        for (int i = 0; i < _senha.Length - 1; i++)
        {
            if (
                (char.IsDigit(_senha[i]) && char.IsDigit(_senha[i + 1])) ||
                (char.IsLetter(_senha[i]) && char.IsLetter(_senha[i + 1]))
            )
            {
                if (_senha[i] + 1 == _senha[i + 1])
                    return false;
            }
        }
        return true;
    }

    private bool SemRepeticaoSequencial()
    {
        for (int i = 0; i < _senha.Length - 1; i++)
        {
            if (_senha[i] == _senha[i + 1])
            {
                return false;
            }
        }
        return true;
    }

    private bool TemLetraMaiuscula()
    {
        foreach (char c in _senha)
        {
            if (char.IsUpper(c))
            {
                return true;
            }
        }
        return false;
    }

    private bool TemLetraMinuscula()
    {
        foreach (char c in _senha)
        {
            if (char.IsLower(c))
            {
                return true;
            }
        }
        return false;
    }

    private bool SemTodosIguais()
    {
        char primeiro = _senha[0];

        foreach (char c in _senha)
        {
            if (c != primeiro)
            {
                return true;
            }
        }
        return false;
    }
}