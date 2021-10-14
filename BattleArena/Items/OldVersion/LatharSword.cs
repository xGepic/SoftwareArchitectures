using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    class LatharSword
    {
        private Random randomNumberGenerator;
        static readonly int strength = 5;
        static readonly int percentageVariable = 4;
        public LatharSword(Random randomNumberGenerator)
        {
            this.randomNumberGenerator = randomNumberGenerator;
        }
        public int Hit()
        {
            if (randomNumberGenerator.Next(10) < percentageVariable)
            {
                return strength;
            }
            return 0;
        }
    }
}
