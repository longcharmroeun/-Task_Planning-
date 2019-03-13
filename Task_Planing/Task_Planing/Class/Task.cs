using Newtonsoft.Json;
using System;

namespace Task_Planing.Class
{
    public class Task : Interfaces.ITask
    {
        [JsonProperty("TaskName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string TaskName { get; set; }
        [JsonProperty("Date_Execution", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Date_Execution { get; set; }
        [JsonProperty("Prioritize", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Prioritize Prioritize { get; set; }
    }
    public enum Prioritize
    {
        Hight,Normal,low
    }
}
