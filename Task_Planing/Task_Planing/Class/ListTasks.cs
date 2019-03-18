using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Task_Planing.Interfaces;
using Microsoft.Win32.TaskScheduler;

namespace Task_Planing.Class
{
    public partial class ListTasks : ITaskEditor
    {
        [JsonProperty("Tasks", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<Task> Tasks { get; set; }

        public void Delete(int Index)
        {
            try
            {
                Tasks.RemoveAt(Index);
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        public void Modify(int Index, string TaskName, DateTime Date_Execution, Prioritize Prioritize)
        {
            try
            {
                Tasks.ElementAt(Index).TaskName = TaskName;
                Tasks.ElementAt(Index).Prioritize = Prioritize;
                Tasks.ElementAt(Index).Date_Execution = Date_Execution;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw;
            }
        }

        public ListTasks()
        {
            Tasks = new List<Task>();
        }
    }

    public partial class ListTasks
    {
        public static ListTasks ListTaskFromJson(string json) => JsonConvert.DeserializeObject<ListTasks>(json, Task_Planing.Class.Converter.Settings);
        public static ListTasks Load()
        {
            ListTasks listTasks = new ListTasks();
            using (TaskService ts = new TaskService())
            {
                var TaskFolder =  ts.GetFolder("Task_Planing");
                if (TaskFolder != null)
                {
                    foreach (var item in TaskFolder.AllTasks)
                    {
                        listTasks.Tasks.Add(new Task() { TaskName = item.Name, Comment = item.Definition.RegistrationInfo.Description, Date_Execution = item.Definition.Triggers.First().StartBoundary });
                    }
                }
            }
            return listTasks;
        }
        public static Task TaskFromJson(string json) => JsonConvert.DeserializeObject<Task>(json, Task_Planing.Class.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ListTasks self) => JsonConvert.SerializeObject(self, Task_Planing.Class.Converter.Settings);
        public static void Create(this Task task)
        {
            using (TaskService ts = new TaskService())
            {
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = task.Comment;
                td.Triggers.Add(new TimeTrigger() { StartBoundary = task.Date_Execution });
                td.Actions.Add(new ExecAction(System.Environment.CurrentDirectory + @"\Task_Planing.exe", $"{task.TaskName} {task.Comment}", null));
                ts.RootFolder.RegisterTaskDefinition(@"Task_Planing\" + task.TaskName, td);
            }
        }
        public static void Delete(this Task task)
        {
            using (TaskService ts = new TaskService())
            {
                if (ts.GetTask(@"Task_Planing\" + task.TaskName) != null)
                {
                    ts.RootFolder.DeleteTask(@"Task_Planing\" + task.TaskName);
                }
            }
        }
        public static void Modify(this Task task)
        {
            using (TaskService ts = new TaskService())
            {
                if (ts.GetTask(@"Task_Planing\" + task.TaskName) != null)
                {
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = task.Comment;
                    td.Triggers.Add(new TimeTrigger() { StartBoundary = task.Date_Execution });
                    td.Actions.Add(new ExecAction(System.Environment.CurrentDirectory + @"\Task_Planing.exe", $"{task.TaskName} {task.Comment}", null));
                    ts.RootFolder.RegisterTaskDefinition(@"Task_Planing\" + task.TaskName, td);
                }
            }
        }
        public static string ToJson(this Task task) => JsonConvert.SerializeObject(task, Task_Planing.Class.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            DateFormatString = "MM/dd/yyyy H:mm",
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            Formatting = Formatting.Indented
        };
    }
}
