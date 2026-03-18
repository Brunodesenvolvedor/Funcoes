using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

/* A senha deve ter pelo menos: uma letra maiúscula, uma letra minúscula, um número, 
um caractere especial (!@#$%...), além disso, não pode ter espaços, nem caracteres repetidos 
em sequência (aaa, 111) */

public class ValidaSenha
{
    private string Senha;

    public ValidaSenha(string senha)
    {
        Senha = senha;
    }

    public string TudoCerto()
    {
        if (!SenhaNaoVazia())
        {
            return ("A senha não pode ser vazia");
        }
        if (!TemPeloMenosOitoCaracteres())
        {
            return ("A senha precisa ter oito caracteres");
        }
        if (!SemTodosIguais())
        {
            return ("Os caracteres não podem ser todos iguais");
        }
        if (!SemSequenciaCrescente())
        {
            return ("A senha não pode ser uma sequência crescente");
        }
        if (!SemSequenciaDecrescente())
        {
            return ("A senha não pode ser uma sequência decrescente");
        }
        return ("CPF válido");
        /* como o return vem depois dos if, não é preciso indicar
        else */
    }

    private bool SenhaNaoVazia()
    {
        return !string.IsNullOrEmpty(Senha);
    }

    private bool TemPeloMenosOitoCaracteres()
    {
        return Senha.Length >= 8;
    }

    private bool TemPeloMenosUmNumero()
    {
        foreach (char c in Senha)
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
        foreach (char c in Senha)
        {
            if (!char.IsLetterOrDigit(c))
            {
                return true;
            }
        }
        return false;
    }

    private bool SemEspaço()
    {
        foreach (char c in Senha)
        {
            if (char.IsWhiteSpace(c))
            {
                return false;
            }
        }
        return true;
    }

    private bool SemSequenciaCrescente()
    {
        for (int i = 0; i < Senha.Length - 1; i++)
        {
            int atual = Senha[i] - '0';
            int proximo = Senha[i + 1] - '0';

            if (atual + 1 == proximo)
            {
                return false;
            }
        }
        return true;
    }

    private bool SemSequenciaDecrescente()
    {
        for (int i = 0; i < Senha.Length - 1; i++)
        {
            int atual = Senha[i] - '0';
            int proximo = Senha[i + 1] - '0';

            if (atual - 1 == proximo)
            {
                return false;
            }
        }
        return true;
    }

    private bool TemLetraMaiuscula()
    {
        foreach (char c in Senha)
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
        foreach (char c in Senha)
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
        char primeiro = Senha[0];

        foreach (char c in Senha)
        {
            if (c != primeiro)
            {
                return false;
            }
        }
        return true;
    }
}