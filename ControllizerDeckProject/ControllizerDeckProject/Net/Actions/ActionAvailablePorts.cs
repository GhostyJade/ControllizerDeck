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

using ControlizerCore.Serial;

using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControllizerDeckProject.Net.Actions
{
    public class ActionAvailablePorts : ActionBase
    {
        public ActionAvailablePorts() : base("AvailablePortList", "/ports/list/", HTTPType.GET)
        { }

        public override void OnGet(HttpListenerRequest request, HttpListenerResponse response)
        {
            string[] portArray = SerialIO.GetPortNames().ToArray();

            //TODO move this method to a ResponseFactory (or something like that)
            string jsonResponse = "{\"result\":true,\n \"ports\":[";
            for(int i = 0; i < portArray.Length; i++)
            {
                jsonResponse += $"\"{portArray[i]}\"";
                if (i != portArray.Length - 1)
                    jsonResponse += ",";
            }
            jsonResponse += "]}";

            byte[] data = Encoding.UTF8.GetBytes(jsonResponse);
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
