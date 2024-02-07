namespace BankClientUI.ViewModels
{
    [QueryProperty(nameof(IsFullAccess), nameof(IsFullAccess))]
    [QueryProperty(nameof(ClientDetailsViewModel), nameof(ClientDetailsViewModel))]
    public partial class EditClientViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool isFullAccess;

        [ObservableProperty]
        private ClientDetailsViewModel? clientDetailsViewModel;
    }
}
