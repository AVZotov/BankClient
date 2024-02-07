namespace BankClientUI.Views;

public partial class EditClientPage : ContentPage
{
	public EditClientPage(EditClientViewModel editClientViewModel)
	{
		InitializeComponent();

		BindingContext = editClientViewModel;
	}
}