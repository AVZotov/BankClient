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

        if (this.clientsViewModel.Clients.Count > 0) { return; }

        clientsViewModel.GetClients();
    }

    private void PointerGestureRecognizer_PointerEntered(object sender, PointerEventArgs e)
    {
        ((Button)sender).Background = Color.FromArgb("#111730");
    }

    private void PointerGestureRecognizer_PointerExited(object sender, PointerEventArgs e)
    {
        ((Button)sender).Background = Color.FromArgb("#2C3C5D");
    }
}