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

using ControllizerCore.Input.Action;

using ControllizerDeckProject.Core.Input;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.IO;

namespace ControllizerDeckProject.Core.Hardware
{
    /// <summary>
    /// This class load the hardware description file and prepare it's content to be read to the rest of the app
    /// </summary>
    public static class HardwareDataManager
    {
        private const string HardwareDescriptionFile = "Data/Hardware/hardwaredescription.json";
        private const string ActionDataFile = "Data/Hardware/actionmapping.json";

        private static string LoadFromFile()
        {
            if (!File.Exists(AppContext.BaseDirectory + HardwareDescriptionFile))
                throw new FileNotFoundException(HardwareDescriptionFile);
            return File.ReadAllText(AppContext.BaseDirectory + HardwareDescriptionFile);
        }

        private class ActionDataMapping
        {
            public int id;
            public DigitalInputActionBase action;
        }

        public static void StoreMapping(HardwareData inputDataMapping)
        {
            List<ActionDataMapping> rawData = new List<ActionDataMapping>();
            inputDataMapping.PushButtons.ForEach(e =>
            {
                if (e.AssociatedAction != null)
                    rawData.Add(new ActionDataMapping() { id = e.Identifier, action = e.AssociatedAction });
            });
            JArray pushButtons = JArray.FromObject(rawData);
            JObject obj = new JObject
            {
                { "PushButton", pushButtons }
            };
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter streamWriter = new StreamWriter(string.Format("{0}/{1}", AppContext.BaseDirectory, ActionDataFile)))
            using (JsonWriter writer = new JsonTextWriter(streamWriter))
            {
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, obj);
            }
        }

        /// <summary>
        /// Load an Hardware mapping from file
        /// </summary>
        public static HardwareData LoadData()
        {
            return LoadData(LoadFromFile());
        }

        /// <summary>
        /// Create an Hardware mapping from a raw json string
        /// </summary>
        /// <param name="jsonHardwareData">the hardware json description string</param>
        public static HardwareData LoadData(string jsonData)
        {
            HardwareData d = new HardwareData();

            JToken data = JToken.Parse(jsonData);
            // Parses push buttons' data:
            JObject pushButtonObj = (JObject)data.SelectToken("PushButton");
            if (pushButtonObj != null)
            {
                string type = (string)pushButtonObj.SelectToken("type");
                string identifier = (string)pushButtonObj.SelectToken("identifier");
                if (identifier != null)
                {
                    PushButton.UpdateIdentifier(identifier);
                }
                // Check what type of pushbutton the hardware has:
                if (type == "list")
                {
                    JArray btn = (JArray)pushButtonObj.SelectToken("buttons");
                    for (int i = 0; i < btn.Count; i++)
                    {
                        int id = (int)btn[i].SelectToken("id");
                        d.PushButtons.Add(new PushButton(id));
                    }
                }
                else if (type == "matrix")
                {
                    d.HasInitializedAsMatrix = true;
                    d.MatrixLayout = (string)pushButtonObj.SelectToken("layout");
                    int count = (int)pushButtonObj.SelectToken("size");
                    for (int i = 0; i < count; i++)
                    {
                        d.PushButtons.Add(new PushButton(i));
                    }
                }
                else
                {
                    //log unknown/invalid type
                }
            }

            // Parses rotary encoders' data:
            JArray rotEnc = (JArray)data.SelectToken("RotaryEncoder");
            if (rotEnc != null)
            {
                for (int i = 0; i < rotEnc.Count; i++)
                {
                    int id = (int)rotEnc[i].SelectToken("id");
                    bool hasButton = (bool)rotEnc[i].SelectToken("hasButton");
                    d.RotaryEncoders.Add(new RotaryEncoder(id, hasButton));
                }
            }

            // Parses knobs' data
            JObject knobsObj = (JObject)data.SelectToken("Knobs");
            if (knobsObj != null)
            {
                int knobsCount = (int)knobsObj.SelectToken("size");
                for (int i = 0; i < knobsCount; i++)
                {
                    d.Knobs.Add(new Knob(i));
                }
            }

            return d;
        }

        /// <summary>
        /// Make a JObject from an HardwareDescription to stored as a json file
        /// </summary>
        /// <param name="d">the HardwareDescription object</param>
        /// <returns>the Json representation of the HardwareDescription object</returns>
        public static JObject Serialize(HardwareDescription d)
        {
            JObject container = new JObject();
            JObject btns = JObject.FromObject(d.btnData);
            container.Add("PushButton", btns);
            JArray encoders = new JArray();
            d.encData.encoders.ForEach(e => encoders.Add(new JObject(e)));
            container.Add("RotaryEncoder", encoders);
            JObject knobs = JObject.FromObject(d.knbData);
            container.Add("Knobs", knobs);
            return container;
        }

        /// <summary>
        /// Load an HardwareDescription from file
        /// <note type="note">This method is unused</note>
        /// </summary>
        /// <returns>An HardwareDescription object containing the file's content</returns>
        public static HardwareDescription Deserialize()
        {
            using JsonReader reader = new JsonTextReader(File.OpenText(HardwareDescriptionFile));
            JsonSerializer serializer = new JsonSerializer();
            return serializer.Deserialize<HardwareDescription>(reader);
        }
    }
}
