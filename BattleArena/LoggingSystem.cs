﻿using System;
using System.Collections.Generic;
using System.IO;

//Singleton

namespace BattleArena
{
    class LoggingSystem
    {
        private static readonly LoggingSystem instance = new();
        private readonly LinkedList<string> myLog = new();
        private int counter = 1;
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
                Console.WriteLine($"{counter}. {item}");
                counter++;
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
                sw.WriteLine($"{counter}. {item}");
                counter++;
            }
        }
    }
}
