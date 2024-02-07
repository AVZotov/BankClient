namespace BankClientUI.ViewModels
{
    public partial class ClientsViewModel : BaseViewModel, IQueryAttributable
    {
        public ObservableCollection<ClientDetailsViewModel> Clients { get; set; }

        [ObservableProperty]
        private bool isFullAccess;

        [ObservableProperty]
        private ClientDetailsViewModel? selectedClient = null;

        [ObservableProperty]
        private IWorker? worker;

        private readonly IStorage storage;

        public ClientsViewModel(IStorage storage)
        {
            Clients = [];
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
            List<Client> clientsList = storage.GetClients();

            if (clientsList is null) { return; }

            if (Worker is null) { return; }

            foreach (Client client in clientsList)
            {
                Clients.Add(new ClientDetailsViewModel(client, Worker));
            }
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue(nameof(Worker), out _))
            {
                Worker = (IWorker)query[nameof(Worker)];
                IsFullAccess = IsManager();
            }


        }

        private bool IsManager()
        {
            return Worker != null && !Worker.GetAccess().Equals("worker");
        }
    }
}
