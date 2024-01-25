using CommunityToolkit.Mvvm.Input;

namespace BankClientUI.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string? selection;

        [RelayCommand]
        private void Login()
        {
            if (string.IsNullOrWhiteSpace(Selection)) return;

            if (Selection.Equals("Manager"))
            {
                Shell.Current.DisplayAlert("Navigation", "Login as manager", "OK");
            }

            if (Selection.Equals("Worker"))
            {
                Shell.Current.DisplayAlert("Navigation", "Login as worker", "OK");
            }
        }
    }
}
