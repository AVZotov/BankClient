namespace BankClientUI.ViewModels
{
    [QueryProperty(nameof(Selection), nameof(Selection))]
    public partial class ClientsViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string selection;
    }
}
