namespace BankClientUI.ViewModels
{
    //[QueryProperty(nameof(Worker), nameof(Worker))] to pass Interface instead of Class as Navigation parameter from LoginViewModel to this the possible soulution is to use IQuerryAttributable 
    
    public partial class ClientsViewModel : BaseViewModel, IQueryAttributable
    {
        public ObservableCollection<Client>? clients;

        [ObservableProperty]
        private IWorker? worker;

        private readonly IStorage storage;

        public ClientsViewModel(IStorage storage)
        {
            clients = new ObservableCollection<Client>();
            this.storage = storage;
        }

        [RelayCommand]
        public void GetClients()
        {
            clients?.Clear();

            var responce = storage.GetClientsAsync().Result;

            responce?.ForEach(client => clients.Add(client));

        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Worker = (IWorker)query[nameof(Worker)];
        }
    }
}
