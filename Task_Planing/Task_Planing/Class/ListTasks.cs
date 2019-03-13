using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Planing.Interfaces;

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
                throw;
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
        public static ListTasks FromJson(string json) => JsonConvert.DeserializeObject<ListTasks>(json, Task_Planing.Class.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ListTasks self) => JsonConvert.SerializeObject(self, Task_Planing.Class.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
