using VpnClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VpnClient.Repositories
{
    public interface IVpnNodeRepository
    {
        Task<IEnumerable<VpnNode>> GetVpnNodes();
    }
}

