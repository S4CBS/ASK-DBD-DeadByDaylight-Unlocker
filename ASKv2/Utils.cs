using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ASKv2
{
    internal class Utils
    {
        private static string ProfilePath = Path.Combine(Program.ProfilePath, "Bloodweb.json");
        private static string ProfilePath2 = Path.Combine(Program.ProfilePath, "Profile.json");
        public static void updatePrestigeLvL(string lvl)
        {
            int level = int.Parse(lvl);
            // Обновление Bloodweb.json
            if (Directory.Exists(Program.ProfilePathASK))
            {
                string JSON = File.ReadAllText(ProfilePath);
                var SettingsObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(JSON);

                if (SettingsObj.ContainsKey("prestigeLevel"))
                {
                    SettingsObj["prestigeLevel"] = level;
                }

                string FinalJson = JsonConvert.SerializeObject(SettingsObj, Formatting.Indented);
                File.WriteAllText(ProfilePath, FinalJson);
            } else
            {
                MessageBox.Show("Файл не найден.", "Изменение престижа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Form1.signal = true;
            }
            // Обновление Profile.json
            if (Directory.Exists(Program.ProfilePathASK))
            {
                string JSON = File.ReadAllText(ProfilePath2);
                var SettingsObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(JSON);

                if (SettingsObj.ContainsKey("list"))
                {
                    var listArray = SettingsObj["list"] as JArray;

                    if (listArray != null)
                    {
                        foreach ( var item in listArray )
                        {
                            if (item["prestigeLevel"] != null)
                            {
                                item["prestigeLevel"] = level;
                            }
                        }
                    }
                }

                string FinalJson = JsonConvert.SerializeObject(SettingsObj, Formatting.Indented);
                File.WriteAllText(ProfilePath2, FinalJson);
            }
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
        public static string ReturnProfile()
        {
            string JSON = File.ReadAllText(Program.CfgProfilePath);
            var SettingsObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(JSON);

            if (SettingsObj != null && SettingsObj.ContainsKey("profile"))
            {
                return SettingsObj["profile"].ToString();
            }
            return "";
        }
        public static void SetProfile(string profile)
        {
            string JSON = File.ReadAllText(Program.CfgProfilePath);
            var SettingsObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(JSON);

            if (SettingsObj != null && SettingsObj.ContainsKey("profile"))
            {
                SettingsObj["profile"] = profile;
            }
            string FinalJson = JsonConvert.SerializeObject(SettingsObj);
            File.WriteAllText(Program.CfgProfilePath, FinalJson);
        }
        internal static string ReturnPlatform()
        {
            string JSON = File.ReadAllText(Program.CfgProfilePath);
            var SettingsObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(JSON);

            if (SettingsObj != null && SettingsObj.ContainsKey("platform"))
            {
                return SettingsObj["platform"].ToString();
            }
            return "";
        }
        public static void SetPlatform(string platform)
        {
            string JSON = File.ReadAllText(Program.CfgProfilePath);
            var SettingsObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(JSON);

            if (SettingsObj != null && SettingsObj.ContainsKey("platform"))
            {
                SettingsObj["platform"] = platform;
            }

            string FinalJson = JsonConvert.SerializeObject(SettingsObj);
            File.WriteAllText(Program.CfgProfilePath, FinalJson);
        }

        public static string ReturnName()
        {
            string JSON = File.ReadAllText(Program.CfgProfilePath);
            var SettingsObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(JSON);

            if (SettingsObj != null && SettingsObj.ContainsKey("nicknamehack"))
            {
                return SettingsObj["nicknamehack"].ToString();
            }
            return "";
        }

        public static void SetName_(string username)
        {
            string JSON = File.ReadAllText(Program.CfgProfilePath);
            var SettingsObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(JSON);

            if (SettingsObj != null && SettingsObj.ContainsKey("nicknamehack"))
            {
                SettingsObj["nicknamehack"] = username;
            }

            string FinalJson = JsonConvert.SerializeObject(SettingsObj);
            File.WriteAllText(Program.CfgProfilePath, FinalJson);
        }

        public static void AutoSetName(string id, string name, string lang)
        {
            string json = File.ReadAllText(Path.Combine(Program.ProfilePath, "changeName.json"));
            JArray jsonArray = JsonConvert.DeserializeObject<JArray>(json);
            
            foreach (var item in jsonArray)
            {
                item["accountId"] = id;
                item["displayName"] = name;
                item["preferredLanguage"] = lang;
                break;
            }
            string updateJson = JsonConvert.SerializeObject(jsonArray, Formatting.None);
            File.WriteAllText(Path.Combine(Program.ProfilePath, "changeName.json"), updateJson);
        }

        public static void SetName(string name)
        {
            string json = File.ReadAllText(Path.Combine(Program.ProfilePath, "changeName.json"));
            JArray jsonArray = JsonConvert.DeserializeObject<JArray>(json);

            foreach (var item in jsonArray)
            {
                item["displayName"] = name;
                break;
            }
            string updateJson = JsonConvert.SerializeObject(jsonArray, Formatting.None);
            File.WriteAllText(Path.Combine(Program.ProfilePath, "changeName.json"), updateJson);
        }

        public static void Logging(string log)
        {
            Form1.Logs.Items.Add(log);
        }
    }
}
