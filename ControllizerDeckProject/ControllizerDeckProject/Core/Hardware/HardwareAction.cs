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

using ControllizerDeckProject.Core.ControllizerActions;

using Newtonsoft.Json.Linq;

using System;
using System.IO;

namespace ControllizerDeckProject.Core.Hardware
{
    public class HardwareAction
    {
        private const string ActionDataFile = "Data/Hardware/actionmapping.json";

        private HardwareDataManager instance;

        public HardwareAction(HardwareDataManager descriptorInstance)
        {
            instance = descriptorInstance;
            DispatchHardwareFragment();
        }

        private void DispatchHardwareFragment(string data)
        {
            JToken jsonData = JToken.Parse(data);

            JArray btn = (JArray)jsonData.SelectToken("PushButton");
            for (int i = 0; i < btn.Count; i++)
            {
                int id = (int)btn[i].SelectToken("id");
                var action = btn[i].SelectToken("action");
                Console.WriteLine(action.ToString());
                if (action != null)
                    switch ((int)action.SelectToken("Type"))
                    {
                        case (int)EventTypeMapping.LaunchApp:
                            instance.PushButtons.Find(e => e.Identifier == id).AssociatedAction = action.ToObject<ActionRunProgram>();
                            break;
                    }
            }
        }

        private bool CheckFileExistance()
        {
            return File.Exists(AppContext.BaseDirectory + ActionDataFile);
        }

        private string LoadFromFile()
        {
            return File.ReadAllText(AppContext.BaseDirectory + ActionDataFile);
        }

        private void DispatchHardwareFragment()
        {
            if (CheckFileExistance())
                DispatchHardwareFragment(LoadFromFile());
        }

        public HardwareDataManager HardwareCreator()
        {
            return instance;
        }
    }
}
