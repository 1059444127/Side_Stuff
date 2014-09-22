using System;
using System.Collections.Generic;
using System.Text;


class BasicLanguage
{
    static void Main()
    {
        checked
        {
            string[] input = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            Queue<string> commandQueue = new Queue<string>();

            Queue<string> toExecute = new Queue<string>();

            for (int i = 0; i < input.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder executeText = new StringBuilder();
                for (int k = 0; k < input[i].Length; k++)
                {
                    sb.Append(input[i][k]);
                    if (sb.ToString().Contains("FOR") || sb.ToString().Contains("PRINT") || sb.ToString().Contains("EXIT"))
                    {
                        commandQueue.Enqueue(sb.ToString().Trim());
                        sb.Clear();
                        k++;
                        if (k >= input[i].Length)
                        {
                            break;
                        }
                        executeText.Append(input[i][k]);

                        while (executeText[executeText.Length - 1] != ')')
                        {
                            k++;
                            executeText.Append(input[i][k]);
                        }

                        toExecute.Enqueue(executeText.ToString());
                    }
                    executeText.Clear();
                }
            }

            bool inALoop = false;
            StringBuilder toPrint = new StringBuilder();
            int timesToLoop = 1;
            while (true)
            {
                string command = commandQueue.Dequeue();
                if (command == "EXIT")
                {
                    Console.WriteLine(toPrint);
                    return;
                }
                string stringToExecute = toExecute.Dequeue().Trim();
                stringToExecute = stringToExecute.Substring(1, stringToExecute.Length - 2);

                switch (command)
                {
                    case "FOR":
                        if (stringToExecute.Contains(","))
                        {
                            int commaIndex = stringToExecute.IndexOf(',');
                            string firstLiteral = stringToExecute.Substring(0, commaIndex);
                            string secondLiteral = stringToExecute.Substring(commaIndex + 1);
                            firstLiteral = firstLiteral.Trim();
                            secondLiteral = secondLiteral.Trim();
                            int firstLiteralInt = int.Parse(firstLiteral);
                            int secondLiteralInt = int.Parse(secondLiteral);
                            timesToLoop *= secondLiteralInt - firstLiteralInt + 1;
                            inALoop = true;
                        }
                        else
                        {
                            int literal = int.Parse(stringToExecute.Trim());
                            timesToLoop *= literal;
                            inALoop = true;
                        }
                        break;
                    case "PRINT":
                        if (inALoop == true)
                        {
                            for (int i = 0; i < timesToLoop; i++)
                            {
                                toPrint.Append(stringToExecute);
                            }
                            inALoop = false;
                            timesToLoop = 1;
                        }
                        else
                        {
                            toPrint.Append(stringToExecute);
                        }
                        break;
                    default:
                        return;
                }
            }
        }
    }
}