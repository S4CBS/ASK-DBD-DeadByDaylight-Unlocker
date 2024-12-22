using Fiddler;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ASK;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Security;

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
        // Client
        public static string Accept = string.Empty;
        public static string Accept_Encoding = string.Empty;
        public static string userAgent = string.Empty;
        // Cookies
        public static string Cookie = string.Empty;
        // Entity
        public static string Content_Length = string.Empty;
        public static string Content_Type = string.Empty;
        // Misc
        public static string api_key = string.Empty;
        public static string x_kraken_analytics_session_id = string.Empty;
        public static string x_kraken_client_os = string.Empty;
        public static string x_kraken_client_platform = string.Empty;
        public static string x_kraken_client_provider = string.Empty;
        public static string x_kraken_client_resolution = string.Empty;
        public static string x_kraken_client_timezone_offset = string.Empty;
        public static string x_kraken_client_version = string.Empty;
        // match_id
        public static string match_id = string.Empty;
        private static HashSet<string> ProcessedMatches = new HashSet<string>();
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
        async static Task DwnloadSettings()
        {
            var downloadTasks = new List<Task>
            {
                DwnloadBytes(BaseDir + "Profile.json", Path.Combine(ProfilePath, "Profile.json")),
                DwnloadBytes(BaseDir + "Bloodweb.json", Path.Combine(ProfilePath, "Bloodweb.json")),
                DwnloadBytes(BaseDir + "SkinsWithItems.json", Path.Combine(ProfilePath, "SkinsWithItems.json")),
                DwnloadBytes(BaseDir + "DlcOnly.json", Path.Combine(ProfilePath, "DlcOnly.json")),
                DwnloadBytes(BaseDir + "SkinsPerks.json", Path.Combine(ProfilePath, "SkinsPerks.json")),
                DwnloadBytes(BaseDir + "SkinsONLY.json", Path.Combine(ProfilePath, "SkinsONLY.json")),
                DwnloadBytes(BaseDir + "Level.json", Path.Combine(ProfilePath, "Level.json")),
                DwnloadBytes(BaseDir + "Currency.json", Path.Combine(ProfilePath, "Currency.json")),
                DwnloadBytes(BaseDir + "AutoUpdate.json", Path.Combine(ProfilePath, "AutoUpdate.json")),
                DwnloadBytes(BaseDir + "changeName.json", Path.Combine(ProfilePath, "changeName.json")),
                DwnloadBytes(BaseDir + "auscpt.exe", Path.Combine(ProfilePath, "auscpt.exe"))
            };

            await Task.WhenAll(downloadTasks);
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

        static async Task UpdateInventory()
        {
            foreach (string file in InventoryFiles)
            {
                if (File.Exists(file))
                {
                    string JSON = await File.ReadAllTextAsync(file);
                    var SettingsObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(JSON);

                    if (SettingsObj != null && SettingsObj.TryGetValue("data", out var dataObj) && dataObj is JObject data)
                    {
                        if (data.TryGetValue("inventory", out var inventoryToken) && inventoryToken is JArray inventoryArray)
                        {
                            var inventory = inventoryArray.ToObject<List<object>>();
                            if (inventory != null)
                            {
                                inventory = ShuffleList(inventory);
                                data["inventory"] = JArray.FromObject(inventory);
                            }
                        }
                    }

                    string FinalJson = JsonConvert.SerializeObject(SettingsObj, Formatting.Indented);
                    await File.WriteAllTextAsync(file, FinalJson);
                }
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
                AttachConsole();
                Console.Title = "Debuging";
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
            if (oSession.uriContains("/api/v1/config"))
            {
                if (oSession != null)
                {
                    Accept = oSession.oRequest["Accept"];
                    Accept_Encoding = oSession.oRequest["Accept-Encoding"];
                    userAgent = oSession.oRequest["User-Agent"];
                    Cookie = oSession.oRequest["Cookie"];
                    Content_Length = oSession.oRequest["Content-Length"];
                    Content_Type = oSession.oRequest["Content-Type"];
                    api_key = oSession.oRequest["api-key"];
                    x_kraken_analytics_session_id = oSession.oRequest["x-kraken-analytics-session-id"];
                    x_kraken_client_os = oSession.oRequest["x-kraken-client-os"];
                    x_kraken_client_platform = oSession.oRequest["x-kraken-client-platform"];
                    x_kraken_client_provider = oSession.oRequest["x-kraken-client-provider"];
                    x_kraken_client_resolution = oSession.oRequest["x-kraken-client-resolution"];
                    x_kraken_client_timezone_offset = oSession.oRequest["x-kraken-client-timezone-offset"];
                    x_kraken_client_version = oSession.oRequest["x-kraken-client-version"];
                }
            }
        }

        static async Task GetProfilesInfo(string id)
        {
            string url = $"https://egs.live.bhvrdbd.com/api/v1/playername/byId/{id}";

            var client = new HttpClient();

            // Создание объекта HttpRequestMessage
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            request.Headers.Add("Accept", Accept);
            request.Headers.Add("Accept-Encoding", Accept_Encoding);

            request.Headers.Add("Cookie", Cookie);
            request.Headers.Add("x-kraken-analytics-session-id", x_kraken_analytics_session_id);

            request.Headers.Add("x-kraken-client-os", x_kraken_client_os);
            request.Headers.Add("x-kraken-client-platform", x_kraken_client_platform);
            request.Headers.Add("x-kraken-client-provider", x_kraken_client_provider);
            request.Headers.Add("x-kraken-client-resolution", x_kraken_client_resolution);
            request.Headers.Add("x-kraken-client-timezone-offset", x_kraken_client_timezone_offset);
            request.Headers.Add("x-kraken-client-version", x_kraken_client_version);

            request.Headers.Add("api-key", api_key);
            request.Headers.Add("User-Agent", userAgent);

            // Отключение проверки SSL-сертификатов
            var handler = new HttpClientHandler()
            {
                // Отключение проверки сертификатов
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            var httpClient = new HttpClient(handler);

            try
            {
                var response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();  // Проверка на успешный ответ

                string responseBody = await response.Content.ReadAsStringAsync();
                JObject json = JsonConvert.DeserializeObject<JObject>(responseBody);

                string json_ = json["providerPlayerNames"].ToString();
                JObject JSON = JObject.Parse(json_);
                foreach (var propety in JSON)
                {
                    Log($"Платформа: {propety.Key}, Ник: {propety.Value}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
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
                        Form1.label6.Text = "МАТЧ СОЗДАН!";
                        match_id = JSON["matchData"]["matchId"].ToString();
                    }
                }
            }
            if (oSession.uriContains("api/v1/queue/cancel"))
            {
                Form1.label6.Text = "Очередь: xxx";
            }
            if (oSession.uriContains($"api/v1/match/{match_id}"))
            {
                var odin = false;
                var dva = false;
                if (!ProcessedMatches.Contains(match_id))
                {
                    oSession.utilDecodeResponse();
                    string responseBody = oSession.GetResponseBodyAsString();
                    JObject JSON = JsonConvert.DeserializeObject<JObject>(responseBody);

                    // Проверяем sideA
                    var sideAArray = JSON["sideA"]?.ToObject<List<string>>();
                    if (sideAArray != null && sideAArray.Count == 1)
                    {
                        odin = true;
                        string sideA = sideAArray[0];
                        GetProfilesInfo(sideA);
                    }
                    else
                    {
                    }

                    // Проверяем sideB
                    var sideB = JSON["sideB"]?.ToObject<List<string>>();
                    if (sideB != null && sideB.Count == 4)
                    {
                        dva = true;
                        Console.WriteLine("SideB:");
                        foreach (string id in sideB)
                        {
                            GetProfilesInfo(id);
                        }
                    }
                    else
                    {
                    }
                    if (odin == true & dva == true)
                    {
                        ProcessedMatches.Add(match_id);
                    }
                }
            }
        }

        async static Task DwnloadBytes(string url, string output)
        {
            try
            {
                byte[] fileBytes = await WC.GetByteArrayAsync(url);
                await File.WriteAllBytesAsync(output, fileBytes);
            }
            catch (Exception ex)
            {
            }
        }
    }
}