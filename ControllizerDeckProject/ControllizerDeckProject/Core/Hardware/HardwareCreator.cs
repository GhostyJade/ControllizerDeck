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

using Newtonsoft.Json.Linq;

using System.Collections.Generic;

namespace ControllizerDeckProject.Core.Hardware
{
    public class HardwareCreator
    {
        public List<PushButton> PushButtons { get; private set; } = new List<PushButton>();
        public List<RotaryEncoder> RotaryEncoders { get; private set; } = new List<RotaryEncoder>();

        public HardwareCreator(string jsonHardwareData)
        {
            ParseJson(jsonHardwareData);
        }

        private void ParseJson(string jsonData)
        {
            JToken data = JToken.Parse(jsonData);
            JArray btn = (JArray)data.SelectToken("PushButton");
            for (int i = 0; i < btn.Count; i++)
            {
                int id = (int)btn[i].SelectToken("id");
                PushButtons.Add(new PushButton(id));
            }

            JArray rotEnc = (JArray)data.SelectToken("RotaryEncoder");
            for (int i = 0; i < rotEnc.Count; i++)
            {
                int id = (int)rotEnc[i].SelectToken("id");
                bool hasButton = (bool)rotEnc[i].SelectToken("hasButton");
                RotaryEncoders.Add(new RotaryEncoder(id, hasButton));
            }
        }
    }
}
