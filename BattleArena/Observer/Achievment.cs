using BattleArena.Pawn;
using System;

namespace BattleArena
{
    abstract class Achievment : IObserver
    {
        public string Achievmentname { get; set; }
        abstract public void Update(ISubject subject);
    }
    class RichAchievment : Achievment
    {
        private bool AchievmentDone = false;
        public RichAchievment()
        {
            Achievmentname = "MeSoRich";
        }
        public override void Update(ISubject subject)
        {
            if (subject is Hero myHero)
            {
                if (myHero.Coins > 4 && AchievmentDone == false)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Achievment unlocked: {Achievmentname} by {myHero.Name}");
                    Console.WriteLine();
                    AchievmentDone = true;
                    LoggingSystem myLog = LoggingSystem.GetLoggingSystem();
                    myLog.LogSomething("Achievment unlocked: MeSoRich");
                }
            }
        }
    }
    class LuckyAchievment : Achievment
    {
        private bool AchievmentDone = false;
        public LuckyAchievment()
        {
            Achievmentname = "MeSoLucky";
        }
        public override void Update(ISubject subject)
        {
            if (subject is Hero myHero)
            {
                if (myHero.Leprechaun > 4 && AchievmentDone == false)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Achievment unlocked: {Achievmentname} by {myHero.Name}");
                    Console.WriteLine();
                    AchievmentDone = true;
                    LoggingSystem myLog = LoggingSystem.GetLoggingSystem();
                    myLog.LogSomething("Achievment unlocked: MeSoLucky");
                }
            }
        }
    }
}