
# VpnClient MVP

This is a **Minimal Viable Product (MVP)** of a VPN client for Windows, built using **WPF** and the **MVVM architectural pattern**. It demonstrates a mocked authentication flow, VPN node management, and simulated VPN connections.

## 🚀 Overview

VpnClient allows users to:
- Log in using mock credentials  
- View available VPN nodes with name, country, and latency  
- Simulate connecting and disconnecting to VPN nodes  
- Receive native-like notifications for connection changes  
- Logout to return to the login screen  

The application uses **MVVM** architecture, separating concerns across **Models, Views, ViewModels, Services, and Repositories**.

## 🛠️ Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) (or compatible)  
- Visual Studio 2022 (or later) with WPF desktop workload  
- Optional: Visual Studio Code with C# extension  

## 📂 Project Structure

```
VpnClient/
│
├─ Models/
│   ├─ User.cs
│   └─ VpnNode.cs
│
├─ Views/
│   ├─ SignInView.xaml / .xaml.cs
│   └─ MainWindow.xaml / .xaml.cs
│
├─ ViewModels/
│   ├─ BaseViewModel.cs
│   ├─ SignInViewModel.cs
│   └─ MainViewModel.cs
│
├─ Services/
│   ├─ SessionService.cs
│   ├─ VpnConnectionService.cs
│   └─ NotificationService.cs
│
├─ Repositories/
│   ├─ IUserRepository.cs / UserRepository.cs
│   └─ IVpnNodeRepository.cs / VpnNodeRepository.cs
│
├─ Commands/
│   └─ RelayCommand.cs
│
├─ Converters/
│   └─ NullToBoolConverter.cs
│
├─ App.xaml / App.xaml.cs
└─ VpnClient.csproj
```

## ⚙️ Setup & Run

1. **Clone the Repository**
   ```bash
   git clone <your-repo-url>
   cd VpnClient
   ```

2. **Open in IDE**  
   - Open the `VpnClient` folder in **Visual Studio** or **VS Code**.

3. **Restore Packages**
   - Visual Studio: Automatic prompt  
   - VS Code / CLI:  
   ```bash
   dotnet restore
   ```

4. **Build the Project**
   ```bash
   dotnet build
   ```

5. **Run the Application**
   ```bash
   dotnet run
   ```
   Or simply press **F5** in Visual Studio.

## 🧪 Mock Data  

**Users (UserRepository.cs):**
```csharp
[
  { "username": "admin", "email": "admin@example.com", "password": "password123" },
  { "username": "user1", "email": "user1@example.com", "password": "pass456" }
]
```

**VPN Nodes (VpnNodeRepository.cs):**
```csharp
[
  { "name": "Node 1", "country": "USA", "latency_ms": 50, "public_key": "ABC123", "endpoint_ip": "192.168.1.1" },
  { "name": "Node 2", "country": "Germany", "latency_ms": 80, "public_key": "DEF456", "endpoint_ip": "192.168.2.1" }
]
```

## ✨ Features Implemented

- **Login / Authentication**: Validates against mock users  
- **Session Management**: Tracks logged-in user & connected VPN node  
- **VPN Node Listing**: Displays mock VPN nodes with details  
- **Connect / Disconnect Simulation**: Updates status & simulates connection  
- **Native Notifications**: Simulated connection change alerts  
- **Logout**: Clears session & returns to login screen  
- **MVVM Architecture**: Clean separation of concerns  
- **Async Operations**: Non-blocking UI via async/await  
- **ICommand Bindings**: Button actions in ViewModels  
- **INotifyPropertyChanged**: Automatic UI updates  

## 🏗️ UML Architecture Overview

```
+-------------------+
|       Views        |
|-------------------|
| SignInView         |
| MainWindow         |
+---------^----------+
          |
          v
+-------------------+
|    ViewModels      |
|-------------------|
| SignInViewModel    |
| MainViewModel      |
| BaseViewModel      |
+---------^----------+
          |
          v
+-------------------+
|      Services      |
|-------------------|
| SessionService     |
| VpnConnectionSvc   |
| NotificationSvc    |
+---------^----------+
          |
          v
+-------------------+
|   Repositories     |
|-------------------|
| UserRepository     |
| VpnNodeRepository  |
+-------------------+
```

## 🔄 Workflow Diagram

```
User --> SignInView --> SignInViewModel
  |                                 |
  |-- enters credentials ------------|
  |                                 |
  |-- [valid] --> MainWindow --> MainViewModel
  |                  |              |
  |                  |-- Load VPN Nodes
  |                  |-- Connect/Disconnect
  |                  |-- SessionService updates
  |                  |-- NotificationService alerts
  |
  |-- Logout --> Session cleared --> Back to SignInView
```

## 🧪 Testing & Validation

- **Build**: Ensure no build errors  
- **Login**:  
  - Valid → MainWindow opens  
  - Invalid → Error message shown  
- **VPN Nodes**: Displayed correctly with details  
- **Connect / Disconnect**: Status & notifications work  
- **Logout**: Clears session & returns to login  

## 📌 Notes

- This is a **simulated VPN client**; no real VPN connections occur.  
- Designed for **Windows WPF** using **MVVM** pattern.  
- Easily extendable for **real VPN APIs** integration.  

## 📄 License
MIT License - Feel free to use and modify for learning and development.
