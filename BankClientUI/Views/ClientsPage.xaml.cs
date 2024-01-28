namespace BankClientUI.Views;

public partial class ClientsPage : ContentPage
{
	public ClientsPage(ClientsViewModel clientsViewModel)
	{
		InitializeComponent();

		BindingContext = clientsViewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}