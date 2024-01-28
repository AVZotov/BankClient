namespace BankClientUI.Assets
{
    public interface IStorage
    {
        public List<Client> GetClients();
        public void SaveClients(List<Client> clients);
    }
}
