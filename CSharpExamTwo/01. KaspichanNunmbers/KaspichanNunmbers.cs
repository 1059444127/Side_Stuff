using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

class KaspichanNunmbers
{
    static void Main()
    {
        checked
        {
            List<string> baseSystem = new List<string>();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int currentLetterIndex = 0;

            for (int i = 0; i < 256; i++)
            {

                if (i < 26)
                {
                    baseSystem.Add(alphabet[i].ToString());
                }
                else if (i % 26 == 0)
                {
                    currentLetterIndex = (i / 26) - 1;
                    baseSystem.Add(String.Format("{0}{1}", alphabet[currentLetterIndex].ToString().ToLower(), alphabet[0].ToString()));
                }
                else
                {
                    int secondLetterIndex = i % 26;
                    baseSystem.Add(String.Format("{0}{1}", alphabet[currentLetterIndex].ToString().ToLower(), alphabet[secondLetterIndex].ToString()));
                }
            }

            BigInteger number;
            BigInteger.TryParse(Console.ReadLine(), out number);
            StringBuilder sb = new StringBuilder();

            if (number == 0)
            {
                sb.Append("A");
            }
            else
            {
                while (number > 0)
                {
                    BigInteger remainder = number % 256;
                    number /= 256;
                    sb.Insert(0, baseSystem[(int)remainder]);
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
