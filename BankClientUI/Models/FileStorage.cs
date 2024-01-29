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

                return clients;
            }

            throw new FileNotFoundException();
        }

        public void SaveClients(List<Client> clients)
        {
            throw new NotImplementedException();
        }
    }
}
