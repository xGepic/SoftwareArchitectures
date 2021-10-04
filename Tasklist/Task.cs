using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasklist
{
    class Task
    {
        public string TaskName { get; set; }
        public string TaskText { get; set; }
        public uint Priority { get; set; }
        public Task(string name, string text, uint num)
        {
            TaskName = name;
            TaskText = text;
            Priority = num;
        }
    }
}