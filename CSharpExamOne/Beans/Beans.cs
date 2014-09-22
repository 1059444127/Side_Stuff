using System;

class Beans
{
    static void Main()
    {
        double tomatoes, cucumbers, potatoes, carrots, cabbage, beans;
        int tomatoesArea, cucumbersArea, potatoesArea, carrotsArea, cabbageArea;
        double.TryParse(Console.ReadLine(), out tomatoes);
        int.TryParse(Console.ReadLine(), out tomatoesArea);
        double.TryParse(Console.ReadLine(), out cucumbers);
        int.TryParse(Console.ReadLine(), out cucumbersArea);
        double.TryParse(Console.ReadLine(), out potatoes);
        int.TryParse(Console.ReadLine(), out potatoesArea);
        double.TryParse(Console.ReadLine(), out carrots);
        int.TryParse(Console.ReadLine(), out carrotsArea);
        double.TryParse(Console.ReadLine(), out cabbage);
        int.TryParse(Console.ReadLine(), out cabbageArea);
        double.TryParse(Console.ReadLine(), out beans);

        double totalPrice = (tomatoes * 0.5) + (cucumbers * 0.4) + (potatoes * 0.25) + (carrots * 0.6) + (cabbage * 0.3) + (beans * 0.4);
        int remainingArea = 250 - (tomatoesArea + cucumbersArea + carrotsArea + cabbageArea + potatoesArea);

        if (remainingArea > 0)
        {
            Console.WriteLine("Total cost: {0:F2}", totalPrice);
            Console.WriteLine("Beans area: {0}", remainingArea);
        }
        else if (remainingArea == 0)
        {
            Console.WriteLine("Total cost: {0:F2}", totalPrice);
            Console.WriteLine("No area for beans");
        }
        else
        {
            Console.WriteLine("Total cost: {0:F2}", totalPrice);
            Console.WriteLine("Insufficient area");
        }
    }
}
