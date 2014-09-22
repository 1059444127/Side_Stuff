using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class EncodeAndEncrypt
{
    static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    static string Encrypt(string message, string cypher)
    {
        StringBuilder encryptedMessage = new StringBuilder();
        if (message.Length > cypher.Length)
        {
            int cypherIndex = 0;
            for (int i = 0; i < message.Length; i++)
            {
                if (cypherIndex >= cypher.Length)
                {
                    cypherIndex = 0;
                }
                encryptedMessage.Append(CalculateXORCode(message[i], cypher[cypherIndex]));
                cypherIndex++;
            }
        }
        else if (cypher.Length > message.Length)
        {
            for (int i = 0; i < message.Length; i++)
            {
                char firstCode = CalculateXORCode(message[i], cypher[i]);
                if (i + message.Length < cypher.Length)
                {
                    firstCode = CalculateXORCode(firstCode, cypher[i + message.Length]);
                }

                encryptedMessage.Append(firstCode);
            }
        }
        else if (message.Length == cypher.Length)
        {
            for (int i = 0; i < message.Length; i++)
            {
                encryptedMessage.Append(CalculateXORCode(message[i], cypher[i]));
            }
        }

        encryptedMessage.Append(cypher);
        return encryptedMessage.ToString();
    }

    static string Encode(string message, string cypher)
    {
        StringBuilder encodedMessage = new StringBuilder();
        StringBuilder messageCheck = new StringBuilder();
        string encryptedMessage = Encrypt(message, cypher);

        messageCheck.Append(encryptedMessage[0]);
        for (int i = 1; i < encryptedMessage.Length; i++)
        {
            if (encryptedMessage[i] == messageCheck[messageCheck.Length - 1])
            {
                messageCheck.Append(encryptedMessage[i]);
            }
            else
            {
                if (messageCheck.Length <= 2)
                {
                    encodedMessage.Append(messageCheck);
                    messageCheck.Clear();
                    messageCheck.Append(encryptedMessage[i]);
                }
                else
                {
                    encodedMessage.Append(String.Format("{0}{1}", messageCheck.Length, messageCheck[0]));
                    messageCheck.Clear();
                    messageCheck.Append(encryptedMessage[i]);
                }
            }
        }

        if (messageCheck.Length >= 2)
        {
            encodedMessage.Append(String.Format("{0}{1}", messageCheck.Length, messageCheck[0]));
        }
        else
        {
            encodedMessage.Append(messageCheck);
        }
        encodedMessage.Append(cypher.Length);

        return encodedMessage.ToString();
    }

    static char CalculateXORCode(char firstChar, char secondChar)
    {
        int firstCharCode = alphabet.IndexOf(firstChar);
        int secondCharCode = alphabet.IndexOf(secondChar);
        int code = (secondCharCode ^ firstCharCode) + 65;
        return (char)code;
    }

    static void Main()
    {
        string message = Console.ReadLine();
        string cypher = Console.ReadLine();
        Console.WriteLine(Encode(message, cypher));

    }
}
