_This document contains a list of AI-assisted prompts for extending and debugging the VpnClient MVP application._

### Extending Features (AI-Assisted Prompts)

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

