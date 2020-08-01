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
    public class HardwareDataManager
    {
        private const string HardwareDescriptionFile = "Data/Hardware/hardwaredescription.json";
        private const string ActionDataFile = "Data/Hardware/actionmapping.json";

        public string MatrixLayout { get; private set; }

        /// <summary>
        /// A list of PushButtons
        /// </summary>
        public List<PushButton> PushButtons { get; private set; } = new List<PushButton>();

        /// <summary>
        /// A list of Rotary Encoders
        /// </summary>
        public List<RotaryEncoder> RotaryEncoders { get; private set; } = new List<RotaryEncoder>();

        /// <summary>
        /// A list of Knobs
        /// </summary>
        public List<Knob> Knobs { get; private set; } = new List<Knob>();

        /// <summary>
        /// Create an Hardware mapping from a raw json string
        /// </summary>
        /// <param name="jsonHardwareData">the hardware json description string</param>
        public HardwareDataManager(string jsonHardwareData)
        {
            ParseJson(jsonHardwareData);
        }

        /// <summary>
        /// Load an Hardware mapping from file
        /// </summary>
        public HardwareDataManager()
        {
            ParseJson(LoadFromFile());
        }

        private string LoadFromFile()
        {
            if (!File.Exists(AppContext.BaseDirectory + HardwareDescriptionFile))
                throw new FileNotFoundException(HardwareDescriptionFile);
            return File.ReadAllText(AppContext.BaseDirectory + HardwareDescriptionFile);
        }

        private void ParseJson(string jsonData)
        {
            JToken data = JToken.Parse(jsonData);
            JObject pushButtonObj = (JObject)data.SelectToken("PushButton");
            string type = (string)pushButtonObj.SelectToken("type");
            string identifier = (string)pushButtonObj.SelectToken("identifier");
            if (identifier != null)
            {
                PushButton.UpdateIdentifier(identifier);
            }
            //check what type of pushbutton the hardware has
            if (type == "list")
            {
                JArray btn = (JArray)pushButtonObj.SelectToken("buttons");
                for (int i = 0; i < btn.Count; i++)
                {
                    int id = (int)btn[i].SelectToken("id");
                    PushButtons.Add(new PushButton(id));
                }
            }
            else if (type == "matrix")
            {
                InputDispatcher.HasInitializedAsMatrix = true;
                MatrixLayout = (string)pushButtonObj.SelectToken("layout");
                int count = (int)pushButtonObj.SelectToken("size");
                for (int i = 0; i < count; i++)
                {
                    PushButtons.Add(new PushButton(i));
                }
            }
            else
            {
                //log unknown type
            }

            JArray rotEnc = (JArray)data.SelectToken("RotaryEncoder");
            for (int i = 0; i < rotEnc.Count; i++)
            {
                int id = (int)rotEnc[i].SelectToken("id");
                bool hasButton = (bool)rotEnc[i].SelectToken("hasButton");
                RotaryEncoders.Add(new RotaryEncoder(id, hasButton));
            }

            JObject knobsObj = (JObject)data.SelectToken("Knobs");
            int knobsCount = (int)knobsObj.SelectToken("size");
            for(int i = 0; i < knobsCount; i++)
            {
                Knobs.Add(new Knob(i));
            }
        }

        private class ActionDataMapping
        {
            public int id;
            public InputActionBase action;
        }

        public void StoreMapping()
        {
            List<ActionDataMapping> rawData = new List<ActionDataMapping>();
            PushButtons.ForEach(e =>
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
    }
}
