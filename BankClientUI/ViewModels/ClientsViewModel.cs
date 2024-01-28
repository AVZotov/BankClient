namespace BankClientUI.ViewModels
{
    //[QueryProperty(nameof(Worker), nameof(Worker))] to pass Interface instead of Class as Navigation parameter from LoginViewModel to this the possible soulution is to use IQuerryAttributable 
    public partial class ClientsViewModel : BaseViewModel, IQueryAttributable
    {
        public ObservableCollection<Client> clients;

        [ObservableProperty]
        private IWorker? worker;

        private readonly IStorage storage;

        public ClientsViewModel(IStorage storage)
        {
            clients = new ObservableCollection<Client>();
            this.storage = storage;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Worker = (IWorker)query[nameof(Worker)];
        }
    }
}
