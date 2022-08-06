using System.Collections.Generic;
using System.IO;
using BehaviorRecorder.Models;
using Newtonsoft.Json;

namespace BehaviorRecorder.Repositories
{
    public class BehaviorRecorderRepository
    {
        private static readonly List<BehaviorRecord> _behaviorRecords = Init();
        private static string _path;

        // public BehaviorRecorderRepository()
        // {
        //     // _path = "../../../BehaviorRecords.json";
        //     _behaviorRecords = Init();
        // }
        
        private static List<BehaviorRecord> Init()
        {
            var readAllText = File.ReadAllText(_path);
            if (string.IsNullOrEmpty(readAllText))
            {
                return new List<BehaviorRecord>();
            }
            return JsonConvert.DeserializeObject<List<BehaviorRecord>>(readAllText);
        }

        public static void SaveRecord(BehaviorRecord record)
        {
            _behaviorRecords.Add(record);
            _path = $"../../../BehaviorRecords.json";
            File.WriteAllText(_path, JsonConvert.SerializeObject(_behaviorRecords,Formatting.Indented));
        }
    }
}