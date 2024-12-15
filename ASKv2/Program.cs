using Fiddler;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ASK;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ASKv2
{
    internal static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();

        public static string MyPlayerId = string.Empty;
        public static string LocalAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static string ProfilePathASK = Path.Combine(LocalAppData, "ASK");
        public static string ProfilePath = Path.Combine(ProfilePathASK, "Configs");
        public static string CfgProfilePath = Path.Combine(ProfilePathASK, "Config.json");
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
            await DwnloadBytes(BaseDir + "Level.json", Path.Combine(ProfilePath, "Level.json"));
            await DwnloadBytes(BaseDir + "Currency.json", Path.Combine(ProfilePath, "Currency.json"));
            await DwnloadBytes(BaseDir + "AutoUpdate.json", Path.Combine(ProfilePath, "AutoUpdate.json"));
            await DwnloadBytes(BaseDir + "changeName.json", Path.Combine(ProfilePath, "changeName.json"));
            // auscpt.exe
            await DwnloadBytes(BaseDir + "auscpt.exe", Path.Combine(ProfilePath, "auscpt.exe"));

            UpdateInventory();
        }
        public static void AttachConsole()
        {
            AllocConsole(); // Создаёт новое консольное окно
            Console.WriteLine("Консоль подключена!");
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

        public static void CreateDirsAndFiles()
        {
            // Проверка на наличие конфигураций
            if (!Directory.Exists(ProfilePathASK))
            {
                Directory.CreateDirectory(ProfilePathASK);
            }
            if (!Directory.Exists(ProfilePath))
            {
                Directory.CreateDirectory(ProfilePath);
            }

            foreach (string filepath in InventoryFiles)
            {
                if (!File.Exists(filepath))
                {
                    DwnloadSettings();
                }
            }

            if (!File.Exists(CfgProfilePath))
            {
                var jsonData = new Dictionary<string, object>() {
                    { "profile", "SkinsWithItems.json" }, {"platform", "EGS"}, {"nicknamehack", "xxx"}
                };
                string jsonContent = JsonConvert.SerializeObject(jsonData, Formatting.Indented);
                File.WriteAllText(CfgProfilePath, jsonContent);
            }
            Form1.Logs.Items.Add("Файлы конфигураций подгружены.");
        }

        public static void Start(bool IsRunning)
        {
            CONFIG.IgnoreServerCertErrors = true;
            CONFIG.EnableIPv6 = true;

            var settings = new FiddlerCoreStartupSettingsBuilder()
                .ListenOnPort((ushort)8888)
                .DecryptSSL()
                .RegisterAsSystemProxy()
                .Build();

            if (IsRunning)
            {
                // AttachConsole();
                // Console.Title = "Debuging";
                FidlerCore.EnsureRootCertGrabber();
                FiddlerApplication.Startup(settings);

                LauchProfileEditor();
                ReturnStartSignal(IsRunning);
                Launcher.LaunchDBD(Form1.platform);
            } else if (!IsRunning)
            {
                FiddlerApplication.Shutdown();
                Launcher.KillDBD(Form1.platform);
                FidlerCore.RemoveRootCert();
                ReturnStartSignal(!IsRunning);
            }
        }

        public static void StartUpdate(bool isRunning)
        {
            CONFIG.IgnoreServerCertErrors = true;
            CONFIG.EnableIPv6 = true;

            var settings = new FiddlerCoreStartupSettingsBuilder()
                .ListenOnPort((ushort)8888)
                .DecryptSSL()
                .RegisterAsSystemProxy()
                .Build();

            if (isRunning)
            {
                FidlerCore.EnsureRootCertGrabber();
                FiddlerApplication.Startup(settings);

                LaunchUpdateProfiles();
                ReturnStartSignal(isRunning);
                Launcher.LaunchDBD(Form1.platform);
            }
            else if (!isRunning)
            {
                FiddlerApplication.Shutdown();
                Launcher.KillDBD(Form1.platform);
                FidlerCore.RemoveRootCert();
                ReturnStartSignal(!isRunning); 
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

        private static void Log(string log)
        {
            Utils.Logging(log);
        }

        static void LauchProfileEditor()
        {
            FiddlerApplication.BeforeRequest -= LaucnhedWithProfileEditor;
            FiddlerApplication.BeforeRequest += LaucnhedWithProfileEditor;
            FiddlerApplication.BeforeResponse += OnBeforeResponse;
        }

        static void LaunchUpdateProfiles()
        {
            FiddlerApplication.BeforeResponse += OnUpdateProfiles;
        }

        static void ProfileEditor(Session oSession)
        {
            if (Form1.Profile == "SkinsWithItems.json")
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
                    oSession.oFlags["x-replywithfile"] = Path.Combine(ProfilePath, Form1.Profile);
                }
            }
            else 
            {
                if (oSession.uriContains("/api/v1/inventories"))
                {
                    oSession.oFlags["x-replywithfile"] = Path.Combine(ProfilePath, Form1.Profile);
                }
            }

            // Валюта - Currency.json
            if (oSession.uriContains("api/v1/wallet/currencies") && Form1.checkBox2.Checked)
            {
                oSession.oFlags["x-replywithfile"] = Path.Combine(ProfilePath, "Currency.json");
            }
            // Level.json
            if ((oSession.uriContains("api/v1/extensions/playerLevels/getPlayerLevel") || oSession.uriContains("api/v1/extensions/playerLevels/earnPlayerXp")) && Form1.checkBox1.Checked)
            {
                oSession.oFlags["x-replywithfile"] = Path.Combine (ProfilePath, "Level.json");
            }
            // Подмена ника - epic/id/v2/sdk/accounts
            if (oSession.uriContains("epic/id/v2/sdk/accounts") && Form1.checkBox3.Checked)
            {
                oSession.oFlags["x-replywithfile"] = Path.Combine(ProfilePath, "changeName.json");
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

        private static void OnUpdateProfiles(Session oSession)
        {
            if (oSession.uriContains("v1/extensions/store/getCatalogItems"))
            {
                oSession.utilDecodeResponse();
                string responseBody = oSession.GetResponseBodyAsString();
                var jsonformat = JsonConvert.DeserializeObject(responseBody);
                File.WriteAllText(Path.Combine(ProfilePath, "AutoUpdate.json"), JsonConvert.SerializeObject(jsonformat, Formatting.Indented));

                ProcessStartInfo startInfo = new ProcessStartInfo(Path.Combine(ProfilePath, "auscpt.exe"))
                {
                    UseShellExecute = true,
                    Verb = "runas"
                };
                Process.Start(startInfo);
                StartUpdate(false);
            }
        }

        private static void OnBeforeResponse(Session oSession)
        {
            string accountId = string.Empty;
            string displayName = string.Empty;
            string preferredLanguage = string.Empty;

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
            if (oSession.uriContains("epic/oauth/v2/token"))
            {
                oSession.utilDecodeResponse();
                string responseBody = oSession.GetResponseBodyAsString();
                JObject JSON = JsonConvert.DeserializeObject<JObject>(responseBody);

                if (JSON != null && JSON.ContainsKey("account_id"))
                {
                    accountId = JSON["account_id"].ToString();
                    preferredLanguage = "en";
                    displayName = Form1.playerName;
                }
                Utils.AutoSetName(accountId, displayName, preferredLanguage);
            }
            if (oSession.uriContains("api/v1/queue"))
            {
                oSession.utilDecodeResponse();
                string responseBody = oSession.GetResponseBodyAsString();
                JObject JSON = JsonConvert.DeserializeObject<JObject>(responseBody);
                if (JSON != null)
                {
                    if (JSON["status"].ToString() == "QUEUED")
                    {
                        Form1.label6.Text = $"Ваша позиция: {JSON["queueData"]["position"].ToString()}";
                    }
                    if (JSON["status"].ToString() == "MATCHED")
                    {
                            Form1.label6.Text = "МАТЧ НАЙДЕН!";
                    }
                }
            }
            if (oSession.uriContains("api/v1/queue/cancel"))
            {
                Form1.label6.Text = "Очередь: xxx";
            }
        }

        async static Task DwnloadBytes(string url, string output)
        {
            byte[] fileBytes = await WC.GetByteArrayAsync(url);
            File.WriteAllBytes(output, fileBytes);
        }
    }
}