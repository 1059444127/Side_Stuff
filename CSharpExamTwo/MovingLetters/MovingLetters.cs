using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MovingLetters
{
    static string alphabet = "abcdefghijklmnopqrstuvwxyz";

    static string EncodeInput(string input)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        StringBuilder encode = ScrambleInput(input);

        for (int i = 0; i < encode.Length; i++)
        {
            // Get alphabet index
            int alphabetIndex = Char.ToLower(encode[i]) - 'a' + 1;
            int indexToInsert = i;

            if (alphabetIndex + i <= encode.Length)
            {
                indexToInsert = alphabetIndex + i;
            }
            else
            {
                alphabetIndex += i;
                while (true)
                {
                    alphabetIndex -= encode.Length;
                    if (alphabetIndex < 0)
                    {
                        break;
                    }
                    indexToInsert = alphabetIndex;
                }
                //for (int j = 0; j < alphabetIndex; j++)
                //{
                //    if (indexToInsert == encode.Length)
                //    {
                //        indexToInsert = 0;
                //    }
                //    indexToInsert++;
                //}
            }

            char toInsert = encode[i];
            encode = encode.Remove(i, 1);
            if (indexToInsert == encode.Length + 1)
            {
                indexToInsert = 0;
            }
            encode = encode.Insert(indexToInsert, toInsert);
        }

        sw.Stop();
        File.AppendAllText("../../time.txt", String.Format("Encode text: {0} \r\n", sw.Elapsed));
        return encode.ToString();
    }

    static StringBuilder ScrambleInput(string input)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        StringBuilder scramble = new StringBuilder();
        string[] split = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int currentWord = 0;
        int letter = 1;
        while (scramble.Length < input.Length - (split.Length - 1))
        {
            if (currentWord == split.Length)
            {
                currentWord = 0;
                letter++;
                continue;
            }
            if (letter > split[currentWord].Length)
            {
                currentWord++;
                continue;
            }

            scramble.Append(split[currentWord][split[currentWord].Length - letter]);

            currentWord++;
        }

        sw.Stop();
        File.AppendAllText("../../time.txt", String.Format("Scramble words time: {0} \r\n", sw.Elapsed));
        return scramble;
    }

    static void Main()
    {
        checked
        {
            //string input = File.ReadAllText("../../test.txt");
            string input = Console.ReadLine();
            Console.WriteLine(EncodeInput(input));
        }
    }
}
