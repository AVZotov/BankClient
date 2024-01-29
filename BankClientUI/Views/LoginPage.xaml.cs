namespace BankClientUI.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel loginViewModel)
	{
        InitializeComponent();
		BindingContext = loginViewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

//#if WINDOWS
//        this.Window.MaximumWidth = 400;
//        this.Window.MaximumHeight = 600;
//        this.Window.MinimumHeight = 600;
//        this.Window.MinimumWidth = 400;
//#endif
    }
}