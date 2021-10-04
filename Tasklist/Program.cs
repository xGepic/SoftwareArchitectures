using System;

namespace Tasklist
{
    class Program
    {
        static void Main()
        {
            TaskHandler taskHandler = new TaskHandler(ToolBox.Welcome());
            taskHandler.Hello();
            while (true)
            {
                int MyInput = ToolBox.GetMenu();
                switch (MyInput)
                {
                    case 1:
                        taskHandler.AddTask();
                        break;
                    case 2:
                        break;
                    case 3:
                        taskHandler.Display();
                        break;
                    case 4:
                        taskHandler.Delete();
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        return;
                    default:
                        ToolBox.WrongNumber();
                        break;
                }
            }
        }
    }
}