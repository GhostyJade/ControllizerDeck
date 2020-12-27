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

using ControllizerCore.Net.Actions;

using ControllizerDeckProject.Utils;

using System.Net;

namespace ControllizerDeckProject.Net.Actions
{
    /// <summary>
    /// Path: /exit/
    /// Method: POST
    /// 
    /// This function is called to kill the daemon.
    /// 
    /// </summary>
    public class ActionExit : ActionBase
    {
        public ActionExit() : base("exit", "/exit/", HTTPType.POST)
        { }

        public override void OnPost(HttpListenerRequest request, HttpListenerResponse response)
        {
            if (!CoreState.HasCloseRequested)
            {
                CoreState.HasCloseRequested = true; // TODO i should use this instead of closing the application directly

                string jsonResponse = "{\"result\":true}";
                ResponseFactory.GenerateResponse(response, jsonResponse);

                CoreState.DisposableElements.ForEach(e => e());

                SettingsManager.SaveSettings();

                // System.Environment.Exit(0); //TODO also, i have to close every thing that must be closed (serial, http server, etc)
                // Bug: if I use System.Env.exit, every method after this invocation is not called.
            }
        }
    }
}
