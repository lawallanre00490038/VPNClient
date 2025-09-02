I want to build a native MVP VPN client for Windows using WPF and MVVM architecture. The client should have a mocked authentication flow: a Sign In screen where users can enter email/username and password, validated against a mock JSON file or HTTP mock endpoint containing sample users, for example:

[
  { "username": "admin", "email": "admin@example.com", "password": "password123" },
  { "username": "user1", "email": "user1@example.com", "password": "pass456" }
]


Successful login should store the user session using a SessionService, and failed login should display a message. Include async operations, ICommand bindings, and proper ViewModel notifications (INotifyPropertyChanged).

The client should also fetch a list of VPN nodes from a mock REST endpoint (/api/v1/nodes) or JSON file, for example:

[
  { "name": "Node 1", "country": "USA", "latency_ms": 50, "public_key": "ABC123", "endpoint_ip": "192.168.1.1" },
  { "name": "Node 2", "country": "Germany", "latency_ms": 80, "public_key": "DEF456", "endpoint_ip": "192.168.2.1" }
]


The UI should display node name, country, and latency, with a Connect button that simulates a VPN connection, toggles UI to “connected,” stores the connected node in the session, and triggers native notifications. Scaffold the project with Models, ViewModels, Views, Services (VPNConnectionService, NotificationService), and Repositories (UserRepository, VPNNodeRepository). Provide a runnable WPF project with clear comments, and also include step-by-step AI-assisted prompts for generating, debugging, and extending the features. Emphasize SOLID principles, clean architecture, and MVVM best practices.

ensure the code is modular able to run in vs code