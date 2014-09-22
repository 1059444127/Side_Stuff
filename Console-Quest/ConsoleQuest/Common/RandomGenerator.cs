namespace ConsoleQuest.Common
{
    using System;

    /// <summary>
    /// Global random number generator.
    /// </summary>
    public static class RandomGenerator
    {
        private static Random randomGen;

        private static string[] wolfNames = 
        {
            "Bite Hound",
            "Paw Claw",
            "Null Claw",
            "Canofang",
            "Wolf Bite",
            "Snapbone",
            "Negadog"
        };

        static RandomGenerator()
        {
            randomGen = new Random();
        }

        /// <summary>
        /// Returns a random value in the specified range.
        /// </summary>
        /// <param name="minValue">Inclusive minimal value.</param>
        /// <param name="maxValue">Exclusive maximal value.</param>
        /// <returns>Random INT value in the specified range.</returns>
        public static int GetRandomValue(int minValue, int maxValue)
        {
            return randomGen.Next(minValue, maxValue);
        }

        /// <summary>
        /// Returns a random wolf name.
        /// </summary>
        /// <returns>string</returns>
        public static string GetRandomWolfName()
        {
            return wolfNames[randomGen.Next(0, wolfNames.Length)];
        }

        public static string GetRandomName(string enemyType)
        {
            string name = string.Empty;

            switch (enemyType)
            {
                case "Wolf":
                    name = GetRandomWolfName();
                    break;
                default:
                    name = GetRandomWolfName();
                    break;
            }

            return name;
        }
    }
}
