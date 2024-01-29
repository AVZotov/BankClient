namespace BankClientUI.ViewModels
{
    //[QueryProperty(nameof(Worker), nameof(Worker))] to pass Interface instead of Class as Navigation parameter from LoginViewModel to this the possible soulution is to use IQuerryAttributable 
    
    public partial class ClientsViewModel : BaseViewModel, IQueryAttributable
    {
        public ObservableCollection<ClientDetailsViewModel>? Clients { get; set; }

        [ObservableProperty]
        private IWorker worker;

        private readonly IStorage storage;

        public ClientsViewModel(IStorage storage)
        {
            Clients = new();
            this.storage = storage;
            Title = "Clients List";
        }

        public void GetClients()
        {
            List<Client> list = new List<Client>();

            list = storage.GetClients();

            foreach (Client client in list)
            {
                Clients.Add(new ClientDetailsViewModel(client, worker));
            }

        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Worker = (IWorker)query[nameof(Worker)];
        }
    }
}
