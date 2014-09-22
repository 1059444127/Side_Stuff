using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

class _9GagNumbers
{
    static List<string> nineGagNumbers = new List<string>()
    {
        "-!",
        "**",
        "!!!",
        "&&",
        "&-",
        "!-",
        "*!!!",
        "&*!",
        "!!**!-"
    };

    static BigInteger SplitNumbers(string input)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder extractedNumbers = new StringBuilder();

        sb.Append(input[0]);
        for (int i = 1; i < input.Length; i++)
        {
            sb.Append(input[i]);

            if (sb.Length > 1 && nineGagNumbers.Contains(sb.ToString()))
            {
                extractedNumbers.Append(nineGagNumbers.IndexOf(sb.ToString()));
                sb.Clear();
                //if (sb.ToString() == "**" && input.Substring(i + 1, 3) == "!!!")
                //{
                //}
                //else
                //{
                //    extractedNumbers.Append(nineGagNumbers.IndexOf(sb.ToString()));
                //    sb.Clear();
                //}

            }
        }

        return SBasedNumber(extractedNumbers.ToString(), 9);
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

    static string hex = "0123456789ABCDEF";

    static string ReverseString(string input)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = input.Length - 1; i >= 0; i--)
        {
            sb.Append(input[i]);
        }

        return sb.ToString();
    }

    static BigInteger SBasedNumber(string number, int baseSystem)
    {
        number = ReverseString(number);
        BigInteger result = 0;

        // Position 0
        result += hex.IndexOf(number[0]);

        // position 1
        if (number.Length >= 2)
        {
            result += hex.IndexOf(number[1]) * baseSystem;
        }

        for (int i = 2; i < number.Length; i++)
        {
            result += (hex.IndexOf(number[i]) * Power(baseSystem, i));
        }

        return result;
    }

    static void Main()
    {
        string input = Console.ReadLine();
        Console.WriteLine(SplitNumbers(input));
    }
}
