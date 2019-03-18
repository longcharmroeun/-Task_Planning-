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
        #region Property Region
        /// <summary>
        /// Property Tasks
        /// </summary>
        [JsonProperty("Tasks", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<Task> Tasks { get; set; }
        #endregion

        #region Method Region
        /// <summary>
        /// Delete Tasks
        /// </summary>
        /// <param name="Index">Tasks Index</param>
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

        /// <summary>
        /// Modify Index
        /// </summary>
        /// <param name="Index">Tasks Index</param>
        /// <param name="TaskName"></param>
        /// <param name="Date_Execution"></param>
        /// <param name="Prioritize"></param>
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

        /// <summary>
        /// Array of index tasks search
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public int[] DateSearch(System.DateTime StartDate , System.DateTime EndDate)
        {
            int[] tmp = new int[Tasks.Count];
            int Count = 0;
            for (int i = 0; i < Tasks.Count; i++)
            {
                if (Tasks[i].Date_Execution >= StartDate && Tasks[i].Date_Execution <= EndDate)
                {
                    tmp[Count] = i;
                    Count++;
                }
            }

            int[] realtmp = new int[Count];
            for (int i = 0; i < Count; i++)
            {
                realtmp[i] = tmp[i];
            }

            return realtmp;
        }
        #endregion

        #region Contrutor Region
        /// <summary>
        /// Implement Tasks
        /// </summary>
        public ListTasks()
        {
            Tasks = new List<Task>();
        }
        #endregion
    }

    public partial class ListTasks
    {
        #region Method Region
        /// <summary>
        /// Deserialize ListTask from json
        /// </summary>
        /// <param name="json">Json text</param>
        /// <returns></returns>
        public static ListTasks ListTaskFromJson(string json) => JsonConvert.DeserializeObject<ListTasks>(json, Task_Planing.Class.Converter.Settings);

        /// <summary>
        /// Load data from Task Scheduler
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Deserialize TaskS from json
        /// </summary>
        /// <param name="json">Json text</param>
        /// <returns></returns>
        public static Task TaskFromJson(string json) => JsonConvert.DeserializeObject<Task>(json, Task_Planing.Class.Converter.Settings);
        #endregion
    }

    public static class Serialize
    {
        #region Method Region
        /// <summary>
        /// Serialze obj to Json
        /// </summary>
        /// <param name="self">obj</param>
        /// <returns></returns>
        public static string ToJson(this ListTasks self) => JsonConvert.SerializeObject(self, Task_Planing.Class.Converter.Settings);

        /// <summary>
        /// Create Task Schedule
        /// </summary>
        /// <param name="task">obj</param>
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

        /// <summary>
        /// Delete Task Schedul
        /// </summary>
        /// <param name="task">obj</param>
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

        /// <summary>
        /// Modify Task Schedule
        /// </summary>
        /// <param name="task">obj</param>
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

        /// <summary>
        /// Serialze obj to Json
        /// </summary>
        /// <param name="task">obj</param>
        /// <returns></returns>
        public static string ToJson(this Task task) => JsonConvert.SerializeObject(task, Task_Planing.Class.Converter.Settings);
        #endregion
    }

    internal static class Converter
    {
        #region Method Region
        /// <summary>
        /// Serialize Setting
        /// </summary>
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            DateFormatString = "MM/dd/yyyy HH:mm",
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            Formatting = Formatting.Indented
        };
        #endregion
    }
}
