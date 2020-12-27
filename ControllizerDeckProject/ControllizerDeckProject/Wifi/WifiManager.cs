using ControllizerDeckProject.Core;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ControllizerDeckProject.Wifi
{
    public class WifiManager
    {
        private Thread wifiThread;
        private UdpClient client;
        private bool running = false;
        private int port = 4001;
        public static WifiManager ManagerInstance
        {
            get
            {
                if (_instance == null) _instance = new WifiManager();
                return _instance;
            }
        }
        private static WifiManager _instance;

        public WifiManager()
        {
            wifiThread = new Thread(ReceiveData)
            {
                IsBackground = true
            };
            client = new UdpClient(port)
            {
                EnableBroadcast = true
            };
        }

        public void Start()
        {
            running = true;
            wifiThread.Start();
        }

        private void ReceiveData()
        {
            while (running)
            {
                IPEndPoint host = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref host);
                string str = Encoding.ASCII.GetString(data);
                Console.WriteLine("Received {0} from ESP32", str);
                InputDispatcher.PerformAction(str);
            }
        }

        public void Dispose()
        {
            running = false;
            wifiThread.Abort();
            client.Close();
        }
    }
}
