using System.Windows;
using VpnClient.Views;

namespace VpnClient
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            SignInView signInView = new SignInView();
            signInView.Show();
        }
    }
}

