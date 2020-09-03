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

using ControllizerCore.Input.Action;
using ControllizerCore.Utils;

namespace ControllizerDeckProject.Core.Input
{
    public class Knob
    {
        public const string PotentiometerIdentifier = "K";

        public int ComponentIdentifier { get; private set; }
        public int PotentiometerValue { get; private set; }
        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }

        public DigitalInputActionBase action;

        public Knob(int id, int min = 0, int max = 1023)
        {
            ComponentIdentifier = id;
            MinValue = min;
            MaxValue = max;
        }

        public void UpdateValue(int readValue)
        {
            PotentiometerValue = readValue.MapRange(0, MinValue, 1023, MaxValue);
            if (action != null)
                action.Execute(); //give action some data
        }
    }
}
