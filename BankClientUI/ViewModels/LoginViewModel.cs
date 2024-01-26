namespace BankClientUI.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string? selection;

        [RelayCommand]
        private void Login()
        {
            if (string.IsNullOrWhiteSpace(Selection))
            {
                Shell.Current.DisplayAlert("Error!", "Please Login To proceed", "OK");
                return;
            }

            Shell.Current.GoToAsync($"{nameof(ClientsPage)}?{nameof(Selection)}={Selection}");
        }
    }
}
