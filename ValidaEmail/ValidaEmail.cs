using System;

public class ValidaEmail
{
    private string _email;

    public ValidaEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("O e-mail não pode ser vazio");
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
}

// texto antes do @ e texto depois do ponto

