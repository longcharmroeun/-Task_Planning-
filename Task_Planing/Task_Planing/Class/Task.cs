using Newtonsoft.Json;
using System;

namespace Task_Planing.Class
{
    public class Task : Interfaces.ITask
    {
        #region Property Region
        [JsonProperty("TaskName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string TaskName { get; set; }
        [JsonProperty("Date_Execution", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Date_Execution { get; set; }
        [JsonProperty("Prioritize", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Prioritize Prioritize { get; set; }
        [JsonProperty("Comment", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Comment {get;set;}
        #endregion
    }
    public enum Prioritize
    {
        Hight,Normal,low
    }
}
