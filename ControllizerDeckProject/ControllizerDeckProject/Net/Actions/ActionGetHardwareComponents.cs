using ControllizerDeckProject.Core;

using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControllizerDeckProject.Net.Actions
{
    public class ActionGetHardwareComponents : ActionBase
    {
        public ActionGetHardwareComponents() : base("GetHardwareComponents", "/hardware/", HTTPType.GET)
        { }

        public override void OnGet(HttpListenerRequest request, HttpListenerResponse response)
        {
            //TODO move this method to a response factory

            byte[] data = Encoding.UTF8.GetBytes(InputDispatcher.ObjectsToJSON());
            // Write the response info
            response.ContentType = "application/json";
            response.ContentEncoding = Encoding.UTF8;
            response.ContentLength64 = data.LongLength;

            // Write out to the response stream (asynchronously), then close it
            Task a = response.OutputStream.WriteAsync(data, 0, data.Length);
            a.GetAwaiter().GetResult();
            response.Close();
        }
    }
}
