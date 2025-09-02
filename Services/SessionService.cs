using VpnClient.Models;

namespace VpnClient.Services
{
    public class SessionService
    {
        public User CurrentUser { get; private set; }
        public VpnNode ConnectedNode { get; private set; }

        public void SetCurrentUser(User user)
        {
            CurrentUser = user;
        }

        public void ClearSession()
        {
            CurrentUser = null;
            ConnectedNode = null;
        }

        public void SetConnectedNode(VpnNode node)
        {
            ConnectedNode = node;
        }
    }
}

