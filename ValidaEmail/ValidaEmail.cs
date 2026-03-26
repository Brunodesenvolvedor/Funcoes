using System;

public class ValidaEmail
{
    private string _email;

    public ValidaEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("O e-mail não pode ser vazio, nem ter espaços em branco");
        }
        _email = email;
    }
    // Validação de espaço vazio já dentro do construtor, impedindo a criação de um objeto vazio.

    public string Validar()
    {
        return MensagemErro();
    }

    private string MensagemErro()
    {
        if (!TemArroba())
        {
            return ("O e-mail deve conter um '@'");
        }

        if (!TemPontoPosArroba())
        {
            return ("O e-mail deve conter um ponto ('.')");
        }
        return null;
        if (!TemTextoAntesdaArroba())
        {
            return ("O e-mail deve conter texto antes do '@'");
        }
        if (!PrimeiroDigitoValido())
        { 
            return ("O primeiro dígito do e-mail não pode ser um símbolo");
        }
        if (!UltimoDigitoValido())
        {
            return ("O último dígito antes do '@' deve ser uma letra ou número");
        }
        if (!SimbolosRepetidos())
        {
            return ("O e-mail não pode conter símbolos repetidos em sequência");
        }
        if(!LetraPosArroba())
        {
            return ("O e-mail deve conter caracteres depois da '@'");
        }
        if(PontoPosArroba())
        {
            return ("O e-mail deve conter um ponto depois da '@'");
        }
        return "E-mail válido";
    }

    private bool TemArroba()
    {
        int arrobaCount = 0;

        foreach (char c in _email)
        {
            if (c == '@')
            {
                arrobaCount++;
            }
        }
        return arrobaCount == 1;
    }

    private bool TemPontoPosArroba()
    {
        int indexArroba = _email.IndexOf('@');

        if (indexArroba == -1)
            return false;

        return _email.IndexOf('.', indexArroba) > indexArroba;
    }
    // IndexOf('@') procura a posição do primeiro @ dentro da string _email. O resultado é um número inteiro (se não existir, ele retorna -1). O método IndexOf('.', indexArroba) procura a posição do primeiro ponto (.) a partir da posição do @. Se o resultado for maior que a posição do @, significa que existe um ponto depois do @, o que é necessário para um email válido.

    private bool TemTextoAntesdaArroba()
    {
        int indexArroba = _email.IndexOf('@');
        
        for (int i = 0; i<indexArroba; i++)
        {
            if (char.IsLetter(_email[i]))
            {
                return true;
            }        
        }
        return false;
    }

    private bool PrimeiroDigitoValido()
    {
        char primeiroDigito = _email[0];
        
        return char.IsLetterOrDigit(primeiroDigito);
    }

    private bool UltimoDigitoValido()
    {
        int ultimoDigito = _email.IndexOf('@');
        return char.IsLetterOrDigit(_email[ultimoDigito - 1]);
    }

    private bool SimbolosRepetidos()
    {
        for (int i = 0; i < _email.Length -1; i++)
        {
            char digitoAnterior = _email[i];
            char digitoAtual = _email[i + 1];


            bool anteriorEhSimbolo = !char.IsLetterOrDigit(digitoAnterior);
            bool atualEhSimbolo = !char.IsLetterOrDigit(digitoAtual);
            
            if (anteriorEhSimbolo && atualEhSimbolo)
            // Isso é o mesmo que (anteriorEhSimbolo == true && atualEhSimbolo == true)
            {
                return false;
            }
        }
        return true;
    }

    private bool LetraPosArroba ()
    {
        int posArroba = _email.IndexOf('@') + 1;
        int doisCaracteres = 0;

        for (int i = posArroba; i < _email.Length; i++)
        {
            if (char.IsLetter(_email[i]))
            {
                doisCaracteres++;
            }
        }
        return doisCaracteres >= 2;
    }

    private bool PontoPosArroba()
    {
        int posArroba = _email.IndexOf('@') + 1;
        int temPonto = 0;

        for (int i = posArroba; i < _email.Length; i++)
        {
            if (_email[i] == '.')
            {
                temPonto++;
            }
        }
        return temPonto >= 1;
    }


    int posPonto = _email.IndexOf('.') + 1;
    // depois do ponto deve ter texto com ao menos dois caracteres, não pode ter espaços em branco
}