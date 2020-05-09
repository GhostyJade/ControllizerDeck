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

using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace ControllizerDeckProject.Utils
{
    public static class SettingsManager
    {
        public static async Task SaveSettingsAsync(Settings s, string filename)
        {
            using (FileStream fs = File.Create(filename))
            {
                await JsonSerializer.SerializeAsync(fs, s);
            }
        }

        public static void SaveSettings(Settings s, string filename)
        {
            string json = JsonSerializer.Serialize(s);
            File.WriteAllText(filename, json);
        }

        public static void LoadSettings()
        {

        }
    }
}
