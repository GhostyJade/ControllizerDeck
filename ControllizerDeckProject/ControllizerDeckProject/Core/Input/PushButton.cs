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

namespace ControllizerDeckProject.Core.Input
{
    /// <summary>
    /// A PushButton is a button that can represent a bool value (true if pressed, false if not pressed)
    /// </summary>
    public class PushButton
    {
        /// <summary>
        /// The push button generic identifier
        /// </summary>
        public const string PushButtonIdentifier = "PB";
        
        /// <summary>
        /// <see langword="true"/> if pressed, false otherwise
        /// </summary>
        public bool IsPressed { get; private set; }
        
        /// <summary>
        /// The push button identifier
        /// </summary>
        public int Identifier { get; private set; }

        public InputActionBase AssociatedAction;

        public PushButton(int id)
        {
            Identifier = id;
        }

        /// <summary>
        /// Update the push button state
        /// </summary>
        /// <param name="value">The new button state</param>
        public void UpdateState(bool value)
        {
            IsPressed = value;
            if (IsPressed) 
                AssociatedAction.Execute();
        }
    }
}
