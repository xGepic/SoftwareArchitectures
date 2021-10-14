using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    class Goblin
    {
        private int strength;
        private Random randomNumberGenerator;
        static readonly int percentageVariable = 3;
        public Goblin(int strength, Random randomNumberGenerator)
        {
            this.strength = strength;
            this.randomNumberGenerator = randomNumberGenerator;
        }
        public void Action(Hero other)
        {
            if (randomNumberGenerator.Next(10) < percentageVariable)
            {
                other.ReduceHealth(strength);
            }
        }
    }
}
