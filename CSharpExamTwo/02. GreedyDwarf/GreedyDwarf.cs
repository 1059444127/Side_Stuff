using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GreedyDwarf
{
    static int[] GetPattern (string patternInput)
    {      
        char[] splitArguments = { ',', ' ' };
        string[] split = patternInput.Split(splitArguments, StringSplitOptions.RemoveEmptyEntries);

        var pattern = new int[split.Length];

        for (int i = 0; i < split.Length; i++)
        {
            int.TryParse(split[i], out pattern[i]);
        }

        return pattern;
    }

    static void Main()
    {
        string valley = Console.ReadLine();
        var valleyPattern = GetPattern(valley);

        int numberOfPatterns;
        int.TryParse(Console.ReadLine(), out numberOfPatterns);
        int maxSum = 0;

        for (int i = 0; i < numberOfPatterns; i++)
        {
            string currentPatternInput = Console.ReadLine();
            var currentPattern = GetPattern(currentPatternInput);
            int currentSum = valleyPattern[0];
            int currentHop = 0;
            int counter = 0;
            bool[] takenCoins = new bool[valleyPattern.Length];
            takenCoins[0] = true;

            while (true)
            {
                int hopIndex = counter % currentPattern.Length;
                currentHop += currentPattern[hopIndex];

                if (currentHop < 0 || currentHop > valleyPattern.Length - 1)
                {
                    break;
                }
                else if (takenCoins[currentHop] == true)
                {
                    break;
                }

                currentSum += valleyPattern[currentHop];
                takenCoins[currentHop] = true;

                counter++;
            }

            if (i == 0)
            {
                maxSum = currentSum;
            }
            else if (currentSum > maxSum)
            {
                maxSum = currentSum;
            }
        }

        Console.WriteLine(maxSum);
    }
}
