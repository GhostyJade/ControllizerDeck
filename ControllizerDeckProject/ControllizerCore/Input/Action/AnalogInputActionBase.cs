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

using ControllizerCore.Input.Types;

namespace ControllizerCore.Input.Action
{
    public abstract class AnalogInputActionBase
    {
        public string Name { get; private set; }
        public AnalogActionType ActionType { get; private set; }

        public AnalogInputActionBase(string Name, AnalogActionType ActionType)
        {
            this.Name = Name;
            this.ActionType = ActionType;
        }

        public abstract void Init();
        public abstract void Execute(decimal value);
    }
}
