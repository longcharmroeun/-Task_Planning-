using System;

namespace Task_Planing.Interfaces
{
    interface ITask
    {
        string TaskName { get; set; }
        DateTime Date_Execution { get; set; }
        Class.Prioritize Prioritize { get; set; }
        string Comment { get; set; }
    }
}
