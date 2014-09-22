using System;
using System.Collections.Generic;
using System.Text;

class GenomeDecoder
{
    static Queue<char> characters = new Queue<char>();
    static Queue<int> repeats = new Queue<int>();

    static void SplitInput(string input)
    {
        StringBuilder currentSequence = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            if (Char.IsDigit(input[i]))
            {
                currentSequence.Append(input[i]);
            }
            else if (Char.IsLetter(input[i]) && currentSequence.Length < 1)
            {
                characters.Enqueue(input[i]);
                repeats.Enqueue(1);
            }
            else if (Char.IsLetter(input[i]) && currentSequence.Length > 0)
            {
                repeats.Enqueue(int.Parse(currentSequence.ToString()));
                characters.Enqueue(input[i]);
                currentSequence.Clear();
            }
        }
    }

    static string ExpandDecodedGenome(int n, int m)
    {
        StringBuilder expandedGenome = new StringBuilder();

        while (repeats.Count > 0)
        {
            int numberOfRepeats = repeats.Dequeue();
            char charToRepeat = characters.Dequeue();
            expandedGenome.Append(new string(charToRepeat, numberOfRepeats));
        }


        StringBuilder sb = new StringBuilder();
        int lineCount = 1;
        int numberOfLines = (int)Math.Ceiling((decimal)expandedGenome.Length / (decimal)n);
        int spacingCount = 0;
        sb.AppendFormat("{0} ", DetermineWhitespaces(numberOfLines, lineCount));
        for (int i = 0; i < expandedGenome.Length; i++)
        {
            if (i % n == 0 && i != 0)
            {
                sb.AppendLine();
                lineCount++;
                sb.Append(String.Format("{0} ", DetermineWhitespaces(numberOfLines, lineCount)));
                spacingCount = 0;
            }
            else if (spacingCount - m == 0)
            {
                sb.Append(' ');
                spacingCount = 0;
            }
            sb.Append(expandedGenome[i]);
            spacingCount++;
        }

        Console.WriteLine(sb);

        return "bla";
    }

    static string DetermineWhitespaces(int numberOfLines, int lineCount)
    {
        string numberOfLinesString = numberOfLines.ToString();
        string lineCountString = lineCount.ToString();
        int spaceCount = numberOfLinesString.Length - lineCountString.Length;
        return new string(' ', spaceCount) + lineCountString;
    }

    static void Main()
    {
        string[] lineLengthAndSpacing = Console.ReadLine().Split(' ');
        string input = Console.ReadLine();
        int n = int.Parse(lineLengthAndSpacing[0]);
        int m = int.Parse(lineLengthAndSpacing[1]);
        SplitInput(input);
        ExpandDecodedGenome(n, m);
    }
}
