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

using ControllizerDeckProject.Core;
using ControllizerDeckProject.Core.ControllizerActions;
using ControllizerDeckProject.Net;
using ControllizerDeckProject.Utils;

using System.Threading.Tasks;

namespace ControllizerDeckProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SettingsManager.LoadSettings();

            ActionManager.Init();
            var it = new Core.Hardware.HardwareCreator();
            it.PushButtons[0].AssociatedAction = new ActionRunProgram("blender") { FullAppDirectory = @"C:\Program Files\Blender Foundation\Blender 2.83\blender.exe" };
            InputDispatcher.RegisterHardware(it);
            HttpServer server = new HttpServer("localhost", 8080);
            Task listen = server.Listen();
            listen.GetAwaiter().GetResult();
        }
    }
}
