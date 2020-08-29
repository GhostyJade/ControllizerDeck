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

using ControllizerDeckProject.Net;
using ControllizerDeckProject.Utils;

using System.Threading.Tasks;

namespace ControllizerDeckProject
{
    public class Program
    {
#pragma warning disable IDE0060 // Remove unused parameter
        public static void Main(string[] args)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            // TODO add debug modifiers to tweak stuff while debugging

            // Load app settings:
            SettingsManager.LoadSettings();
            // Init all HTTP actions
            ActionManager.Init();

            if (!CoreState.SettingsInstance.IsFirstLaunch)
            {
                HardwareHelper.InitHardware();
            }
            else
            {
                ConsoleManager.LogInfo("Waiting for hardware initialization.");
            }

            // Server initialization:
            HttpServer server = new HttpServer(CoreState.SettingsInstance.LocalServerAddress, CoreState.SettingsInstance.LocalServerPort);
            Task listen = server.Listen();
            listen.GetAwaiter().GetResult();
        }
    }
}
