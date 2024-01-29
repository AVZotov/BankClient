namespace BankClientUI.ViewModels
{
    //[QueryProperty(nameof(Worker), nameof(Worker))] to pass Interface instead of Class as Navigation parameter from LoginViewModel to this the possible soulution is to use IQuerryAttributable 
    
    public partial class ClientsViewModel : BaseViewModel, IQueryAttributable
    {
        public ObservableCollection<ClientDetailsViewModel>? Clients { get; set; }
        public bool CanAdd => IsManager();
        public bool CanDelete => IsManager();
        [ObservableProperty]
        private ClientDetailsViewModel? selectedClient = null;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(CanAdd))]
        [NotifyPropertyChangedFor(nameof(CanDelete))]
        private IWorker? worker;
        private readonly IStorage storage;

        public ClientsViewModel(IStorage storage)
        {
            Clients = new();
            this.storage = storage;
            Title = "Clients List";
        }

        [RelayCommand]
        private void ShowDetails(ClientDetailsViewModel clientDetailsViewModel)
        {
                SelectedClient = clientDetailsViewModel;
        }

        public void GetClients()
        {
            List<Client> list = storage.GetClients();

            foreach (Client client in list)
            {
                Clients.Add(new ClientDetailsViewModel(client, worker));
            }
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Worker = (IWorker)query[nameof(Worker)];
        }

        private bool IsManager()
        {
            if (Worker == null || Worker.GetAccess().Equals("worker")) return false;

            return true;
        }
    }
}
