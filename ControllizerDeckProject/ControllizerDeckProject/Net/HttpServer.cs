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

using System.Net;
using System.Threading.Tasks;

namespace ControllizerDeckProject.Net
{
    public class HttpServer
    {
        protected string address;
        protected int port;
        protected HttpListener listener;

        protected bool Active = false; //TODO change this to false when POST /exit/ is performed

        public HttpServer(string address, int port)
        {
            this.port = port;
            this.address = address;

            ActionManager.Init(); //And i should move this line elsewhere.
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

                HandleGETRequest(req, resp);
                HandlePOSTRequest(req, resp);
            }
        }

        //Known bug: if the given RawUrl is not existent in the available methods it crashes...make it try/catch or delete the last / in the request
        private void HandlePOSTRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            if (!request.HttpMethod.Equals("POST"))
                return;
            //handle right request position ("/exit/" || "/add/" etc)
            ActionManager.GetPOSTActions().Find(e => e.ActionURI.Equals(request.RawUrl)).OnPost(request, response);
        }
        private void HandleGETRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            if (!request.HttpMethod.Equals("GET"))
                return;
            ActionManager.GetGETActions().Find(e => e.ActionURI.Equals(request.RawUrl)).OnGet(request, response);
        }
    }

}
