using System.Windows.Input;

namespace BankClientUI.ViewModels
{
    //[QueryProperty(nameof(Worker), nameof(Worker))] to pass Interface instead of Class as Navigation parameter from LoginViewModel to this the possible soulution is to use IQuerryAttributable 
    
    public partial class ClientsViewModel : BaseViewModel, IQueryAttributable
    {
        public ObservableCollection<ClientDetailsViewModel>? Clients { get; set; }
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
            IsBlocked = false;
            IsBlockedPassport = (worker.GetAccess().Equals("manager")) ? false : true;
        }

        [RelayCommand]
        private void Udpate(Entry sender)
        {
            if (SelectedClient != null)
            {
                SelectedClient.LastName = sender.Text;
            }
            sender = new Entry();
            sender.Placeholder = "test";
            sender.Text = String.Empty;
            sender.IsReadOnly = true;
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
            return (Worker == null || Worker.GetAccess().Equals("worker")) ? false : true;
        }
    }
}
