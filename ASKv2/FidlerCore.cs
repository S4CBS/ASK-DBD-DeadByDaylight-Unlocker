using Fiddler;
using System.Security.Cryptography.X509Certificates;

namespace ASK
{
    internal class FidlerCore
    {
        // Метод для создания и установки корневого сертификата
        public static void EnsureRootCertGrabber()
        {
            CertMaker.createRootCert(); // Создание корневого сертификата
            string str = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ASK");
            if (!Directory.Exists(str))
                Directory.CreateDirectory(str); // Создание каталога, если его нет
            string path = Path.Combine(str, "root.cer"); // Путь для сохранения сертификата
            X509Certificate2 rootCertificate = CertMaker.GetRootCertificate(); // Получение корневого сертификата
            rootCertificate.FriendlyName = "ASK"; // Название сертификата
            File.WriteAllBytes(path, rootCertificate.Export(X509ContentType.Cert)); // Сохранение сертификата на диск
            X509Store x509Store = new X509Store(StoreName.Root, StoreLocation.CurrentUser); // Открытие хранилища сертификатов
            x509Store.Open(OpenFlags.ReadWrite); // Открытие хранилища для записи
            x509Store.Add(rootCertificate); // Добавление сертификата в хранилище
            x509Store.Close(); // Закрытие хранилища
        }
        public static void RemoveRootCert()
        {
            CertMaker.removeFiddlerGeneratedCerts(true); // Удаляем сгенерированные Fiddler сертификаты
        }
    }
}
