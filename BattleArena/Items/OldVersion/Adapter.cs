using BattleArena.Items.OldVersion;
using BattleArena.Pawn;
using System;

namespace BattleArena.Items
{
    //Adapter - Object Adapter
    //I chose the Object Adapter because I found It much more straightforward to implement and to comprehend
    class Adapter : IEquipment
    {
        private readonly LatharSword LatharSword;
        public Adapter(LatharSword mySword)
        {
            LatharSword = mySword;
        }
        public void Use(Hero other)
        {
            other.ReduceHealth(LatharSword.Hit());
        }
    }
}
