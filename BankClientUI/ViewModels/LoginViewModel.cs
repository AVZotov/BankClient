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

            IWorker worker = (Selection == "manager")? new Manager() : new Worker();

            Shell.Current.GoToAsync(nameof(ClientsPage), true, new Dictionary<string, object>
            {
                [nameof(Worker)] = worker
            });
        }
    }
}
