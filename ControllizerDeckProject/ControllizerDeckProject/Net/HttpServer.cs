/*
    Controllizer Deck - A DIY customizable controller deck
    Copyright (C) 2020  GhostyJade <ghostyjade2410@gmail.com>

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

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

            ActionManager.INIT(); //And i should move this line elsewhere.
        }

        public async Task Listen()
        {
            Active = true;
            listener = new HttpListener();
            listener.Prefixes.Add($"http://{address}:{port}/");
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

                // If `shutdown` url requested w/ POST, then shutdown the server after serving the page
                if ((req.HttpMethod == "POST") && (req.Url.AbsolutePath == "/shutdown"))
                {
                    Console.WriteLine("Shutdown requested");
                    Active = false;
                }

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
            ActionManager.GetPOSTActions().Find(e => e.ActionURI.Equals(request.RawUrl)).OnPost();
        }
        private void HandleGETRequest(HttpListenerRequest request)
        {
            if (!request.HttpMethod.Equals("GET"))
                return;
            ActionManager.GetGETActions().Find(e => e.ActionURI.Equals(request.RawUrl)).OnGet();
        }
    }

}
