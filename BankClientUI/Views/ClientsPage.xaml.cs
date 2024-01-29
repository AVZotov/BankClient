namespace BankClientUI.Views;

public partial class ClientsPage : ContentPage
{
    private readonly ClientsViewModel clientsViewModel;

    public ClientsPage(ClientsViewModel clientsViewModel)
	{
		InitializeComponent();

		BindingContext = clientsViewModel;
        this.clientsViewModel = clientsViewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        clientsViewModel.GetClients();
    }
}