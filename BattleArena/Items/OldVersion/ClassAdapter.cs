﻿using BattleArena.Items.OldVersion;
using BattleArena.Pawn;
using System;

namespace BattleArena.Items
{
    //Adapter - Class Adapter - unused because I chose the object adapter
    class MyAdapter : LatharSword
    {
        public MyAdapter() : base(new Random())
        {

        }
        public void Use(Hero other)
        {
            other.ReduceHealth(Hit());
        }
    }
}