namespace BankClientUI.Assets
{
    public interface IStorage
    {
        public Task<List<Client>> GetClientsAsync();
        public Task SaveClientsAsync(List<Client> clients);
    }
}
