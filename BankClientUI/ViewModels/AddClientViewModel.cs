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
            if (!string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName) && !string.IsNullOrWhiteSpace(Phone) && !string.IsNullOrWhiteSpace(Passport))
            {
                ClientDetailsViewModel clientDetailsViewModel = new(new Client(FirstName, SecondName, LastName, Phone,
                                                                               Passport, new RecordInfo("manager")));

                Shell.Current.GoToAsync(nameof(ClientsPage), new Dictionary<string, object> { 
                    ["newClient"] = clientDetailsViewModel 
                });
            }

            Shell.Current.DisplayAlert("Error!", "Please add all the field to create new customer", "OK");
        }

        [RelayCommand]
        private void Cancel() 
        {
            Shell.Current.GoToAsync("..");
        }
    }
}
