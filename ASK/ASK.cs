using System;
using Fiddler;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ASK
{
    class Program
    {
        static string MyPlayerId = string.Empty;
        static string LocalAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        static string ProfilePathASK = Path.Combine(LocalAppData, "ASK");
        static string ProfilePath = Path.Combine(ProfilePathASK, "Configs");
        static SessionStateHandler LaucnhedWithProfileEditor = new SessionStateHandler(ProfileEditor);
        private static string BaseDir = "https://raw.githubusercontent.com/S4CBS/ASK-DBDUnclocker/main/Configs/";
        private HttpClient WC = new HttpClient();

        async Task DwnloadSettings()
        {
            await DwnloadBytes(BaseDir + "Profile.json", Path.Combine(ProfilePath, "Profile.json"));
            await DwnloadBytes(BaseDir + "Bloodweb.json", Path.Combine(ProfilePath, "Bloodweb.json"));
            await DwnloadBytes(BaseDir + "SkinsWithItems.json", Path.Combine(ProfilePath, "SkinsWithItems.json"));
            await DwnloadBytes(BaseDir + "DlcOnly.json", Path.Combine(ProfilePath, "DlcOnly.json"));
            await DwnloadBytes(BaseDir + "SkinsPerks.json", Path.Combine(ProfilePath, "SkinsPerks.json"));
            await DwnloadBytes(BaseDir + "SkinsONLY.json", Path.Combine(ProfilePath, "SkinsONLY.json"));

            UpdateInventory();
        }

        static List<string> InventoryFiles = new List<string>() {
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

        static List<T> ShuffleList<T>(List<T> list)
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

        static void Main(string[] args)
        {
            Console.Title = "ASK-DBD_Unlocker by S4CBS";
            CONFIG.IgnoreServerCertErrors = true;
            CONFIG.EnableIPv6 = true;

            // Проверка на наличие конфигураций
            if (!Directory.Exists(ProfilePathASK))
            {
                Directory.CreateDirectory(ProfilePathASK);
                Console.WriteLine($"Создан каталог: {ProfilePathASK}");
            }
            if (!Directory.Exists(ProfilePath))
            {
                Directory.CreateDirectory(ProfilePath);
                Console.WriteLine($"Создан каталог: {ProfilePath}");
            }

            var program = new Program();
            foreach (string filepath in InventoryFiles)
            {
                if (!File.Exists(filepath))
                {
                    Console.WriteLine($"Файл не найден: {filepath}. Начинается загрузка...");
                    program.DwnloadSettings().Wait();
                    Console.WriteLine("Все файлы загружены!");
                    break;
                }
            }

            var settings = new FiddlerCoreStartupSettingsBuilder()
                .ListenOnPort((ushort)8888)
                .DecryptSSL()
                .RegisterAsSystemProxy()
                .Build();

            FidlerCore.EnsureRootCertGrabber();
            FiddlerApplication.Startup(settings);
            Console.WriteLine("FiddlerCore запущен. Ожидание запросов...");

            LauchProfileEditor();

            Console.ReadLine();

            FiddlerApplication.Shutdown();
            FidlerCore.RemoveRootCert();
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
                Console.WriteLine("Профиль Загружен!");
            }
            if (oSession.uriContains("/api/v1/dbd-character-data/bloodweb"))
            {
                oSession.oFlags["x-replywithfile"] = Path.Combine(ProfilePath, "Bloodweb.json");
                Console.WriteLine("Кровавая паутина загружена!");
            }


            if (oSession.uriContains("/api/v1/inventories"))
            {
                oSession.oFlags["x-replywithfile"] = Path.Combine(ProfilePath, "SkinsWithItems.json");
                Console.WriteLine("Инвентарь Загружен!");
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
                        Console.WriteLine($"Обновлен файл: {file}");
                    }
                }
                else
                {
                    Console.WriteLine($"Файл не найден: {file}");
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
                    Console.WriteLine($"Получен userId: {MyPlayerId}");
                    UpdPlayerId(MyPlayerId);
                }
                else
                {
                    Console.WriteLine("Ключ 'userId' отсутствует в ответе.");
                }
            }
        }

        async Task DwnloadBytes(string url, string output)
        {
            byte[] fileBytes = await WC.GetByteArrayAsync(url);
            File.WriteAllBytes(output, fileBytes);
        }
    }
}

