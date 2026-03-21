using System;

public class ValidaNumeroDeCelular
{
    private string _numeroCelular;

    private bool DDDCorreto()
    {
        int[] dddsValidos = {
            11,12,13,14,15,16,17,18,19, // SP
            21,22,24,                   // RJ/ES
            27,28,
            31,32,33,34,35,37,38,       // MG
            41,42,43,44,45,46,          // PR
            47,48,49,                   // SC
            51,53,54,55,                // RS
            61,                         // DF
            62,64,                      // GO
            63,                         // TO
            65,66,                      // MT
            67,                         // MS
            68,                         // AC
            69,                         // RO
            71,73,74,75,77,             // BA
            79,                         // SE
            81,87,                      // PE
            82,                         // AL
            83,                         // PB
            84,                         // RN
            85,88,                      // CE
            86,89,                      // PI
            91,93,94,                   // PA
            92,97,                      // AM
            95,                         // RR
            96,                         // AP
            98,99                       // MA
            };
    }

    public ValidaNumeroDeCelular(string numeroCelular)
    {
        _numeroCelular = numeroCelular;
    }

    public string TudoCerto()
    /* Como numeroCelular já é um objeto dentro dessa classe, não é necessário passar ele como parâmetro aqui, basta usar o _numeroCelular diretamente */
    {
        LimpaNumero();

        if (!TemOnzeDigitos())
        {
            return ("O número de celular precisa ter 11 dígitos");
        }

        if (string.IsNullOrWhiteSpace(_numeroCelular))
        {
            return ("O número de celular não pode ser vazio");
        }

        if (!DDDCorreto())
        {
            return ("O número de celular precisa começar com um DDD válido");
        }

        if (!ComecarComNove())
        {
            return ("O número de celular precisa começar com 9");
        }
        return "Número válido";
    }

    private string LimpaNumero()
    {
        return _numeroCelular = _numeroCelular.Replace(" ", "")
                                              .Replace("-", "")
                                              .Replace("(", "")
                                              .Replace(")", "")
                                              .Replace(".", "");
    }
    private bool NumeroNaoVazio()
    {
        return !string.IsNullOrEmpty(_numeroCelular);
    }
    private bool TemOnzeDigitos()
    {
        return _numeroCelular.Length == 11;
    }
    private bool DDDValido()
    {
        int ddd = int.Parse(_numeroCelular.Substring(0, 2));
        return dddsValidos.Contains(ddd);
    }
    private bool ComecarComNove()
    {
        return _numeroCelular[2] == '9';
    }
}

// fazer verificação de numeros sequenciais e repetições
