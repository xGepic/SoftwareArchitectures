﻿using System;

namespace BattleArena
{
    class Game
    {
        public Game()
        {

        }
    }
    class Program
    {
        static void Main()
        {
            UserIO userinteraction = new();
            Random randomNumberGenerator = new();
            Hero[] playerList = { new Hero("Player 1", new CynradBow(randomNumberGenerator)), new Hero("Player 2", new CynradBow(randomNumberGenerator)) };
            bool run = true;
            while (run)
            {
                userinteraction.ClearScreen();
                userinteraction.PrintPlayerInformation(playerList);
                foreach(Hero currentHero in playerList)
                {
                    bool action = false;
                    do
                    {
                        int userinput = -1;
                        do
                        {
                            userinteraction.PrintFightMenu(currentHero.GetName());
                            userinput = userinteraction.GetUserInput();
                        } while (userinput < 0 || userinput > 5);
                        switch (userinput)
                        {
                            case 0:
                                run = false;
                                userinteraction.ExitGame();
                                break;
                            case 1:
                                if (currentHero.GetName() == "Player 1")
                                {
                                    action = currentHero.Action(playerList[1]);
                                }
                                else
                                {
                                    action = currentHero.Action(playerList[0]);
                                }
                                break;
                            case 2:
                                action = currentHero.AddLeprechaun();
                                break;
                            case 3:
                                action = currentHero.AddTinyGoblin(randomNumberGenerator);
                                break;
                            case 4:
                                action = currentHero.AddMediumGoblin(randomNumberGenerator);
                                break;
                            case 5:
                                action = currentHero.AddBigGoblin(randomNumberGenerator);
                                break;
                            default:
                                break;
                        }
                        if (!action)
                        {
                            userinteraction.ClearScreen();
                            userinteraction.PrintPlayerInformation(playerList);
                            Console.WriteLine("\nNot enought money");
                        }
                    } while (!action);
                    currentHero.UpdateCoins();
                    if (currentHero.GetName() == "Player 1")
                    {
                        currentHero.UseGoblins(playerList[1]);
                    }
                    else
                    {
                        currentHero.UseGoblins(playerList[0]);
                    }
                }
                if(playerList[0].GetHealth() <= 0)
                {
                    userinteraction.EndGame(playerList[0].GetName());
                    run = false;
                }else if(playerList[1].GetHealth() <= 0)
                {
                    userinteraction.EndGame(playerList[1].GetName());
                    run = false;
                }
            }
        }
    }
}