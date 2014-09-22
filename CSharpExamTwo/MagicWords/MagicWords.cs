using System;
using System.Collections.Generic;
using System.Text;

class MagicWords
{
    static string Reorder(List<string> words)
    {
        for (int i = 0; i < words.Count; i++)
        {
            string currentWord = words[i];
            int positionToMove = currentWord.Length % (words.Count + 1);
            words.Insert(positionToMove, currentWord);
            if (positionToMove < i)
            {
                words.RemoveAt(i + 1);
            }
            else
            {
                words.RemoveAt(i);
            }
        }

        return Print(words);
    }

    static string Print(List<string> words)
    {
        int highestCount = 0;
        for (int i = 0; i < words.Count; i++)
        {
            if (words[i].Length > highestCount)
            {
                highestCount = words[i].Length;
            }
        }

        StringBuilder toPrint = new StringBuilder();
        for (int i = 0; i < highestCount; i++)
        {
            for (int k = 0; k < words.Count; k++)
            {
                if (i >= words[k].Length)
                {
                    continue;
                }
                toPrint.Append(words[k][i]);
            }
        }

        return toPrint.ToString();
    }

    static void Main()
    {
        List<string> words = new List<string>();
        int size = int.Parse(Console.ReadLine());
        for (int i = 0; i < size; i++)
        {
            words.Add(Console.ReadLine());
        }

        Console.WriteLine(Reorder(words));
    }
}
