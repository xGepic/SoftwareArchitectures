using System;
using System.Collections.Generic;
using System.IO;

namespace BattleArena
{
    class FileHandler
    {
        private readonly string fileName; //Use relative path here
        private int counter = 1;
        public FileHandler(LinkedList<string> myLog)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            using StreamWriter sw = File.CreateText(fileName);
            foreach (var item in myLog)
            {
                sw.WriteLine($"{counter}. {item}");
                counter++;
            }
        }
        public void WriteContent()
        {
            using StreamReader sr = File.OpenText(fileName);
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
        }
    }
}