using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    class GameController
    {
        private List<int> totalRoledCount;
        private int sumRolls;
        private int rollDice;
        Dictionary<int, int> findWiner = new Dictionary<int, int>();
        

        Random rand = new Random();

        public void PlayerRoll(int setPlayerCount, int setDiceCount)
        {
            Console.Clear();
            findWiner.Clear();
            for (int i = 1; i <= setPlayerCount; i++)
            {
                Console.Write($" Player{i}  Rolled -");
                RollDice(setDiceCount);
                findWiner.Add(i, sumRolls);
            }
            Console.ReadKey();
            CheckWinnerCount(setDiceCount);
        }

        public void RollDice(int setDiceCount)
        {
            totalRoledCount = new List<int>();
            for (int i = 1; i <= setDiceCount; i++)
            {
                rollDice = rand.Next(1, 7);
                Console.Write($" {rollDice}");
                totalRoledCount.Add(rollDice);
            }
            SumRolls();
        }

        public void SumRolls() 
        {
            sumRolls = totalRoledCount.Sum(x => x);
            Console.Write($"  Total - { sumRolls}\n");
        }


        public void CheckWinnerCount(int setDiceCount)
        {
            int addWinnerCount = 0;
            int setPlayerCount = 0;
            var howMAnyWinners = findWiner.Values.Max();
            var checkWinnerCount = findWiner.Where(x => x.Value == howMAnyWinners).Select(p => p.Key);

            foreach (var name in checkWinnerCount)
            {
                addWinnerCount++;
                setPlayerCount = addWinnerCount;
            }
            if (addWinnerCount >= 2)
            {
                PlayerRoll(setPlayerCount, setDiceCount);
            }
            else
            {
                Winner();
            }
        }

        public void Winner()
        {
            Console.Clear();
            var winnerName = findWiner.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            Console.WriteLine($"   Winner is:\n    Player{winnerName} score - {findWiner.Values.Max()}");
        }
    }
}
