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

using ControllizerDeckProject.Net.Actions;
using System.Collections.Generic;

namespace ControllizerDeckProject.Net
{
    /// <summary>
    /// Util class used to manage HTTP Actions
    /// </summary>
    public static class ActionManager
    {
        public static Dictionary<string, ActionBase> actions = new Dictionary<string, ActionBase>();

        public static void Init()
        {
            RegisterAction(new ActionExit());
            RegisterAction(new ActionAvailablePorts());
            RegisterAction(new ActionSetCOMPort());
            RegisterAction(new ActionGetHardwareComponents());
            RegisterAction(new ActionSetHardwareFunctions());
            RegisterAction(new ActionFirstLaunch());
            RegisterAction(new ActionWelcome());
        }

        /// <summary>
        /// Register an HTTP Action
        /// </summary>
        /// <param name="a">the HTTP action instance to register</param>
        public static void RegisterAction(ActionBase a)
        {
            actions.Add(a.ActionURI, a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A list of HTTP POST Actions</returns>
        public static List<ActionBase> GetPOSTActions()
        {
            List<ActionBase> a = new List<ActionBase>();
            foreach (ActionBase action in actions.Values)
            {
                if (action.ActionType == ActionBase.HTTPType.POST)
                    a.Add(action);
            }
            return a;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns>A list of HTTP GET Actions</returns>
        public static List<ActionBase> GetGETActions()
        {
            List<ActionBase> a = new List<ActionBase>();
            foreach (ActionBase action in actions.Values)
            {
                if (action.ActionType == ActionBase.HTTPType.GET)
                    a.Add(action);
            }
            return a;
        }
    }
}
