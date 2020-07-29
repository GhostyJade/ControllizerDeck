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

using ControllizerDeckProject.Core.Hardware;
using ControllizerDeckProject.Core.Input;
using ControllizerDeckProject.Utils;

using Newtonsoft.Json;

using System;

namespace ControllizerDeckProject.Core
{
    /// <summary>
    /// Provides some methods to trigger input events from Serial communication
    /// </summary>
    public static class InputDispatcher
    {
        public static bool HasInitializedAsMatrix = false;//TODO move to initialization data (static class)
        private static HardwareDataManager InputEvents { get; set; } 

        /// <summary>
        /// Assign to a PushButton an action
        /// </summary>
        /// <param name="id">the PushButton id</param>
        /// <param name="action">the PushButton new action</param>
        public static void UpdatePushButtonAction(int id, InputActionBase action)
        {
            InputEvents.PushButtons.Find(e => e.Identifier == id).AssociatedAction = action;
        }

        /// <summary>
        /// Set the hardware representation from an existing object
        /// </summary>
        /// <param name="instance"></param>
        public static void RegisterHardware(HardwareDataManager instance)
        {
            InputEvents = instance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A string containing the hardware description data.</returns>
        public static string ObjectsToJSON()
        {
            return JsonConvert.SerializeObject(InputEvents, Formatting.Indented);
        }

        /// <summary>
        /// Perform action based on Serial input
        /// </summary>
        /// <param name="msg">The Serial input message</param>
        public static void PerformAction(string msg)
        {
            string[] data = msg.Split(':');
            string id = data[0];
            string state = data[1];
            //PushButtonEvent
            if (id.StartsWith(PushButton.PushButtonIdentifier))
            {
                if (!HasInitializedAsMatrix)
                {
                    int btnId = int.Parse(id.Replace(PushButton.PushButtonIdentifier, ""));
                    PushButton btn = InputEvents.PushButtons.Find(e => e.Identifier == btnId);
                    btn.UpdateState(MathHelper.BoolFromInt(int.Parse(state)));
                    Console.WriteLine(btn.Identifier + " " + btn.IsPressed);
                }
                else
                {
                    int i = 0;
                    foreach (char c in state.TrimEnd())
                    {
                        // Update PushButton's state for each button
                        PushButton btn = InputEvents.PushButtons.Find(e => e.Identifier == i);
                        btn.UpdateState(MathHelper.BoolFromChar(c));
                        i++;
                    }
                }
            }
            else if (id.StartsWith(RotaryEncoder.RotaryEncoderIdentifier)) //Encoder events
            {
                int encId = int.Parse(id.Replace(RotaryEncoder.RotaryEncoderIdentifier, ""));
                RotaryEncoder enc = InputEvents.RotaryEncoders.Find(e => e.ComponentIdentifier == encId);
                enc.UpdateValue(long.Parse(state));
            }
            else if (id.StartsWith(RotaryEncoder.RotaryEncoderButtonIdentifier))
            {
                int encId = int.Parse(id.Replace(RotaryEncoder.RotaryEncoderButtonIdentifier, ""));
                RotaryEncoder enc = InputEvents.RotaryEncoders.Find(e => e.ComponentIdentifier == encId);
                enc.UpdateButtonState(MathHelper.BoolFromInt(int.Parse(state)));
            }
            else
            {
                Console.WriteLine(msg);
            }
        }

        public static void UpdateActionMappingFile()
        {
            InputEvents.StoreMapping();
        }
    }
}
