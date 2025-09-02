using System.Threading.Tasks;
using VpnClient.Models;

namespace VpnClient.Services
{
    public class VpnConnectionService
    {
        public async Task<bool> ConnectToVpn(VpnNode node)
        {
            // Simulate VPN connection process
            await Task.Delay(2000); // Simulate connection time
            return true; // Always successful for now
        }

        public async Task<bool> DisconnectFromVpn(VpnNode node)
        {
            // Simulate VPN disconnection process
            await Task.Delay(1000); // Simulate disconnection time
            return true; // Always successful for now
        }
    }
}

