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
        private List<int>  numberScoredPoints= new List<int>();
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
            Winner();
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


        public void CheckWinnerCount(int winner)
        {
            //int result = from p in winner
            //             group p by p.Value into g
            //             where g.Count() > 1
            //             select g;


            //foreach (var r in result)
            //{
            //    var sameValue = (from p in r
            //                     select p.Key + "").ToArray();


            //    Console.WriteLine("Player{0} has the same value {1}:",
            //                      string.Join(",", sameValue), r.Key);
            //}

            //Console.ReadKey();
           // var lookup = findWiner.ToLookup(x => x.Value, x => x.Key).Where(x => x.Count() > 1);
           // Winner();
        }

        public void Winner()
        {
            Console.Clear();
            var winnerName = findWiner.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            Console.WriteLine($"   Winner is:\n    Player{winnerName} score - {findWiner.Values.Max()}");
        }
    }
}
