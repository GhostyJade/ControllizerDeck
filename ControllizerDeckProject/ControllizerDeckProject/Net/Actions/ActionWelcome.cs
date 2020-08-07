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

using ControllizerDeckProject.Core.Hardware;
using ControllizerDeckProject.Utils;

using Newtonsoft.Json.Linq;

using System.Collections.Generic;
using System.Net;

namespace ControllizerDeckProject.Net.Actions
{
    /// <summary>
    /// This class is used to create the hardwaredescription file by the frontend
    /// </summary>
    public class ActionWelcome : ActionBase
    {
        public ActionWelcome() : base("ActionWelcome", "/welcome/", HTTPType.POST)
        { }

        public override void OnPost(HttpListenerRequest request, HttpListenerResponse response)
        {
            if (request.ContentType == null)
                return; //TODO handle failure
            if (!request.ContentType.Equals("application/json"))
                return;
            string jsonBody = ResponseFactory.JsonStringFromRequest(request);
            JObject body = JObject.Parse(jsonBody);
            bool success;
            try
            {
                int btnCount = (int)body.SelectToken("btnCount");
                int encodersCount = (int)body.SelectToken("encodersCount");
                int knobsCount = (int)body.SelectToken("knobsCount");

                JToken btnData = body.SelectToken("buttons");
                bool isMatrix = (bool)btnData.SelectToken("matrix");
                string type = isMatrix ? "matrix" : "list";
                string layout = "";
                if (isMatrix)
                {
                    layout = (int)btnData.SelectToken("w") + "x" + (int)btnData.SelectToken("h");
                }
                List<HardwareDescription.Encoder> encodersList = new List<HardwareDescription.Encoder>();

                HardwareDescription description = new HardwareDescription
                {
                    btnData = new HardwareDescription.ButtonsData()
                    {
                        identifier = "PB",
                        size = btnCount,
                        layout = layout,
                        type = type
                    },
                    knbData = new HardwareDescription.KnobsData()
                    {
                        identifier = "K",
                        size = knobsCount
                    },
                    encData = new HardwareDescription.EncodersData()
                    {
                        encoders = encodersList
                    }
                };

                success = true;
                HardwareHelper.StoreConfiguration(description);
                HardwareHelper.InitHardware();
                CoreState.SettingsInstance.IsFirstLaunch = false;
                SettingsManager.SaveSettings();
            }
            catch
            {
                success = false;
            }

            ResponseFactory.GenerateResponse(response, "{\"result\":" + success.ToString().ToLower() + "}");
        }
    }
}
