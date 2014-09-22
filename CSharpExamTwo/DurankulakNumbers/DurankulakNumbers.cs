using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

class DurankulakNumbers
{
    static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    static List<string> durankulakNumbers = new List<string>();

    static List<int> decimalRepresentation = new List<int>();

    static void FillDurankulakNumbers()
    {
        int addIndex = -1;
        for (int i = 0; i < 168; i++)
        {
            if (i < 26)
            {
                durankulakNumbers.Add(alphabet[i].ToString());
            }
            else if (i % 26 == 0)
            {
                addIndex++;
                durankulakNumbers.Add(String.Format("{0}{1}", alphabet[addIndex].ToString().ToLower(), alphabet[0]));

            }
            else
            {
                int secondLetterIndex = i % 26;
                durankulakNumbers.Add(String.Format("{0}{1}", alphabet[addIndex].ToString().ToLower(), alphabet[secondLetterIndex]));
            }
        }
    }

    static BigInteger ExtractNumber(string input)
    {
        StringBuilder sb = new StringBuilder();
        int result = 0;

        for (int i = 0; i < input.Length; i++)
        {
            sb.Append(input[i]);

            if (durankulakNumbers.Contains(sb.ToString()))
            {
                decimalRepresentation.Add(durankulakNumbers.IndexOf(sb.ToString()));
                sb.Clear();
            }
        }

        return SBasedNumber(result.ToString(), 168);
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

    static BigInteger SBasedNumber(string number, int baseSystem)
    {
        BigInteger result = 0;
        //decimalRepresentation.Reverse();

        // Position 0
        for (int i = 0; i < decimalRepresentation.Count; i++)
        {
            result += decimalRepresentation[decimalRepresentation.Count - i - 1] + (BigInteger)Math.Pow(168, i) - 1; 
        }

        return result;
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

    static void Main()
    {
        string input = Console.ReadLine();
        FillDurankulakNumbers();
        Console.WriteLine(ExtractNumber(input));
    }
}
