
namespace BankClientUI.ViewModels
{
    [QueryProperty(nameof(IsPassportBlocked), nameof(IsPassportBlocked))]
    [QueryProperty(nameof(ClientDetails), nameof(ClientDetailsViewModel))]
    public partial class EditClientViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool isPassportBlocked;

        [ObservableProperty]
        private ClientDetailsViewModel? clientDetails;

        [RelayCommand]
        private void Cancel()
        {
            Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private void Save()
        {
            if (ClientDetails is null)
            {
                Cancel();
            }

            if (ClientDetails is not null)
            {
                Shell.Current.GoToAsync(nameof(ClientsPage), new Dictionary<string, object>
                {
                    ["updatedClientDetails"] = ClientDetails
                });
            }
        }
    }
}

