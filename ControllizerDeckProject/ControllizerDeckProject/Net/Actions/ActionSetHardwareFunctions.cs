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

using ControllizerDeckProject.Utils;

using Newtonsoft.Json.Linq;

using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControllizerDeckProject.Net.Actions
{
    public class ActionSetHardwareFunctions : ActionBase
    {
        public ActionSetHardwareFunctions() : base("SetHardwareFunctions", "/hardware/functions/", HTTPType.POST)
        { }

        public override void OnPost(HttpListenerRequest request, HttpListenerResponse response)
        {
            if (request.ContentType == null)
            {
                ConsoleManager.LogError("Missing Content-Type in " + ActionName);
                return;
            }
            if (!request.ContentType.Equals("application/json")) return;

            Stream body = request.InputStream;
            Encoding bodyEncoding = request.ContentEncoding;
            StreamReader reader = new StreamReader(body, bodyEncoding);
            string jsonBody = reader.ReadToEnd();

            JToken t = JToken.Parse(jsonBody);

            //do stuff

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
        }
    }
}
