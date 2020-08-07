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

using Newtonsoft.Json;

using System;
using System.IO;

namespace ControllizerDeckProject.Utils
{
    /// <summary>
    /// Class used to manage settings data (creation, save, load)
    /// </summary>
    public static class SettingsManager
    {
        /// <summary>
        /// Settings file name
        /// </summary>
        private const string SettingsFileName = "settings.json";

        /// <summary>
        /// 
        /// </summary>
        private const string SettingsPath = "Data";

        /// <summary>
        /// Check if settings file exists and create data folder if missing
        /// </summary>
        /// <returns><see langword="true"/> if settings were previously saved, false otherwise</returns>
        private static bool CheckSettingsData()
        {
            if (!Directory.Exists(AppContext.BaseDirectory + SettingsPath))
                Directory.CreateDirectory(AppContext.BaseDirectory + SettingsPath);
            if (File.Exists(string.Format("{0}/{1}/{2}", AppContext.BaseDirectory, SettingsPath, SettingsFileName)))
                return true;
            return false;
        }

        /// <summary>
        /// Save settings to file
        /// </summary>
        public static void SaveSettings()
        {
            SaveSettings(CoreState.SettingsInstance);
        }

        /// <summary>
        /// Save settings to file
        /// </summary>
        /// <param name="s">The settings instance</param>
        private static void SaveSettings(Settings s)
        {
            JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
            using (StreamWriter streamWriter = new StreamWriter(string.Format("{0}/{1}/{2}", AppContext.BaseDirectory, SettingsPath, SettingsFileName)))
            using (JsonWriter writer = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(writer, s);
            }
        }

        /// <summary>
        /// Load settings from file and store it's data in the CoreState instance
        /// </summary>
        public static void LoadSettings()
        {
            if (!CheckSettingsData())
            {
                CoreState.SettingsInstance = new Settings();
            }
            else
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamReader sr = new StreamReader(string.Format("{0}/{1}/{2}", AppContext.BaseDirectory, SettingsPath, SettingsFileName)))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    Settings settings = serializer.Deserialize<Settings>(reader);
                    //TODO Check COM validity
                    CoreState.SettingsInstance = settings;
                    SerialManager.ManagerInstance.Start();
                }
            }
        }
    }
}
