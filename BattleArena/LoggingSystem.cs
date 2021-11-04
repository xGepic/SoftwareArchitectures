using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Singleton

namespace BattleArena
{
    class LoggingSystem
    {
        private static readonly LoggingSystem instance = new();
        private LinkedList<string> myLog = new();
        private LoggingSystem()
        {

        }
        public static LoggingSystem GetLoggingSystem()
        {
            return instance;
        }
    }
}
