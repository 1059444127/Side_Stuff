// Code for permutations taken from http://stackoverflow.com/questions/11208446/generating-permutations-of-a-set-most-efficiently

using System;
using System.Linq;

class TheyAreGreen
{
    private static bool NextPermutation(char[] numList)
    {
        /*
         Knuths
         1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation.
         2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l.
         3. Swap a[j] with a[l].
         4. Reverse the sequence from a[j + 1] up to and including the final element a[n].

         */
        var largestIndex = -1;
        for (var i = numList.Length - 2; i >= 0; i--)
        {
            if (numList[i] < numList[i + 1])
            {
                largestIndex = i;
                break;
            }
        }

        if (largestIndex < 0) return false;

        var largestIndex2 = -1;
        for (var i = numList.Length - 1; i >= 0; i--)
        {
            if (numList[largestIndex] < numList[i])
            {
                largestIndex2 = i;
                break;
            }
        }

        var tmp = numList[largestIndex];
        numList[largestIndex] = numList[largestIndex2];
        numList[largestIndex2] = tmp;

        for (int i = largestIndex + 1, j = numList.Length - 1; i < j; i++, j--)
        {
            tmp = numList[i];
            numList[i] = numList[j];
            numList[j] = tmp;
        }

        return true;
    }

    static bool NonConsecutiveCheck(char[] letters)
    {
        bool flag = true;

        for (int i = 1; i < letters.Length; i++)
        {
            if (letters[i] == letters[i - 1])
            {
                flag = false;
                break;
            }
        }

        return flag;
    }

    static void Main()
    {
        int length = int.Parse(Console.ReadLine());

        char[] letters = new char[length];

        for (int i = 0; i < length; i++)
        {
            letters[i] = char.Parse(Console.ReadLine());
        }

        Array.Sort(letters);

        int nonConsecutiveCounter = NonConsecutiveCheck(letters) ? 1 : 0;

        while (NextPermutation(letters))
        {
            if (NonConsecutiveCheck(letters))
            {
                nonConsecutiveCounter++;
            }
        }

        Console.WriteLine(nonConsecutiveCounter);
    }
}
