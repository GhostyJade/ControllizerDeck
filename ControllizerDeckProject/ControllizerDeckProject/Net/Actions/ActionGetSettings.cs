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

using ControllizerDeckProject.Utils;
using Newtonsoft.Json.Linq;
using System.Net;

namespace ControllizerDeckProject.Net.Actions
{

    /// <summary>
    /// Path: /ports/list/
    /// Method: GET
    /// 
    /// This function is used to send a list of COM ports to the client.
    /// 
    /// </summary>
    public class ActionGetSettings : ActionBase
    {
        public ActionGetSettings() : base("GetSettings", "/settings/", HTTPType.GET)
        { }

        public override void OnGet(HttpListenerRequest request, HttpListenerResponse response)
        {
            JObject obj = new JObject()
            {
                { "result", true },
                { "ports", new JArray(SerialIO.GetPortNames().ToArray()) },
                { "wifi", CoreState.SettingsInstance.useWifi }
            };

            ResponseFactory.GenerateResponse(response, obj.ToString());
        }
    }
}
