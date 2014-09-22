using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generale
{
    class Generale
    {
        static List<string> commands = new List<string>() 
        {
            "roll",
            "pair",
            "three-of-a-kind",
            "straight",
            "full-house",
            "four-of-a-kind",
            ""
        }
        static List<string> ParseCommand(string input)
        {
            
        }
        static void Main(string[] args)
        {
            Die newDice = new Die();
            Console.WriteLine(newDice.ThrowDice());
            Console.WriteLine(newDice.LastThrow());
        }
    }
}
