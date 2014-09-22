using System;
using System.Text;

class DecodeAndDecrypt
{
    static string Decrypt(string message, string cypher)
    {
        StringBuilder sb = new StringBuilder();
        if (message.Length > cypher.Length)
        {
            int cypherIndex = 0;
            for (int i = 0; i < message.Length; i++)
            {
                if (cypherIndex >= cypher.Length)
                {
                    cypherIndex = 0;
                }
                int secondCharCode = CalculateXORCode(message[i], cypher[cypherIndex]);
                sb.Append((char)secondCharCode);
                cypherIndex++;
            }
        }
        else if (cypher.Length > message.Length)
        {
            for (int i = 0; i < message.Length; i++)
            {
                char firstChar = CalculateXORCode(message[i], cypher[i]);
                if (i + message.Length < cypher.Length)
                {
                    char secondChar = CalculateXORCode(firstChar, cypher[i + message.Length]);
                    sb.Append(secondChar);
                }
                else
                {
                    sb.Append(firstChar);
                }
            }
        }
        else
        {
            for (int i = 0; i < message.Length; i++)
            {
                sb.Append(CalculateXORCode(message[i], cypher[i]));
            }
        }

        return sb.ToString();
    }

    static string Decode(string input)
    {
        StringBuilder decodedMessage = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            if (i == input.Length - 1)
            {
                decodedMessage.Append(input[i]);
                break;
            }
            if (Char.IsDigit(input[i]))
            {
                int repetition = (int)Char.GetNumericValue(input[i]);
                char charToRepeat = input[++i];
                decodedMessage.Append(new string(charToRepeat, repetition));
            }
            else
            {
                decodedMessage.Append(input[i]);
            }
        }

        int cypherLength = (int)Char.GetNumericValue(decodedMessage[decodedMessage.Length - 1]);
        string decodedMessageString = decodedMessage.ToString();
        string cypher = decodedMessageString.Substring((decodedMessageString.Length - cypherLength) - 1, cypherLength);
        string message = decodedMessageString.Substring(0, decodedMessageString.Length - cypherLength - 1);
        string finalMessage = Decrypt(message, cypher);

        return finalMessage;
    }

    static char CalculateXORCode(char firstChar, char secondChar)
    {
        int firstCharCode = firstChar - 'A';
        int secondCharCode = secondChar - 'A';
        int code = (firstCharCode ^ secondCharCode) + 65;
        return (char)code;
    }

    static void Main()
    {
        string input = Console.ReadLine();
        Console.WriteLine(Decode(input));
    }
}
