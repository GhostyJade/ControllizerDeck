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

using ControllizerDeckProject.Utils;

using System.Net;

namespace ControllizerDeckProject.Net.Actions
{

    /// <summary>
    /// Path: /firstlaunch/
    /// Method: GET
    /// 
    /// This action return a bool that indicate if the application has already been initialized before or not
    /// 
    /// See: <seealso cref="Settings.IsFirstLaunch"/> <seealso cref="ActionWelcome"/>
    /// </summary>
    public class ActionFirstLaunch : ActionBase
    {
        public ActionFirstLaunch() : base("ActionIsFirstLaunch", "/firstlaunch/", HTTPType.GET)
        { }

        public override void OnGet(HttpListenerRequest request, HttpListenerResponse response)
        {
            ResponseFactory.GenerateResponse(response, "{\"status\":" + CoreState.SettingsInstance.IsFirstLaunch.ToString().ToLower() + "}");
        }
    }
}
