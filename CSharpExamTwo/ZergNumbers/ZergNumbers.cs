using System;
using System.Numerics;
using System.Text;

class ZergNumbers
{
    static string[] messages = 
    {
        "Rawr",
        "Rrrr",
        "Hsst",
        "Ssst",
        "Grrr",
        "Rarr",
        "Mrrr",
        "Psst",
        "Uaah",
        "Uaha",
        "Zzzz",
        "Bauu",
        "Djav",
        "Myau",
        "Gruh"
    };

    static string numeralSystem = "0123456789ABCDE";

    static BigInteger GetNumericValue(string input)
    {
        StringBuilder numericValue = new StringBuilder();

        for (int i = 0; i < input.Length; i += 4)
        {
            string currentMessage = input.Substring(i, 4);
            int index = Array.FindIndex(messages, s => s.Equals(currentMessage));
            numericValue.Append(numeralSystem[index]);
        }

        return ConvertSystems(numericValue.ToString());
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
        result += numeralSystem.IndexOf(number[0]);

        // Case position 1
        if (number.Length >= 2)
        {
            result += numeralSystem.IndexOf(number[1]) * 15;
        }

        for (int i = 2; i < number.Length; i++)
        {
            BigInteger currentSum = numeralSystem.IndexOf(number[i]) * Power(15, i);
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
