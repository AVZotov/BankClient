namespace BankClientUI.Views;

public partial class AddClientPage : ContentPage
{
	public AddClientPage(AddClientViewModel addClientViewModel)
	{
		InitializeComponent();

		BindingContext = addClientViewModel;
	}
}