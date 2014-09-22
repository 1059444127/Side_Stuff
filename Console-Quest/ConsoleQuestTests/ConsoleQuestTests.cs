using ConsoleQuest.BattleSystem;
using ConsoleQuest.Characters.FinishedCharacters;
using ConsoleQUest.Common;
using System;

class ConsoleQuestTests
{
    static void UseAbility()
    {
        Console.WriteLine("Ability Used");
    }

    static void Main()
    {
        Knight sirKnigt = new Knight(4, 100);
        sirKnigt.AbilityUsedEvent += UseAbility;
        sirKnigt.AddXP(10);
        Wolf doge = new Wolf(sirKnigt.Level);
        Console.WriteLine(sirKnigt);
        Console.WriteLine(doge);
        Console.WriteLine();

        while (sirKnigt.IsAlive && doge.IsAlive)
        {
            var knightAttackLog = sirKnigt.DealDamage(doge);
            if (knightAttackLog.AttackPassed)
            {
                Console.WriteLine("{0} Remaining HP: {1}", knightAttackLog, doge.CurrentHitPoints);
            }

            var dogeAttackLog = doge.DealDamage(sirKnigt);
            if (dogeAttackLog.AttackPassed)
            {
                Console.WriteLine("{0} Remaining HP: {1}", dogeAttackLog, sirKnigt.CurrentHitPoints);
            }

            Console.WriteLine();

            sirKnigt.Update();
            doge.Update();
        }

        Console.WriteLine();
        Console.WriteLine(sirKnigt);
        Console.WriteLine(doge);

        Party newParty = new Party(sirKnigt, doge);
        newParty.AddToParty(new PetDog(2, 50));

        EnemyParty<Wolf> enemyParty = EnemyParty<Wolf>.GenerateParty(3, 2);
        Console.WriteLine(enemyParty[0]);

        SaveLoadSystem.LoadGameState();
    }
}
