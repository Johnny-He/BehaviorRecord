using System.Collections.Generic;
using System.IO;
using System.Linq;
using BehaviorRecorder.Models;
using Newtonsoft.Json;

namespace BehaviorRecorder.Repositories
{
    public class BehaviorRecorderRepository
    {
        private static readonly List<BehaviorRecord> BehaviorRecords;
        private static string _path;

        static BehaviorRecorderRepository()
        {
            _path = "../../../BehaviorRecords.json";
            BehaviorRecords = Init();
        }
        
        private static List<BehaviorRecord> Init()
        {
            var readAllText = File.ReadAllText(_path);
            if (string.IsNullOrEmpty(readAllText))
            {
                return new List<BehaviorRecord>();
            }
            return JsonConvert.DeserializeObject<List<BehaviorRecord>>(readAllText);
        }

        public void SaveRecord(BehaviorRecord record)
        {
            BehaviorRecords.Add(record);
            _path = $"../../../BehaviorRecords.json";
            File.WriteAllText(_path, JsonConvert.SerializeObject(BehaviorRecords,Formatting.Indented));
        }

        public IEnumerable<BehaviorRecord> GetAllRecord()
        {
            
            return BehaviorRecords;
        }

        public BehaviorRecord GetRecordByName(string recordName)
        {
            return BehaviorRecords.First(record => record.Name == recordName);
        }

        public void DeleteRecord(string recordName)
        {
            var behaviorRecord = BehaviorRecords.First(record => record.Name ==  recordName);
            BehaviorRecords.Remove(behaviorRecord);
        }
    }
}