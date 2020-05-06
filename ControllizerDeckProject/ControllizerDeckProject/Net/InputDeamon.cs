using System.Net.Sockets;

namespace ControllizerDeckProject.Net
{
    public class InputDeamon
    {
        private Socket daemonSocket;

        public InputDeamon()
        {
            daemonSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private void HandleRequests()
        {
            
        }

    }
}
