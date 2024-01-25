namespace BankClientUI.Assets
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? title;
        [ObservableProperty]
        private bool isBusy;
    }
}
