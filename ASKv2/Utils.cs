using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASKv2
{
    internal class Utils
    {
        private static string ProfilePath = Path.Combine(Program.ProfilePath, "Bloodweb.json");
        public static void updatePrestigeLvL(string lvl)
        {
            string JSON = File.ReadAllText(ProfilePath);
            var SettingsObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(JSON);

            if (SettingsObj.ContainsKey("prestigeLevel"))
            {
                SettingsObj["prestigeLevel"] = lvl;
            }

            string FinalJson = JsonConvert.SerializeObject(SettingsObj);
            File.WriteAllText(ProfilePath, FinalJson);
        }
        public static string InitializeLvLPrestige()
        {
            string JSON = File.ReadAllText(ProfilePath);
            var SettingsObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(JSON);

            if (SettingsObj.ContainsKey("prestigeLevel"))
            {
                var prestigeLvL = SettingsObj["prestigeLevel"].ToString();

                if (!string.IsNullOrEmpty(prestigeLvL)) {
                    return prestigeLvL;
                }
            }
            return "0";
        }
    }
}
