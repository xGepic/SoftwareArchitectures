using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    class UserIO
    {
        public void PrintFightMenu(String name)
        {
            Console.WriteLine("+--------------------------------------->  ");
            Console.WriteLine("| Your turn: " + name + "                  ");
            Console.WriteLine("|                                          ");
            Console.WriteLine("| 0: End game                              ");
            Console.WriteLine("| 1: Fight the enemy                       ");
            Console.WriteLine("| 2: Create a new leprechaun    ( 2 Coins )");
            Console.WriteLine("| 3: Create a new tiny goblin   ( 1 Coin  )");
            Console.WriteLine("| 4: Create a new medium goblin ( 3 Coins )");
            Console.WriteLine("| 5: Create a new big goblin    ( 6 Coins )");
            Console.WriteLine("+--------------------------------------->  ");
        }
        public void PrintPlayerInformation(Hero[] playerList)
        {
            Console.WriteLine("####################################################################");
            foreach (Hero player in playerList)
            {

                Console.WriteLine("## " + player.GetName() + " | Health: " + player.GetHealth() + " | Coins: "
                        + player.GetCoins() + " | Leprechaun: " + player.GetLeprechaun() + " | Goblins: "
                        + player.GetNumberofGoblins());

            }
            Console.WriteLine("####################################################################\n");
        }
        public int GetUserInput()
        {
            int keyInt = Convert.ToInt32(Console.ReadLine());
            return keyInt;
        }
        public void EndGame(String name)
        {
            Console.Clear();
            Console.WriteLine(name + " lost the game!");
        }
        public void ExitGame()
        {
            Console.Clear();
            Console.WriteLine("Bye\n");
            Environment.Exit(0);
        }
        public void ClearScreen()
        {
            Console.Clear();
        }
    }
}