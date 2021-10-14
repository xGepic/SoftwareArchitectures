using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    public class Hero
    {
        private String name;
        private int health;
        private int coins;
        private int leprechaun;
        private int lastKeyInput;
        private IEquipment weapon;
        private List<Goblin> goblins = new();
        public Hero(String name, IEquipment equipment)
        {
            this.name = name;
            this.health = 100;
            this.coins = 1;
            this.leprechaun = 0;
            lastKeyInput = -1;
            weapon = equipment;
        }
        public bool Action(Hero other)
        {
            weapon.Use(other);
            return true;
        }
        public void UpdateCoins()
        {
            coins += leprechaun + 1;
        }
        public void UseGoblins(Hero other)
        {
            foreach (Goblin tmpGoblin in goblins)
            {
                tmpGoblin.Action(other);
            }
        }
        public int GetHealth()
        {
            return health;
        }
        public void ReduceHealth(int hitpoints)
        {
            this.health -= hitpoints;
        }
        public int GetCoins()
        {
            return coins;
        }
        public bool AddLeprechaun()
        {
            if (coins > 1)
            {
                coins -= 2;
                leprechaun++;
                return true;
            }
            return false;
        }
        public int GetLeprechaun()
        {
            return leprechaun;
        }
        public int GetNumberofGoblins()
        {
            return goblins.Count;
        }
        public bool AddTinyGoblin(Random randomNumberGenerator)
        {
            if (coins > 0)
            {
                coins -= 1;
                goblins.Add(new Goblin(1, randomNumberGenerator));
                return true;
            }
            return false;
        }
        public bool AddMediumGoblin(Random randomNumberGenerator)
        {
            if (coins > 2)
            {
                coins -= 3;
                goblins.Add(new Goblin(2, randomNumberGenerator));
                return true;
            }
            Console.WriteLine("test");
            return false;
        }
        public bool AddBigGoblin(Random randomNumberGenerator)
        {
            if (coins > 5)
            {
                coins -= 6;
                goblins.Add(new Goblin(3, randomNumberGenerator));
                return true;
            }
            return false;
        }
        public String GetName()
        {
            return this.name;
        }
        public void SetName(String name)
        {
            this.name = name;
        }
        public int GetLastKeyInput()
        {
            return lastKeyInput;
        }
        public void SetLastKeyInput(int key)
        {
            lastKeyInput = key;
        }
    }
}
