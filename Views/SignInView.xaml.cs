// // using System.Windows;
// // using System.Windows.Controls;
// // using VpnClient.ViewModels;

// // namespace VpnClient.Views
// // {
// //     public partial class SignInView : Window
// //     {
// //         public SignInView()
// //         {
// //             InitializeComponent();
// //             this.DataContext = new SignInViewModel();
// //         }

// //         private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
// //         {
// //             if (this.DataContext != null)
// //             {
// //                 ((SignInViewModel)this.DataContext).Password = ((PasswordBox)sender).Password;
// //             }
// //         }
// //     }
// // }









using System.Windows;
using System.Windows.Controls;
using VpnClient.ViewModels;

namespace VpnClient.Views
{
    public partial class SignInView : Window
    {
        public SignInView()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is SignInViewModel viewModel)
            {
                viewModel.Password = ((PasswordBox)sender).Password;
            }
        }
    }
}

