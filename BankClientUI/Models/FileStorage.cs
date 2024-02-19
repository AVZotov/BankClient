using Windows.Storage;

namespace BankClientUI.Models
{
    public class FileStorage : IStorage
    {
        private readonly string fileName = "Clients.json";

        public List<Client> GetClients()
        {
            List<Client>? clients = [];

            if (FileSystem.AppPackageFileExistsAsync(fileName).Result)
            {
                using var stream = FileSystem.OpenAppPackageFileAsync(fileName);
                using var reader = new StreamReader(stream.Result);
                string json = reader.ReadToEndAsync().Result;
                clients = JsonConvert.DeserializeObject<List<Client>>(json);
                reader.Close();
            }

            return clients;
        }

        public void SaveClients(List<Client> clients)
        {
            throw new NotImplementedException();
        }

        public async Task WriteToFileAsync(string fileName, string content)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            using (StreamWriter writer = new StreamWriter(await file.OpenStreamForWriteAsync()))
            {
                await writer.WriteAsync(content);
            }
        }
    }
}
