using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasklist
{
    class TaskHandler
    {
        List<Task> TaskList = new List<Task>();
        private readonly string ListOwner;
        public TaskHandler(string name)
        {
            ListOwner = name;
        }
        public void Hello()
        {
            Console.WriteLine($"\n\nTaskList by {ListOwner}\n");
        }
        public void AddTask()
        {
            Console.WriteLine();
            Console.Write("Please enter a TaskName: ");
            string name = Console.ReadLine();
            Console.Write("Please enter a Description: ");
            string text = Console.ReadLine();
            Console.Write("Please enter a Priority (0 - 100): ");
            try
            {
                uint num = Convert.ToUInt32(Console.ReadLine());
                if (num < 0 || num > 100)
                {
                    Console.WriteLine("\nError: Please enter a valid Integer (0 - 100)!\n");
                    return;
                }
                Console.WriteLine();
                Task TempTask = new Task(name, text, num);
                TaskList.Add(TempTask);
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("\nError: Please enter an Integer!\n");
            }
        }
        public void Display()
        {
            int i = 1;
            if (!TaskList.Any())
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("The List is Empty!\n");
                return;
            }
            Console.Clear();
            foreach (Task task in TaskList)
            {
                Console.WriteLine();
                Console.WriteLine($"Task {i}");
                Console.Write("Name: ");
                Console.Write(task.TaskName + "\n");
                Console.Write("Description: ");
                Console.Write(task.TaskText + "\n");
                Console.Write("Priority: ");
                Console.Write(task.Priority + "\n");
                Console.WriteLine();
                i++;
            }
        }
        public void Delete()
        {
            int count = TaskList.Count;
            Console.Clear();
            Display();
            if(count == 0)
            {
                return;
            }
            Console.Write("Which Task would You like to Delete?: ");
            try
            {
                int del = Convert.ToInt32(Console.ReadLine());
                if (del < 0 || del > count)
                {
                    Console.WriteLine("\nError: Please enter a valid Integer!\n");
                    return;
                }
                TaskList.RemoveAt(del - 1);
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("\nError: Please enter an Integer!\n");
            }
        }
    }
}