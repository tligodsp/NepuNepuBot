using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace NepuBot
{
    class Utilities
    {
        private static Dictionary<string, string> alerts;
        private static Dictionary<string, string[]> database;

        static Utilities()
        {
            string json = File.ReadAllText("SystemLang/alerts.json");
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            alerts = data.ToObject<Dictionary<string, string>>();

            string jsondb = File.ReadAllText("SystemLang/database.json");
            var db = JsonConvert.DeserializeObject<dynamic>(jsondb);
            database = db.ToObject<Dictionary<string, string[]>>();
        }

        public static string GetAlert(string key)
        {
            if (alerts.ContainsKey(key)) return alerts[key];
            return "";
        }

        public static string GetFormattedAlert(string key, params object[] parameter)
        {
            if (alerts.ContainsKey(key))
            {
                return String.Format(alerts[key], parameter);
            }
            return "";
        }

        public static string GetFormattedAlert(string key, object parameter)
        {
            return GetFormattedAlert(key, new object[] { parameter });
        }

        public static string[] GetDatabse(string key)
        {
            if (database.ContainsKey(key)) return database[key];
            return new string[] { "" };
        }
    }
}
