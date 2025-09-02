using VpnClient.Commands;
using VpnClient.Models;
using VpnClient.Repositories;
using VpnClient.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

// Added
using VpnClient.Views;


namespace VpnClient.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<VpnNode> _vpnNodes;
        public ObservableCollection<VpnNode> VpnNodes
        {
            get => _vpnNodes;
            set { _vpnNodes = value; OnPropertyChanged(); }
        }

        private VpnNode _selectedVpnNode;
        public VpnNode SelectedVpnNode
        {
            get => _selectedVpnNode;
            set
            {
                _selectedVpnNode = value;
                OnPropertyChanged();
                ((RelayCommand)ConnectCommand).RaiseCanExecuteChanged();
            }
        }

        private bool _isConnected;
        public bool IsConnected
        {
            get => _isConnected;
            set
            {
                _isConnected = value;
                OnPropertyChanged();
                ((RelayCommand)ConnectCommand).RaiseCanExecuteChanged();
                ((RelayCommand)DisconnectCommand).RaiseCanExecuteChanged();
            }
        }

        private string _connectionStatus;
        public string ConnectionStatus
        {
            get => _connectionStatus;
            set { _connectionStatus = value; OnPropertyChanged(); }
        }

        public ICommand ConnectCommand { get; }
        public ICommand DisconnectCommand { get; }
        public ICommand LogoutCommand { get; }

        private readonly IVpnNodeRepository _vpnNodeRepository;
        private readonly VpnConnectionService _vpnConnectionService;
        private readonly SessionService _sessionService;
        private readonly NotificationService _notificationService;

        public MainViewModel()
        {
            _vpnNodeRepository = new VpnNodeRepository();
            _vpnConnectionService = new VpnConnectionService();
            _sessionService = new SessionService();
            _notificationService = new NotificationService();

            VpnNodes = new ObservableCollection<VpnNode>();
            ConnectionStatus = "Disconnected";

            ConnectCommand = new RelayCommand(async param => await Connect(), param => CanConnect());
            DisconnectCommand = new RelayCommand(async param => await Disconnect(), param => CanDisconnect());
            LogoutCommand = new RelayCommand(param => Logout(param));

            LoadVpnNodes();

        }

        private async void LoadVpnNodes()
        {
            var nodes = await _vpnNodeRepository.GetVpnNodes();
            foreach (var node in nodes)
                VpnNodes.Add(node);
        }

        private async Task Connect()
        {
            if (SelectedVpnNode == null) return;

            ConnectionStatus = $"Connecting to {SelectedVpnNode.Name}...";
            bool success = await _vpnConnectionService.ConnectToVpn(SelectedVpnNode);

            if (success)
            {
                IsConnected = true;
                _sessionService.SetConnectedNode(SelectedVpnNode);
                ConnectionStatus = $"Connected to {SelectedVpnNode.Name} ({SelectedVpnNode.Country})";
                _notificationService.ShowNotification("VPN Connected", $"Successfully connected to {SelectedVpnNode.Name}.");
            }
            else
            {
                IsConnected = false;
                ConnectionStatus = "Connection Failed";
                _notificationService.ShowNotification("VPN Connection Failed", $"Could not connect to {SelectedVpnNode.Name}.");
            }
        }

        private bool CanConnect() => SelectedVpnNode != null && !IsConnected;

        private async Task Disconnect()
        {
            if (_sessionService.ConnectedNode == null) return;

            ConnectionStatus = $"Disconnecting from {_sessionService.ConnectedNode.Name}...";
            bool success = await _vpnConnectionService.DisconnectFromVpn(_sessionService.ConnectedNode);

            if (success)
            {
                IsConnected = false;
                ConnectionStatus = "Disconnected";
                _notificationService.ShowNotification("VPN Disconnected", $"Successfully disconnected from {_sessionService.ConnectedNode.Name}.");
                _sessionService.SetConnectedNode(null);
            }
            else
            {
                ConnectionStatus = "Disconnection Failed";
                _notificationService.ShowNotification("VPN Disconnection Failed", $"Could not disconnect from {_sessionService.ConnectedNode.Name}.");
            }
        }

        private bool CanDisconnect() => IsConnected;


        // Added
        private void Logout(object parameter)
        {
            // Clear session
            _sessionService.SetConnectedNode(null);

            // Open SignInView
            SignInView signInView = new SignInView();
            signInView.Show();

            // Close MainWindow
            if (parameter is Window currentWindow)
                currentWindow.Close();
        }
        
    }
}
