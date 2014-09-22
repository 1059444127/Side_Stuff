using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

class MultiverseCommunication
{
    static List<string> numeralSystem = new List<string>()
    {
        "CHU",
        "TEL",
        "OFT",
        "IVA",
        "EMY",
        "VNB",
        "POQ",
        "ERI",
        "CAD",
        "K-A",
        "IIA",
        "YLO",
        "PLA"
    };

    static string alphabet = "0123456789ABC";

    static BigInteger GetNumericValue(string input)
    {
        StringBuilder numericValueString = new StringBuilder();
        for (int i = 0; i < input.Length; i += 3)
        {
            int currentIndex = numeralSystem.IndexOf(input.Substring(i, 3));
            numericValueString.Append(alphabet[currentIndex]);
        }

        return ConvertSystems(numericValueString.ToString());
    }
    static string Reverse(string input)
    {
        StringBuilder reversed = new StringBuilder();
        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversed.Append(input[i]);
        }

        return reversed.ToString();
    }

    static BigInteger ConvertSystems(string number)
    {
        BigInteger result = 0;
        number = Reverse(number);

        // Case position 0
        result += alphabet.IndexOf(number[0]);

        // Case position 1
        if (number.Length >= 2)
        {
            result += alphabet.IndexOf(number[1]) * 13;
        }

        for (int i = 2; i < number.Length; i++)
        {
            BigInteger currentSum = alphabet.IndexOf(number[i]) * Power(13, i);
            result += currentSum;
        }

        return result;
    }

    static BigInteger Power(BigInteger a, BigInteger b)
    {
        if (b < 0)
        {
            throw new ApplicationException("B must be a positive integer or zero");
        }
        if (b == 0) return 1;
        if (a == 0) return 0;
        if (b % 2 == 0)
        {
            return Power(a * a, b / 2);
        }
        else if (b % 2 == 1)
        {
            return a * Power(a * a, b / 2);
        }
        return 0;
    } 
    static void Main()
    {
        string input = Console.ReadLine();
        Console.WriteLine(GetNumericValue(input));
    }
}
