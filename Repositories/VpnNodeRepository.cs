using VpnClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VpnClient.Repositories
{
    public class VpnNodeRepository : IVpnNodeRepository
    {
        private readonly List<VpnNode> _mockVpnNodes = new List<VpnNode>
        {
            new VpnNode { Name = "Node 1", Country = "USA", Latency_ms = 50, Public_key = "ABC123", Endpoint_ip = "192.168.1.1" },
            new VpnNode { Name = "Node 2", Country = "Germany", Latency_ms = 80, Public_key = "DEF456", Endpoint_ip = "192.168.2.1" }
        };

        public async Task<IEnumerable<VpnNode>> GetVpnNodes()
        {
            // Simulate network delay
            await Task.Delay(100);
            return _mockVpnNodes;
        }
    }
}

