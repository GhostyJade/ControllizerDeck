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

using ControllizerDeckProject.Core;
using ControllizerDeckProject.Utils;

using System.Net;

namespace ControllizerDeckProject.Net.Actions
{
    /// <summary>
    /// Path: /hardware/
    /// Method: GET
    /// 
    /// This function is used to send the hardware description to the client.
    /// </summary>
    public class ActionGetHardwareComponents : ActionBase
    {
        public ActionGetHardwareComponents() : base("GetHardwareComponents", "/hardware/", HTTPType.GET)
        { }

        public override void OnGet(HttpListenerRequest request, HttpListenerResponse response)
        {
            ResponseFactory.GenerateResponse(response, InputDispatcher.ObjectsToJSON());
        }
    }
}
