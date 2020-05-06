using System;
using System.Net;
using System.Threading.Tasks;

namespace ControllizerDeckProject.Net
{
    public class HttpServer
    {
        protected string address;
        protected int port;
        protected HttpListener listener;
        protected bool Active = false;

        public HttpServer(string address, int port)
        {
            this.port = port;
            this.address = address;
        }

        public async Task Listen()
        {
            Active = true;
            listener = new HttpListener();
            listener.Prefixes.Add(address);
            listener.Start();
            while (Active)
            {
                // Will wait here until we hear from a connection
                HttpListenerContext ctx = await listener.GetContextAsync();

                // Peel out the requests and response objects
                HttpListenerRequest req = ctx.Request;
                HttpListenerResponse resp = ctx.Response;

                HandleGETRequest(req);
                HandlePOSTRequest(req);

                // Print out some info about the request
                Console.WriteLine("Request #: {0}", "");//, ++requestCount);
                Console.WriteLine(req.Url.ToString());
                Console.WriteLine(req.HttpMethod);
                Console.WriteLine(req.UserHostName);
                Console.WriteLine(req.UserAgent);
                Console.WriteLine();

                // If `shutdown` url requested w/ POST, then shutdown the server after serving the page
                if ((req.HttpMethod == "POST") && (req.Url.AbsolutePath == "/shutdown"))
                {
                    Console.WriteLine("Shutdown requested");
                    Active = false;
                }

                // Make sure we don't increment the page views counter if `favicon.ico` is requested
                if (req.Url.AbsolutePath != "/favicon.ico")
                    ;// pageViews += 1;

                // Write the response info
                string disableSubmit = !Active ? "disabled" : "";
                /*byte[] data = Encoding.UTF8.GetBytes(string.Format(pageData, pageViews, disableSubmit));
                resp.ContentType = "text/html";
                resp.ContentEncoding = Encoding.UTF8;
                resp.ContentLength64 = data.LongLength;

                // Write out to the response stream (asynchronously), then close it
                await resp.OutputStream.WriteAsync(data, 0, data.Length);*/
                resp.Close();
            }
        }

        private void HandlePOSTRequest(HttpListenerRequest request)
        {
            if (!request.HttpMethod.Equals("POST"))
                return;
            //handle right request position ("/exit/" || "/add/" etc)
            ActionManager.GetPOSTActions().ForEach(e => e.Execute());
        }
        private void HandleGETRequest(HttpListenerRequest request)
        {
            if (!request.HttpMethod.Equals("GET"))
                return;
        }
    }
}
