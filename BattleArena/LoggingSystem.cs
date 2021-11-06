using System.Collections.Generic;

//Singleton

namespace BattleArena
{
    class LoggingSystem
    {
        private static readonly LoggingSystem instance = new();
        public readonly LinkedList<string> myLog = new();
        private LoggingSystem()
        {

        }
        public static LoggingSystem GetLoggingSystem()
        {
            return instance;
        }
        public void LogSomething(string message)
        {
            myLog.AddLast(message);
        }
    }
}
