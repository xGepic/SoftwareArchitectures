﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasklist
{
    class TaskHandler
    {
        private List<Task> TaskList = new();
        private readonly string ListOwner;
        private const int Min = 0;
        private const int Fif = 50;
        private const int Max = 100;
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
                if (num < Min || num > Max)
                {
                    Console.WriteLine("\nError: Please enter a valid Integer (0 - 100)!\n");
                    return;
                }
                Console.Write("In how many Days is the Task due?: ");
                uint days = Convert.ToUInt32(Console.ReadLine());
                DateTime due = DateTime.Today.AddDays(days);
                var TempTask = new Task(name, text, num, due);
                Console.WriteLine();
                TaskList.Add(TempTask);
                Console.WriteLine("\nTask successfully added!\n");
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
            if (IsEmpty(TaskList))
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
                Console.Write("DueDate: ");
                Console.Write(task.DueDate.ToLongDateString() + "\n");
                Console.WriteLine();
                i++;
            }
        }
        public void Delete()
        {
            int count = TaskList.Count;
            Console.Clear();
            Display();
            if (count == Min)
            {
                return;
            }
            Console.Write("Which Task would You like to Delete?: ");
            try
            {
                int del = Convert.ToInt32(Console.ReadLine());
                if (del < 1 || del > count)
                {
                    Console.WriteLine("\nError: Please enter a valid Integer!\n");
                    return;
                }
                TaskList.RemoveAt(del - 1);
                Console.WriteLine("\nTask successfully removed!\n");
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("\nError: Please enter an Integer!\n");
            }
        }
        public void Update()
        {
            int count = TaskList.Count;
            Console.Clear();
            Display();
            if (IsEmpty(TaskList))
            {
                return;
            }
            Console.Write("Which Task would You like to Update?: ");
            try
            {
                int update = Convert.ToInt32(Console.ReadLine());
                if (update < 1 || update > count)
                {
                    Console.WriteLine("\nError: Please enter a valid Integer!\n");
                    return;
                }
                Console.Write("Please enter a TaskName: ");
                string name = Console.ReadLine();
                Console.Write("Please enter a Description: ");
                string text = Console.ReadLine();
                Console.Write("Please enter a Priority (0 - 100): ");
                uint num = Convert.ToUInt32(Console.ReadLine());
                if (num < Min || num > Max)
                {
                    Console.WriteLine("\nError: Please enter a valid Integer (0 - 100)!\n");
                    return;
                }
                //var TempTask = new Task(name, text, num);
                //TaskList[update - 1] = TempTask;
                Console.WriteLine("\nTask successfully updated!\n");
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("\nError: Please enter an Integer!\n");
            }
        }
        public void Filter()
        {
            Console.Clear();
            if (IsEmpty(TaskList))
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("The List is Empty!\n");
                return;
            }
            int input = ToolBox.GetFilterMenu();
            if (input == -1)
            {
                return;
            }
            if (input == 1)
            {
                TaskList = TaskList.OrderByDescending(x => x.Priority).ToList();
                Console.WriteLine("Ordered TaskList!");
                Display();
            }
            if (input == 2)
            {
                foreach (Task task in TaskList) if (task.Priority > Fif)
                    {
                        Console.Write("Name: ");
                        Console.Write(task.TaskName + "\n");
                        Console.Write("Description: ");
                        Console.Write(task.TaskText + "\n");
                        Console.Write("Priority: ");
                        Console.Write(task.Priority + "\n");
                        Console.WriteLine();
                    }
            }
            if (input == 3)
            {
                foreach (Task task in TaskList) if (task.Priority < Fif)
                    {
                        Console.Write("Name: ");
                        Console.Write(task.TaskName + "\n");
                        Console.Write("Description: ");
                        Console.Write(task.TaskText + "\n");
                        Console.Write("Priority: ");
                        Console.Write(task.Priority + "\n");
                        Console.WriteLine();
                    }
            }
        }
        public static bool IsEmpty(List<Task> taskList)
        {
            if (taskList.Any())
            {
                return false;
            }
            return true;
        }
    }
}