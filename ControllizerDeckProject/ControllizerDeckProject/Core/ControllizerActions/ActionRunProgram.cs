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

using System;
using System.Diagnostics;

namespace ControllizerDeckProject.Core.ControllizerActions
{
    /// <summary>
    /// This type of action is called when user want to launch an application (.exe file).
    /// </summary>
    public class ActionRunProgram : InputActionBase
    {
        /// <summary>
        /// The applicaton name
        /// </summary>
        public string AppName = "";
        
        /// <summary>
        /// The application path
        /// </summary>
        public string FullAppDirectory = "";

        public ActionRunProgram(string actionName) : base(actionName, EventTypeMapping.LaunchApp)
        { }

        public override void Execute()
        {
            var process = Process.Start(FullAppDirectory);
            if (process == null)
            {
                // throw error
                Console.WriteLine("Failed to start {0}", AppName);
            }
        }

        public override void Init()
        { }
    }
}
