using System;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    static async Task Main(string[] args)
    {
        var url = "https://egs.live.bhvrdbd.com/api/v1/playername/byId/968a6473-01c3-407b-b1b2-d7dac8299119/crossplatform?platform=egs";

        var client = new HttpClient();

        // Создание объекта HttpRequestMessage
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        // Добавление заголовков запроса
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("Accept-Encoding", "deflate, gzip");
        request.Headers.Add("Cookie", "bhvrSession=qMoorQ7Z_ijyETNLqmFv8A.kdAEPn05SB2qBpY7-1x3fX6nuP1fomn3HvDOVbi7NlZoC9P4Cx8nMd8pZBNRnV-so8Hni1H0dkjdv4_7VI2-NCsT6TWu1yLln1BYMflvOmgZG5LCI8YM-diQPG09Yio-ABJsPYYCw7TTZU0KPwiZtLn0CbeuvOs4cYYcbd--B-Mel3DaO9eVcT45pyKOl-fy7h3RY9qtktAm_GkQsd6Z3Z_RZ-yUqXLMBHPaoA5z4FrzcMAS1rDJ3xOmqohNwSZrD7E-055iesHJvFmEvPR27A.1734865836835.86400000.AJzVx67vdhf3BAzETs_s9wGUvH51pPKOyhuRoirZKo4");

        request.Headers.Add("x-kraken-analytics-session-id", "051289b5-4bad-7571-cb6f-c8ac77641b0b");
        request.Headers.Add("x-kraken-client-platform", "egs");
        request.Headers.Add("x-kraken-client-provider", "egs");
        request.Headers.Add("x-kraken-client-resolution", "1920x1080");
        request.Headers.Add("x-kraken-client-timezone-offset", "-180");
        request.Headers.Add("x-kraken-client-os", "10.0.26100.1.256.64bit");
        request.Headers.Add("x-kraken-client-version", "8.4.2");

        request.Headers.Add("api-key", "58d7aac1-b824-4aa8-93e0-6190375aec0b");
        request.Headers.Add("User-Agent", "DeadByDaylight/DBD_Gelato_HF2_EGS_Shipping_6_2203069 EGS/10.0.26100.1.256.64bit");

        // Отключение проверки SSL-сертификатов
        var handler = new HttpClientHandler()
        {
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
                Console.WriteLine(propety.Key);
                Console.WriteLine(propety.Value);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
