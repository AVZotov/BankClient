namespace BankClientUI.Views;

public partial class ClientsPage : ContentPage
{
	public ClientsPage(ClientsViewModel clientsViewModel)
	{
		InitializeComponent();

		BindingContext = clientsViewModel;
	}
}