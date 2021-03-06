﻿/*
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

using ControllizerCore.Net.Actions;

using ControllizerDeckProject.Core.Hardware;
using ControllizerDeckProject.Utils;

using Newtonsoft.Json.Linq;

using System.Collections.Generic;
using System.Net;

namespace ControllizerDeckProject.Net.Actions
{
    /// <summary>
    /// Path: /welcome/
    /// Method: POST
    /// 
    /// This class is used to create the hardware description file by the frontend
    /// 
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
                    // TODO make identifiers editable
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
                        encoderIdentifier = "RE",
                        encoderButtonIdentifier = "REB",
                        encoders = encodersList
                    }
                };

                string ComPort = (string)body.SelectToken("serialPort");
                string WifiPort = (string)body.SelectToken("wifiPort");
                bool useWifi = !string.IsNullOrEmpty(WifiPort);
                HardwareHelper.StoreConfiguration(description);
                HardwareHelper.InitHardware();
                CoreState.SettingsInstance.IsFirstLaunch = false;
                CoreState.SettingsInstance.useWifi = useWifi;
                if (!useWifi)
                {
                    CoreState.SettingsInstance.COMPort = ComPort;
                }
                else
                {
                    if (int.TryParse(WifiPort, out int value))
                        CoreState.SettingsInstance.WifiServerPort = value;
                }
                SettingsManager.SaveSettings();
                success = true;
            }
            catch
            {
                success = false;
            }

            ResponseFactory.GenerateResponse(response, "{\"result\":" + success.ToString().ToLower() + "}");
        }
    }
}
