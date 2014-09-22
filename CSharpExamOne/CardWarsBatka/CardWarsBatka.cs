using System;
using System.Text;

class CardWarsBatka
{
    static void Main()
    {
        int numberOfGames;
        int.TryParse(Console.ReadLine(), out numberOfGames);
        int playerOneGames = 0;
        int playerTwoGames = 0;
        long playerOneGameScore = 0;
        long playerTwoGameScore = 0;
        bool playerOneXCard = false;
        bool playerTwoXCard = false;

        for (int i = 0; i < numberOfGames; i++)
        {
            long playerOneScore = 0;
            long playerTwoScore = 0;

            for (int k = 0; k < 3; k++)
            {
                string card = Console.ReadLine().ToUpper();

                switch (card)
                {
                    case "2":
                        playerOneScore += 10;
                        break;
                    case "3":
                        playerOneScore += 9;
                        break;
                    case "4":
                        playerOneScore += 8;
                        break;
                    case "5":
                        playerOneScore += 7;
                        break;
                    case "6":
                        playerOneScore += 6;
                        break;
                    case "7":
                        playerOneScore += 5;
                        break;
                    case "8":
                        playerOneScore += 4;
                        break;
                    case "9":
                        playerOneScore += 3;
                        break;
                    case "10":
                        playerOneScore += 2;
                        break;
                    case "A":
                        playerOneScore += 1;
                        break;
                    case "J":
                        playerOneScore += 11;
                        break;
                    case "Q":
                        playerOneScore += 12;
                        break;
                    case "K":
                        playerOneScore += 13;
                        break;
                    case "Z":
                        playerOneGameScore *= 2;
                        break;
                    case "Y":
                        playerOneGameScore -= 200;
                        break;
                    case "X":
                        playerOneXCard = true;
                        break;
                    default:
                        playerOneScore += 0;
                        break;
                }
            }

            for (int j = 0; j < 3; j++)
            {
                string card = Console.ReadLine().ToUpper();

                switch (card)
                {
                    case "2":
                        playerTwoScore += 10;
                        break;
                    case "3":
                        playerTwoScore += 9;
                        break;
                    case "4":
                        playerTwoScore += 8;
                        break;
                    case "5":
                        playerTwoScore += 7;
                        break;
                    case "6":
                        playerTwoScore += 6;
                        break;
                    case "7":
                        playerTwoScore += 5;
                        break;
                    case "8":
                        playerTwoScore += 4;
                        break;
                    case "9":
                        playerTwoScore += 3;
                        break;
                    case "10":
                        playerTwoScore += 2;
                        break;
                    case "A":
                        playerTwoScore += 1;
                        break;
                    case "J":
                        playerTwoScore += 11;
                        break;
                    case "Q":
                        playerTwoScore += 12;
                        break;
                    case "K":
                        playerTwoScore += 13;
                        break;
                    case "Z":
                        playerTwoGameScore *= 2;
                        break;
                    case "Y":
                        playerTwoGameScore -= 200;
                        break;
                    case "X":
                        playerTwoXCard = true;
                        break;
                    default:
                        playerTwoScore += 0;
                        break;
                }
            }

            if (playerOneXCard == true && playerTwoXCard == true)
            {
                playerOneGameScore += 50;
                playerTwoGameScore += 50;
            }
            else if (playerOneXCard == true && playerTwoXCard == false)
            {
                break;
            }
            else if (playerOneXCard == false && playerTwoXCard == true)
            {
                break;
            }

            if (playerOneScore > playerTwoScore)
            {
                playerOneGames++;
                playerOneGameScore += playerOneScore;
            }
            else if (playerTwoScore > playerOneScore)
            {
                playerTwoGames++;
                playerTwoGameScore += playerTwoScore;
            }

            playerOneXCard = false;
            playerTwoXCard = false;
        }
        
        if(playerOneXCard == true)
        {
            Console.WriteLine("X card drawn! Player one wins the match!");
        }
        else if (playerTwoXCard == true)
        {
            Console.WriteLine("X card drawn! Player two wins the match!");
        }
        else if (playerOneGameScore > playerTwoGameScore)
        {
            Console.WriteLine("First player wins!");
            Console.WriteLine("Score: {0}", playerOneGameScore);
            Console.WriteLine("Games won: {0}", playerOneGames);
        }
        else if (playerTwoGameScore > playerOneGameScore)
        {
            Console.WriteLine("Second player wins!");
            Console.WriteLine("Score: {0}", playerTwoGameScore);
            Console.WriteLine("Games won: {0}", playerTwoGames);
        }
        else if(playerOneGameScore == playerTwoGameScore)
        {
            Console.WriteLine("It's a tie!");
            Console.WriteLine("Score: {0}", playerOneGameScore);
        }
    }
}
