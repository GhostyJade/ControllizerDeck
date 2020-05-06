using ControlizerCore.Serial;

using ControllizerDeckProject.Net;

using System.Threading.Tasks;

namespace ControllizerDeckProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SerialManager manager = new SerialManager();
            manager.Start();
            HttpServer server = new HttpServer("http://localhost:8080/", 8080);
            Task listen = server.Listen();
            listen.GetAwaiter().GetResult();
        }
    }
}
