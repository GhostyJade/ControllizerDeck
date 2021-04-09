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

using System.Collections.Generic;

namespace ControllizerCore.Net
{
    /// <summary>
    /// Utility class used to manage HTTP Actions
    /// </summary>
    public static class ActionManager
    {
        private static readonly Dictionary<string, ActionBase> actions = new();

        /// <summary>
        /// Register an HTTP Action
        /// </summary>
        /// <param name="a">the HTTP action instance to register</param>
        public static void RegisterAction(ActionBase a)
        {
            actions.Add(a.ActionName, a);
        }

        /// <summary>
        /// Get a list containing all POST actions
        /// </summary>
        /// <returns>A list of HTTP POST Actions</returns>
        public static List<ActionBase> GetPOSTActions()
        {
            List<ActionBase> a = new();
            foreach (ActionBase action in actions.Values)
            {
                if (action.ActionType == ActionBase.HTTPType.POST)
                    a.Add(action);
            }
            return a;
        }


        /// <summary>
        /// Get a list containing all GET actions
        /// </summary>
        /// <returns>A list of HTTP GET Actions</returns>
        public static List<ActionBase> GetGETActions()
        {
            List<ActionBase> a = new();
            foreach (ActionBase action in actions.Values)
            {
                if (action.ActionType == ActionBase.HTTPType.GET)
                    a.Add(action);
            }
            return a;
        }
    }
}
