using Fiddler;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ASK;

namespace ASKv2
{
    internal static class Program
    {
        public static string MyPlayerId = string.Empty;
        public static string LocalAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static string ProfilePathASK = Path.Combine(LocalAppData, "ASK");
        public static string ProfilePath = Path.Combine(ProfilePathASK, "Configs");
        static SessionStateHandler LaucnhedWithProfileEditor = new SessionStateHandler(ProfileEditor);
        private static string BaseDir = "https://raw.githubusercontent.com/S4CBS/ASK-DBDUnclocker/main/Configs/";
        static HttpClient WC = new HttpClient();
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
        async static Task DwnloadSettings()
        {
            await DwnloadBytes(BaseDir + "Profile.json", Path.Combine(ProfilePath, "Profile.json"));
            await DwnloadBytes(BaseDir + "Bloodweb.json", Path.Combine(ProfilePath, "Bloodweb.json"));
            await DwnloadBytes(BaseDir + "SkinsWithItems.json", Path.Combine(ProfilePath, "SkinsWithItems.json"));
            await DwnloadBytes(BaseDir + "DlcOnly.json", Path.Combine(ProfilePath, "DlcOnly.json"));
            await DwnloadBytes(BaseDir + "SkinsPerks.json", Path.Combine(ProfilePath, "SkinsPerks.json"));
            await DwnloadBytes(BaseDir + "SkinsONLY.json", Path.Combine(ProfilePath, "SkinsONLY.json"));

            UpdateInventory();
        }

        public static List<string> InventoryFiles = new List<string>() {
            Path.Combine(ProfilePath, "SkinsWithItems.json"),
            Path.Combine(ProfilePath, "DlcOnly.json"),
            Path.Combine(ProfilePath, "SkinsPerks.json"),
            Path.Combine(ProfilePath, "SkinsONLY.json"),
        };

        static void UpdateInventory()
        {
            foreach (string file in InventoryFiles)
            {
                string JSON = File.ReadAllText(file);
                var SettingsObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(JSON);

                if (SettingsObj.ContainsKey("data"))
                {
                    JObject data = (JObject)SettingsObj["data"];

                    if (data != null && data.ContainsKey("inventory"))
                    {
                        List<object> inventory = data["inventory"].ToObject<List<object>>();
                        if (inventory != null)
                        {
                            inventory = ShuffleList(inventory);
                            data["inventory"] = JArray.FromObject(inventory);
                        }
                    }
                }

                string FinalJson = JsonConvert.SerializeObject(SettingsObj);
                File.WriteAllText(file, FinalJson);
            }
        }

        public static List<T> ShuffleList<T>(List<T> list)
        {
            Random random = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        public static void Start(bool IsRunning)
        {
            CONFIG.IgnoreServerCertErrors = true;
            CONFIG.EnableIPv6 = true;

            // Проверка на наличие конфигураций
            if (!Directory.Exists(ProfilePathASK))
            {
                Directory.CreateDirectory(ProfilePathASK);
            }
            if (!Directory.Exists(ProfilePath))
            {
                Directory.CreateDirectory(ProfilePath);
                Form1.Logs.Items.Add("Файлы конфигураций не найдены.\nНачалась загрузка...");
            }

            foreach (string filepath in InventoryFiles)
            {
                if (!File.Exists(filepath))
                {
                    DwnloadSettings();
                }
            }
            Form1.Logs.Items.Add("Файлы конфигураций подгружены.");

            var settings = new FiddlerCoreStartupSettingsBuilder()
                .ListenOnPort((ushort)8888)
                .DecryptSSL()
                .RegisterAsSystemProxy()
                .Build();

            if (IsRunning)
            {
                FidlerCore.EnsureRootCertGrabber();
                FiddlerApplication.Startup(settings);

                LauchProfileEditor();
                ReturnStartSignal(IsRunning);
            } else if (!IsRunning)
            {
                FiddlerApplication.Shutdown();
                FidlerCore.RemoveRootCert();
                ReturnStartSignal(!IsRunning);
            }
        }
        
        public static string ReturnStartSignal(bool IsRunning)
        {
            if (IsRunning)
            {
                return "Скрипт запущен, запустите игру.";
            }
            else {
                return "Скрипт выклюнен, закройте игру.";
            }
        }

        static void LauchProfileEditor()
        {
            FiddlerApplication.BeforeRequest -= LaucnhedWithProfileEditor;
            FiddlerApplication.BeforeRequest += LaucnhedWithProfileEditor;
            FiddlerApplication.BeforeResponse += OnBeforeResponse;
        }

        static void ProfileEditor(Session oSession)
        {
            if (oSession.uriContains("/api/v1/dbd-character-data/get-all"))
            {
                oSession.oFlags["x-replywithfile"] = Path.Combine(ProfilePath, "Profile.json");
            }
            if (oSession.uriContains("/api/v1/dbd-character-data/bloodweb"))
            {
                oSession.oFlags["x-replywithfile"] = Path.Combine(ProfilePath, "Bloodweb.json");
            }


            if (oSession.uriContains("/api/v1/inventories"))
            {
                oSession.oFlags["x-replywithfile"] = Path.Combine(ProfilePath, "SkinsWithItems.json");
            }
        }

        static void UpdPlayerId(string playerId)
        {
            foreach (string file in InventoryFiles)
            {
                if (File.Exists(file))
                {
                    string JSON = File.ReadAllText(file);
                    var SettingsObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(JSON);

                    if (SettingsObj != null && SettingsObj.ContainsKey("data"))
                    {
                        JObject data = (JObject)SettingsObj["data"];
                        data["playerId"] = playerId;

                        string FinalJSON = JsonConvert.SerializeObject(SettingsObj, Formatting.Indented);
                        File.WriteAllText(file, FinalJSON);
                    }
                }
                else
                {
                }
            }
        }

        private static void OnBeforeResponse(Session oSession)
        {
            if (oSession.uriContains("v1/auth/provider"))
            {
                oSession.utilDecodeResponse();
                string responseBody = oSession.GetResponseBodyAsString();

                // Преобразуем responseBody в Json и проверяем наличие "userId"
                JObject JSON = JsonConvert.DeserializeObject<JObject>(responseBody);
                if (JSON != null && JSON.ContainsKey("userId"))
                {
                    MyPlayerId = JSON["userId"].ToString();
                    UpdPlayerId(MyPlayerId);
                }
                else
                {
                }
            }
        }

        async static Task DwnloadBytes(string url, string output)
        {
            byte[] fileBytes = await WC.GetByteArrayAsync(url);
            File.WriteAllBytes(output, fileBytes);
        }
    }
}