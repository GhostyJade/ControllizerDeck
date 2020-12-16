﻿/*
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
    /// <summary>
    /// This class provide an abstraction for implementing an action for an hardware digital input
    /// </summary>
    public abstract class DigitalInputActionBase
    {
        /// <summary>
        /// The Action name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The Action type
        /// </summary>
        public DigitalActionType Type { get; private set; }

        public DigitalInputActionBase(string name, DigitalActionType type) { Name = name; Type = type; }

        /// <summary>
        /// Called when the action is initialized
        /// </summary>
        public abstract void Init();

        /// <summary>
        /// Called when the action is executed
        /// </summary>
        public abstract void Execute();
    }
}