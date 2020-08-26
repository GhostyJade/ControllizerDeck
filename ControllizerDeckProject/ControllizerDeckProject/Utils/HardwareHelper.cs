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
using ControllizerDeckProject.Core.Hardware;

using Newtonsoft.Json;

using System;
using System.IO;

namespace ControllizerDeckProject.Utils
{
    /// <summary>
    /// This class provides some functions used to manage the Hardware's data. Currently provides methods to initialize and store data
    /// </summary>
    public static class HardwareHelper
    {
        /// <summary>
        /// The default (and only one) description file
        /// </summary>
        private const string HardwareDescriptionFile = "Data/Hardware/hardwaredescription.json";

        /// <summary>
        /// Load the hardware data and maps existing functions with the hardware
        /// </summary>
        public static void InitHardware()
        {
            HardwareData hardware = HardwareDataManager.LoadData();
            HardwareAction actions = new HardwareAction(hardware);
            InputDispatcher.RegisterHardware(actions.HardwareCreator());
        }

        /// <summary>
        /// Store the hardware configuration into it's file
        /// </summary>
        /// <param name="description">the hardware description instance</param>
        public static void StoreConfiguration(HardwareDescription description)
        {
            if (!Directory.Exists(AppContext.BaseDirectory + "Data/Hardware/"))
                Directory.CreateDirectory(AppContext.BaseDirectory + "Data/Hardware/");

            JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
            using (StreamWriter writer = new StreamWriter(string.Format("{0}/{1}", AppContext.BaseDirectory, HardwareDescriptionFile)))
            using (JsonWriter jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, HardwareDataManager.Serialize(description));
            }
        }
    }
}
