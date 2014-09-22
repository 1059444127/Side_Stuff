using System;
using System.Collections.Generic;

class RelevanceIndex
{

    static char[] splitParams = { ',', '.', '(', ')', ';', '-', '!', '?', ' ' };

    static Dictionary<string, int> Execute(string[] array, string searchWord)
    {
        var dictionary = new Dictionary<string, int>();

        for (int i = 0; i < array.Length; i++)
        {
            string[] split = array[i].Split(splitParams, StringSplitOptions.RemoveEmptyEntries);
            int currentWordCount = 0;
            for (int k = 0; k < split.Length; k++)
            {
                if (split[k].ToLower() == searchWord)
                {
                    split[k] = searchWord.ToUpper();
                    currentWordCount++;
                }
            }

            dictionary.Add(String.Join(" ", split), currentWordCount);
        }

        return dictionary;
    }

    static void Main()
    {
        string searchWord = Console.ReadLine();
        int lines = int.Parse(Console.ReadLine());

        string[] linesArray = new string[lines];

        for (int i = 0; i < lines; i++)
        {
            linesArray[i] = Console.ReadLine();
        }
    }
}
