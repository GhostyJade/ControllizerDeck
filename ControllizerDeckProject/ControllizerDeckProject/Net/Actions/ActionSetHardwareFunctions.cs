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

using ControllizerDeckProject.Core;
using ControllizerDeckProject.Core.ControllizerActions;
using ControllizerDeckProject.Utils;

using Newtonsoft.Json.Linq;

using System.Net;

namespace ControllizerDeckProject.Net.Actions
{
    /// <summary>
    /// Path: /hardware/functions/
    /// Method: POST
    /// 
    /// This function is called to set an hardware specific action.
    /// The request must contain a body
    /// 
    /// </summary>
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

            string jsonBody = ResponseFactory.JsonStringFromRequest(request);

            //Parse data
            JToken t = JToken.Parse(jsonBody);
            int componentId = (int)t.SelectToken("id");

            JObject obj = (JObject)t.SelectToken("data");
            EventTypeMapping eventType = (EventTypeMapping)(int)obj.SelectToken("action");
            switch (eventType)
            {
                case EventTypeMapping.None:
                    InputDispatcher.UpdatePushButtonAction(componentId, null);
                    break;
                case EventTypeMapping.LaunchApp:
                    string actionName = (string)obj.SelectToken("name");
                    string appPath = (string)obj.SelectToken("path");
                    InputDispatcher.UpdatePushButtonAction(componentId, new ActionRunProgram(actionName) { FullAppDirectory = appPath, AppName = actionName });
                    break;
                case EventTypeMapping.OpenWebsite:
                    string uri = (string)obj.SelectToken("websiteUri");
                    string name = (string)obj.SelectToken("name");
                    var action = new ActionOpenWebsite() { WebsiteName = name, WebsiteUri = uri };
                    action.Init();
                    InputDispatcher.UpdatePushButtonAction(componentId, action);
                    break;
            }
            InputDispatcher.UpdateActionMappingFile();

            string jsonResponse = "{\"result\":true}";
            ResponseFactory.GenerateResponse(response, jsonResponse);
        }
    }
}
