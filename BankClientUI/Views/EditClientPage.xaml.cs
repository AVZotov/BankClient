namespace BankClientUI.Views;

public partial class EditClientPage : ContentPage
{
    public EditClientPage(EditClientViewModel editClientViewModel)
	{
		InitializeComponent();

		BindingContext = editClientViewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}