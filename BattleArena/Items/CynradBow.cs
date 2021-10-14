using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    class CynradBow : IEquipment
    {
        private string name = "Cynrad Bow";
        private int strength = 10;
        private Random randomNumberGenerator;
        static readonly int percentageVariable = 2;
        public CynradBow(Random randomNumberGenerator)
        {
            this.randomNumberGenerator = randomNumberGenerator;
        }
        public string GetName()
        {
            return name;
        }
        public void Use(Hero other)
        {
            if (randomNumberGenerator.Next(10) < percentageVariable)
            {
                other.ReduceHealth(strength);
            }
        }
    }
}
