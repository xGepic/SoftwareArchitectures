﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    public interface IEquipment
    {
        public void Use(Hero other);
    }
}
