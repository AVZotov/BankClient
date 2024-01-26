namespace BankClientUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ClientsPage), typeof(ClientsPage));
        }
    }
}
