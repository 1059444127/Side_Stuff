using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generale
{
    public class Die
    {
        private List<int> throws = new List<int>();
        private static Random randomGenerator = new Random();

        public int ThrowDice()
        {
            int result = randomGenerator.Next(1, 7);
            AddThrow(result);
            return result;
        }

        private void AddThrow(int diceThrow)
        {
            throws.Add(diceThrow);
        }

        public int LastThrow()
        {
            return throws[throws.Count - 1];
        }

        public List<int> GetAllThrows()
        {
            return throws;
        }

        public Die()
        {
            
        }
    }
}
