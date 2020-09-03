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

using ControllizerCore.Net.Actions;
using ControllizerCore.Utils;

using ControllizerDeckProject.Utils;

using Newtonsoft.Json.Linq;

using System.Net;

namespace ControllizerDeckProject.Net.Actions
{
    /// <summary>
    /// Path: /ports/
    /// Method: POST
    /// 
    /// This function is called to set the new COM port.
    /// 
    /// </summary>
    public class ActionSetCOMPort : ActionBase
    {
        public ActionSetCOMPort() : base("SetCOMPort", "/ports/", HTTPType.POST)
        { }

        public override void OnPost(HttpListenerRequest request, HttpListenerResponse response)
        {
            if (request.ContentType == null)
            {
                ConsoleManager.LogError("Missing Content-Type in " + ActionName);
                return;
            }
            if (!request.ContentType.Equals("application/json")) return;//TODO Create exception
            // Get request body:
            string jsonBody = ResponseFactory.JsonStringFromRequest(request);

            //Parse body and get port value
            JToken t = JToken.Parse(jsonBody);
            string port = (string)t.SelectToken("port");

            // Set port value
            CoreState.SettingsInstance.COMPort = port;

            // Starts the SerialManager
            SerialManager.ManagerInstance.Start();

            string jsonResponse = "{\"result\":true}";
            ResponseFactory.GenerateResponse(response, jsonResponse);
        }
    }
}
