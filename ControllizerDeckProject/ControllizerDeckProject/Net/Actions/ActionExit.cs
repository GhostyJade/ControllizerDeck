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
using System.Text;
using System.Threading.Tasks;

namespace ControllizerDeckProject.Net.Actions
{
    public class ActionExit : ActionBase
    {
        public ActionExit() : base("exit", "/exit/", HTTPType.POST)
        { }

        public override void OnPost(HttpListenerRequest request, HttpListenerResponse response)
        {
            if (!CoreState.HasCloseRequested)
            {
                CoreState.HasCloseRequested = true; // TODO i should use this instead of closing the application directly
                
                //TODO move this method to a ResposeFactory (or something like that)
                string jsonResponse = "{\"result\":true}";
                byte[] data = Encoding.UTF8.GetBytes(jsonResponse);
                // Write the response info
                response.ContentType = "application/json";
                response.ContentEncoding = Encoding.UTF8;
                response.ContentLength64 = data.LongLength;

                // Write out to the response stream (asynchronously), then close it
                Task a = response.OutputStream.WriteAsync(data, 0, data.Length);
                a.GetAwaiter().GetResult();
                response.Close();
                System.Environment.Exit(0); //TODO also, i have to close every thing that must be close (serial, httpserver, etc)
            }
        }
    }
}
