namespace BankClientUI.ViewModels
{
    public partial class AddClientViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string lastName = string.Empty;
        [ObservableProperty]
        private string firstName = string.Empty;
        [ObservableProperty]
        private string secondName = string.Empty;
        [ObservableProperty]
        private string phone = string.Empty;
        [ObservableProperty]
        private string passport = string.Empty;

        [RelayCommand]
        private void SaveClient()
        {
            if (FirstName is not null && LastName is not null && Phone is not null && Passport is not null)
            {
                ClientDetailsViewModel clientDetailsViewModel = new(new Client(FirstName, SecondName, LastName, Phone, Passport, new RecordInfo("manager")));
                Shell.Current.GoToAsync(nameof(ClientsPage), new Dictionary<string, object>{
                    ["new client"] = clientDetailsViewModel
                });
            }

            Shell.Current.DisplayAlert("Error!", "Please add all the field to create new customer", "OK");
            return;
        }
    }
}
