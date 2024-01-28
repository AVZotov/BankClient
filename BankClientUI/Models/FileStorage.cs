namespace BankClientUI.Models
{
    public class FileStorage : IStorage
    {
        private readonly string fileName = "Clients.json";

        public async Task<List<Client>> GetClientsAsync()
        {
            List<Client>? clients = [];

            if (FileSystem.AppPackageFileExistsAsync(fileName).Result)
            {
                using var stream = FileSystem.OpenAppPackageFileAsync(fileName);
                using var reader = new StreamReader(stream.Result);
                string json = await reader.ReadToEndAsync();
                clients = JsonConvert.DeserializeObject<List<Client>>(json);

                return clients;
            }

            throw new FileNotFoundException();
        }

        public Task SaveClientsAsync(List<Client> clients)
        {
            throw new NotImplementedException();
        }
    }
}
