using System;

public class ValidaEmail
{

    private string _email;

    public ValidaEmail(string email)
    {
        _email = email;
    }

    public bool _tudoCerto
    { 
    
    }

    private bool TemArroba ()
    {
        int arrobaCount = 0;

        foreach (char c in _email)
        {
            if (c == '@')
            {
                arrobaCount++;
            }
        }

        if (arrobaCount != 1)
        {
            return false;
        }

        return arrobaCount == 1;

    }


    private bool TemPontoPosArroba()
    {
        int indexArroba = _email.IndexOf('@');
        return _email.IndexOf('.', indexArroba) > indexArroba;
    }
    // IndexOf('@') procura a posição do primeiro @ dentro da string _email. O resultado é um número inteiro (se não existir, ele retorna -1). O método IndexOf('.', indexArroba) procura a posição do primeiro ponto (.) a partir da posição do @. Se o resultado for maior que a posição do @, significa que existe um ponto depois do @, o que é necessário para um email válido.

    private bool TemPontoCom()
    {
        int indexPontoCom = _email.IndexOf(".com");
        return _email.IndexOf(".com") != -1;
    }
}


