# VpnClient MVP

This is a minimal viable product (MVP) of a VPN client for Windows, built using WPF and the MVVM architectural pattern. It demonstrates a mocked authentication flow and VPN node management.

## Project Structure

- **VpnClient.csproj**: The main project file.
- **App.xaml / App.xaml.cs**: Application entry point and startup logic.
- **Models**: Contains plain C# objects representing data (e.g., `User.cs`, `VpnNode.cs`).
- **Views**: Contains the WPF UI definitions (`.xaml` files) and their code-behind (`.xaml.cs` files).
  - `SignInView.xaml`: The login screen.
  - `MainView.xaml`: The main application screen displaying VPN nodes.
- **ViewModels**: Contains the logic and data for the views, implementing `INotifyPropertyChanged`.
  - `BaseViewModel.cs`: Base class for all ViewModels to handle property change notifications.
  - `SignInViewModel.cs`: ViewModel for the sign-in functionality.
  - `MainViewModel.cs`: ViewModel for the main application functionality (VPN node listing, connection).
- **Services**: Contains business logic and utility services.
  - `SessionService.cs`: Manages user session and connected VPN node.
  - `VpnConnectionService.cs`: Simulates VPN connection and disconnection.
  - `NotificationService.cs`: Simulates native notifications.
- **Repositories**: Handles data access logic.
  - `IUserRepository.cs` / `UserRepository.cs`: Manages user data (mocked).
  - `IVpnNodeRepository.cs` / `VpnNodeRepository.cs`: Manages VPN node data (mocked).
- **Commands**: Contains custom `ICommand` implementations.
  - `RelayCommand.cs`: A basic implementation of `ICommand` for binding UI actions to ViewModel methods.

## How to Run

1.  **Open in Visual Studio Code**: Open the `VpnClient` folder in Visual Studio Code.
2.  **Restore NuGet Packages**: Visual Studio Code should automatically prompt you to restore NuGet packages. If not, open the integrated terminal (Ctrl+` ) and run:
    ```bash
    dotnet restore
    ```
3.  **Run the Application**: In the integrated terminal, navigate to the `VpnClient` directory and run:
    ```bash
    dotnet run
    ```

    Alternatively, you can run the application directly from Visual Studio Code's Run and Debug view.

## Mock Data

-   **Users**: The `UserRepository.cs` contains hardcoded mock user data:
    ```csharp
    [ { "username": "admin", "email": "admin@example.com", "password": "password123" },
      { "username": "user1", "email": "user1@example.com", "password": "pass456" } ]
    ```
-   **VPN Nodes**: The `VpnNodeRepository.cs` contains hardcoded mock VPN node data:
    ```csharp
    [ { "name": "Node 1", "country": "USA", "latency_ms": 50, "public_key": "ABC123", "endpoint_ip": "192.168.1.1" },
      { "name": "Node 2", "country": "Germany", "latency_ms": 80, "public_key": "DEF456", "endpoint_ip": "192.168.2.1" } ]
    ```

## Features Implemented

-   **Mocked Authentication**: Sign In screen with username/password validation against mock data.
-   **Session Management**: `SessionService` to store current user and connected VPN node.
-   **VPN Node Listing**: Displays a list of mock VPN nodes with name, country, and latency.
-   **Connect/Disconnect Simulation**: Buttons to simulate VPN connection and disconnection, updating UI status.
-   **Native Notifications**: Simulated notifications for connection status changes.
-   **MVVM Architecture**: Separation of concerns using Models, Views, ViewModels, Services, and Repositories.
-   **Async Operations**: Use of `async`/`await` for non-blocking UI.
-   **ICommand Bindings**: UI actions bound to ViewModel commands.
-   **INotifyPropertyChanged**: ViewModel properties notify UI of changes.

## Extending Features (AI-Assisted Prompts)

Here are some prompts you can use with an AI assistant to extend or debug this project:

1.  **Adding Real API Integration for Users**:
    "I want to replace the mock `UserRepository` with a real REST API integration. Show me how to modify `UserRepository.cs` to fetch user data from `https://api.example.com/users` using `HttpClient` and `Newtonsoft.Json`."

2.  **Adding Real API Integration for VPN Nodes**:
    "How can I modify `VpnNodeRepository.cs` to fetch VPN node data from a real REST endpoint like `https://api.example.com/v1/nodes`? Provide the necessary `HttpClient` and JSON deserialization code."

3.  **Implementing Persistent User Settings**:
    "I need to save user preferences (e.g., 'Remember Me' checkbox) across application sessions. How can I use `System.IO` or `IsolatedStorageFile` to store and retrieve user settings in `SignInViewModel`?"

4.  **Enhancing UI with Data Validation**:
    "Add input validation to the `SignInView` to ensure username and password fields are not empty before attempting login. Display validation errors next to the input fields."

5.  **Implementing a Navigation Service**:
    "The current navigation between `SignInView` and `MainView` is basic. Implement a proper navigation service that can be injected into ViewModels to manage view transitions more cleanly."

6.  **Adding a Search/Filter Functionality for VPN Nodes**:
    "How can I add a search bar to `MainView` that allows users to filter the list of VPN nodes by name or country? Update `MainViewModel` to handle the filtering logic."

7.  **Integrating a Real Notification Library**:
    "Replace the console-based `NotificationService` with a real WPF notification library like `ToastNotifications`. Show me how to integrate it to display system-level notifications."

8.  **Unit Testing ViewModels**:
    "Provide an example of how to write unit tests for `SignInViewModel` using a testing framework like NUnit or xUnit. Focus on testing the `SignInCommand` and property changes."

9.  **Implementing a Custom Theme/Styling**:
    "I want to apply a dark theme to the application. Show me how to create a `ResourceDictionary` for custom styles and apply it globally to the WPF application."

10. **Handling Disconnection Scenarios (e.g., Network Loss)**:
    "How can I enhance `VpnConnectionService` to simulate network loss and automatically disconnect the VPN, notifying the user?"

This `README.md` serves as a comprehensive guide for understanding, running, and extending the VpnClient MVP application.



## Testing and Validation

To test and validate the application, follow these steps:

1.  **Build the Project**: Ensure the project builds successfully without any errors. Open the integrated terminal in VS Code (Ctrl+` ) and navigate to the `VpnClient` directory, then run:
    ```bash
    dotnet build
    ```

2.  **Run the Application**: Start the application:
    ```bash
    dotnet run
    ```

3.  **Sign In Functionality**: 
    -   **Successful Login**: Use the mock credentials (`username: admin`, `password: password123` or `username: user1`, `password: pass456`). Verify that a "Login Successful" message box appears and the `MainView` opens, closing the `SignInView`.
    -   **Failed Login**: Enter incorrect credentials. Verify that an "Invalid username or password." error message is displayed on the `SignInView`.
    -   **Input Validation**: Try to sign in with empty username or password. The "Sign In" button should be disabled (though this specific UI feedback is not explicitly implemented, the `CanSignIn` method prevents execution).

4.  **VPN Node Listing**: 
    -   Once logged in, verify that the `MainView` displays a list of VPN nodes with their Name, Country, and Latency (ms).
    -   Ensure that selecting a node in the `ListView` updates the `SelectedVpnNode` property in `MainViewModel`.

5.  **Connect/Disconnect Functionality**: 
    -   **Connect**: Select a VPN node from the list and click the "Connect" button. Observe the `ConnectionStatus` text changing to "Connecting..." and then to "Connected to [Node Name] ([Country])". A simulated notification should appear (console output).
    -   **Disconnect**: After connecting, click the "Disconnect" button. Observe the `ConnectionStatus` text changing to "Disconnecting..." and then to "Disconnected". A simulated notification should appear (console output).
    -   **Button State**: Verify that the "Connect" button is disabled when a connection is active, and the "Disconnect" button is disabled when no connection is active.
    -   **Session Update**: After connecting, the `SessionService` should store the `ConnectedNode`. After disconnecting, it should be cleared.

6.  **UI Responsiveness**: 
    -   During connection/disconnection, ensure the UI remains responsive and does not freeze, thanks to `async`/`await` operations.

This manual testing process covers the core functionalities of the MVP. For a production-ready application, automated unit and integration tests would be essential.

