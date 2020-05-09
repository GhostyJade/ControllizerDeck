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
    public static class ActionManager
    {
        public static Dictionary<string, ActionBase> actions = new Dictionary<string, ActionBase>();

        public static void INIT()
        {
            RegisterAction(new ActionExit());
        }

        public static void RegisterAction(ActionBase a)
        {
            actions.Add(a.ActionURI, a);
        }

        public static List<ActionBase> GetPOSTActions()
        {
            List<ActionBase> a = new List<ActionBase>(); //I know that this is stupid and impact on performances...but I don't care :3
            foreach (ActionBase action in actions.Values)
            {
                if (action.ActionType == ActionBase.HTTPType.POST)
                    a.Add(action);
            }
            return a;
        }

        public static List<ActionBase> GetGETActions()
        {
            List<ActionBase> a = new List<ActionBase>(); //I know that this is stupid and impact on performances, again...but I don't care :3
            foreach (ActionBase action in actions.Values)
            {
                if (action.ActionType == ActionBase.HTTPType.GET)
                    a.Add(action);
            }
            return a;
        }
    }
}
