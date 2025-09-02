using VpnClient.Commands;
using VpnClient.Repositories;
using VpnClient.Services;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VpnClient.Views;

namespace VpnClient.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
        private string _username = string.Empty;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
                ((RelayCommand)SignInCommand).RaiseCanExecuteChanged(); // <-- update button state
            }
        }

        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
                ((RelayCommand)SignInCommand).RaiseCanExecuteChanged(); // <-- update button state
            }
        }

        private string _errorMessage = string.Empty;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand SignInCommand { get; }

        private readonly IUserRepository _userRepository;
        private readonly SessionService _sessionService;

        public SignInViewModel()
        {
            _userRepository = new UserRepository();
            _sessionService = new SessionService();
            SignInCommand = new RelayCommand(async param => await SignIn(param), param => CanSignIn());
        }

        // private async Task SignIn(object parameter)
        // {
        //     ErrorMessage = string.Empty;
        //     var user = await _userRepository.GetUserByUsernameAndPassword(Username, Password);

        //     if (user != null)
        //     {
        //         _sessionService.SetCurrentUser(user);

        //         MessageBox.Show($"Welcome, {user.Username}!", "Login Successful");

        //         if (parameter is Window currentWindow)
        //         {
        //             currentWindow.Close();
        //         }

        //         MainView mainView = new MainView();
        //         mainView.Show();
        //     }
        //     else
        //     {
        //         ErrorMessage = "Invalid username or password.";
        //     }
        // }

        private async Task SignIn(object parameter)
        {
            ErrorMessage = string.Empty;
            var user = await _userRepository.GetUserByUsernameAndPassword(Username, Password);

            if (user != null)
            {
                _sessionService.SetCurrentUser(user);

                // Open MainWindow
                MainWindow mainWindow = new MainWindow();
                Application.Current.MainWindow = mainWindow;
                mainWindow.Show();

                // Close SignIn window
                if (parameter is Window signInWindow)
                {
                    signInWindow.Close();
                }
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
            }
        }

        private bool CanSignIn()
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }
    }
}
