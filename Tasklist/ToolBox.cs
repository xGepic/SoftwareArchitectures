using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasklist
{
    public static class ToolBox
    {
        private static bool FormatFlag = false;
        public static int GetMenu()
        {
            Console.WriteLine("1 - Insert a new Task into the List");
            Console.WriteLine("2 - Update a Task in the List");
            Console.WriteLine("3 - Display the List");
            Console.WriteLine("4 - Delete a Task in the List");
            Console.WriteLine("5 - Filter Tasks in a List");
            Console.WriteLine("6 - Exit");
            Console.Write("Input: ");
            try
            {
                int input = Convert.ToInt32(Console.ReadLine());
                return input;
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("\nError: Invalid Input!\n");
                FormatFlag = true;
                return -1;
            }
        }
        public static string Welcome()
        {
            Console.WriteLine("--| Welcome to your own Tasklist! |--\n\n");
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }
        public static void WrongNumber()
        {
            if (FormatFlag)
            {
                FormatFlag = false;
                return;
            }
            Console.WriteLine("\nError: Invalid Input: Use Numbers 1-6!\n");
        }
    }
}