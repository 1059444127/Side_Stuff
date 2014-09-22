using System;

class JoroTheRabbit
{
    static void Main()
    {
        string[] terrain = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        int[] numbersInTerrain = new int[terrain.Length];

        bool[] visitedSteps = new bool[terrain.Length];

        for (int i = 0; i < terrain.Length; i++)
        {
            numbersInTerrain[i] = int.Parse(terrain[i]);
        }

        int numberOfHops = 0;
        for (int i = 1; i < terrain.Length; i++)
        {
            int currentHops = 1;
            int lastStep = numbersInTerrain[i];
            visitedSteps[i] = true;
            int step = i;

            while (true)
            {
                step += i;
                if (step >= terrain.Length)
                {
                    step -= i;
                    int stepHolder = step;
                    for (int k = stepHolder; k <= stepHolder + i; k++)
                    {
                        if (step >= terrain.Length)
                        {
                            step = -1;
                        }
                        step++;
                    }
                }
                if (visitedSteps[step] == true)
                {
                    break;
                }

                int currentStep = numbersInTerrain[step];
                visitedSteps[step] = true;

                if (currentStep <= lastStep)
                {
                    break;
                }
                lastStep = currentStep;
                currentHops++;
            }

            if (currentHops > numberOfHops)
            {
                numberOfHops = currentHops;
            }

            for (int k = 0; k < visitedSteps.Length; k++)
            {
                visitedSteps[k] = false;
            }
        }

        Console.WriteLine(numberOfHops);
    }
}
