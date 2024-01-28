
namespace BankClientUI.Models
{
    public class FileStorage : IStorage
    {
        private readonly string fileName = "Clients.json";

        public List<Client> GetClients()
        {
            //var path = FileSystem.Current.AppDataDirectory()
                throw new NotImplementedException();
        }

        public void SaveClients(List<Client> clients)
        {
            throw new NotImplementedException();
        }
    }
}
