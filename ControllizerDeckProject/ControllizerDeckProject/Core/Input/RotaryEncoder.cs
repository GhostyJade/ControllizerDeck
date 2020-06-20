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
    public class RotaryEncoder
    {
        /// <summary>
        /// Set to <see langword="true"/> if the used rotary encoder has a push button
        /// </summary>
        public bool HasPushButton { get; private set; }

        /// <summary>
        /// Used to store if the push button is pressed or not
        /// </summary>
        public bool IsButtonActive { get; private set; }

        /// <summary>
        /// The component identifier
        /// </summary>
        public int ComponentIdentifier { get; private set; }

        /// <summary>
        /// The current encoder value
        /// </summary>
        public long EncoderValue { get; private set; }

        public RotaryEncoder(int id, bool hasButton)
        {
            ComponentIdentifier = id;
            HasPushButton = hasButton;
        }

    }
}
