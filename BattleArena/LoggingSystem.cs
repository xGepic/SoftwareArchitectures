using System;
using System.Collections.Generic;
using System.IO;

//Singleton

namespace BattleArena
{
    class LoggingSystem
    {
        private static readonly LoggingSystem instance = new();
        private readonly LinkedList<string> myLog = new();
        private int PrintLogCounte = 1;
        private int WriteListToFileCounter = 1;
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
        public void PrintLog()
        {
            Console.WriteLine("Full Log:\n\n");
            foreach (var item in myLog)
            {
                Console.WriteLine($"{PrintLogCounte}. {item}");
                PrintLogCounte++;
            }
        }
        public void WriteListToFile()
        {
            string folderName = "\\MyLogs";
            string myFileName = "/myLogger.txt";
            string fileName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + folderName + myFileName;
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            using StreamWriter sw = new(fileName);
            foreach (var item in myLog)
            {
                sw.WriteLine($"{WriteListToFileCounter}. {item}");
                sw.WriteLine();
                WriteListToFileCounter++;
            }
        }
        public string GetTimeStamp()
        {
            return DateTime.Now.ToString("hh.mm.ss.ffff") + " by " + Environment.UserName.ToString();
        }
    }
}
