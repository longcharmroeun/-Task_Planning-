using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Planing.Interfaces
{
    interface ITaskEditor
    {
        void Delete(int Index);
        void Modify(int index, string TaskName, DateTime Date_Execution, Class.Prioritize Prioritize);
        List<Class.Task> Tasks { get; set; }
    }
}
