namespace BankClientUI.ViewModels
{
    public partial class ClientsViewModel : BaseViewModel, IQueryAttributable
    {
        public ObservableCollection<ClientDetailsViewModel> Clients { get; set; }

        [ObservableProperty]
        private bool isFullAccess;

        [ObservableProperty]
        private bool isPassportBlocked;

        [ObservableProperty]
        private bool canDelete;

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

        [RelayCommand]
        private void EditClient()
        {
            if (SelectedClient != null)
            {
                
                Shell.Current.GoToAsync($"{nameof(EditClientPage)}?IsPassportBlocked={IsPassportBlocked}", new Dictionary<string, object>
                {
                    [nameof(ClientDetailsViewModel)] = SelectedClient.ShallowCopy()
                });
            }
        }

        [RelayCommand]
        private void AddNewClient()
        {
            Shell.Current.GoToAsync(nameof(AddClientPage));
        }

        [RelayCommand]
        private void DeleteClient() 
        {
            if (SelectedClient is not null)
            {
                Clients.Remove(SelectedClient);
                SelectedClient = null;
            }
        }

        [RelayCommand]
        private void SaveToFile()
        {
            List<Client> clients = [];

            foreach (var client in Clients)
            {
                clients.Add(client.GetClientModel());
            }

            storage.SaveClients(clients);
        }

        public void GetClients()
        {
            List<Client> clientsList = storage.GetClients();

            if (clientsList is null) { return; }

            if (Worker is null) { return; }

            foreach (Client client in clientsList)
            {
                Clients.Add(new ClientDetailsViewModel(client));
            }
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.Count == 0)
            {
                return;
            }

            if (query.TryGetValue(nameof(Worker), out object? value))
            {
                Worker = (IWorker)value;
                IsFullAccess = IsManager();
                IsPassportBlocked = !IsFullAccess;
            }

            if (query.TryGetValue("updatedClientDetails", out object? incomingClientDetails))
            {
                if (incomingClientDetails is not null)
                {
                    UpdateClientDetails(incomingClientDetails);
                }
            }

            if (query.TryGetValue("newClient", out object? newClientDetails))
            {
                if (newClientDetails is not null)
                {
                    Clients.Add((ClientDetailsViewModel)newClientDetails);
                    SelectedClient = (ClientDetailsViewModel)newClientDetails;
                }
            }

            query.Clear();
        }

        private bool IsManager()
        {
            return Worker != null && !Worker.GetAccess().Equals("worker");
        }

        private void UpdateClientDetails(object incomingClientDetails)
        {
            if (incomingClientDetails is not ClientDetailsViewModel clientDetais || SelectedClient is null) { return; }

            if (!string.IsNullOrEmpty(clientDetais.FirstName)) { SelectedClient.FirstName = clientDetais.FirstName; }
            
            if (!string.IsNullOrEmpty(clientDetais.FirstName)) { SelectedClient.SecondName = clientDetais.SecondName; }
            
            if (!string.IsNullOrEmpty(clientDetais.FirstName)) { SelectedClient.LastName = clientDetais.LastName; }
            
            if (!string.IsNullOrEmpty(clientDetais.FirstName)) { SelectedClient.Phone = clientDetais.Phone; }
            
            if (!string.IsNullOrEmpty(clientDetais.FirstName)) { SelectedClient.Passport = clientDetais.Passport; }
            
            if (!string.IsNullOrEmpty(clientDetais.FirstName)) { SelectedClient.Created = clientDetais.Created; }
            
            if (!string.IsNullOrEmpty(clientDetais.FirstName)) { SelectedClient.CreatedBy = clientDetais.CreatedBy; }

            SelectedClient.Updated = clientDetais.Updated;
            SelectedClient.UpdatedBy = clientDetais.UpdatedBy;
        }
    }
}
