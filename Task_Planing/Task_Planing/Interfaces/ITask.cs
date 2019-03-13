using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Planing.Interfaces
{
    interface ITask
    {
        string TaskName { get; set; }
        /// <summary>
        /// Name of Task
        /// </summary>
        /// <returns></returns>
        DateTime Date_Execution { get; set; }
        Class.Prioritize Prioritize { get; set; }
    }
}
