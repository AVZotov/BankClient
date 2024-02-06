using System.Windows.Input;

namespace BankClientUI.ViewModels
{
    //[QueryProperty(nameof(Worker), nameof(Worker))] to pass Interface instead of Class as Navigation parameter from LoginViewModel to this the possible soulution is to use IQuerryAttributable 
    
    public partial class ClientsViewModel : BaseViewModel, IQueryAttributable
    {
        public ObservableCollection<ClientDetailsViewModel> Clients { get; set; }
        public bool IsFullAccess => IsManager();

        [ObservableProperty]
        private bool isBlocked = true;

        [ObservableProperty]
        private bool isBlockedPassport = true;

        [ObservableProperty]
        private ClientDetailsViewModel? selectedClient = null;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsFullAccess))]
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
            IsBlocked = true;
            IsBlockedPassport = true;
        }

        [RelayCommand]
        private void CanEdit()
        {
            if (Worker is null) { return; }

            IsBlocked = false;
            IsBlockedPassport = !Worker.GetAccess().Equals("manager");
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
            Worker = (IWorker)query[nameof(Worker)];
        }

        private bool IsManager()
        {
            return Worker != null && !Worker.GetAccess().Equals("worker");
        }
    }
}
