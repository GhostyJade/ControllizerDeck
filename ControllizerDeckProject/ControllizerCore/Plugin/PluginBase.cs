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

namespace ControllizerCore.Plugin
{
    public abstract class PluginBase
    {
        public string PluginName { get; private set; }
        public string PluginVersion { get; private set; }

        protected PluginBase(string name, string version)
        {
            PluginName = name;
            PluginVersion = version;
        }

        public abstract void InitPlugin();
        public abstract void ExecutePlugin();
        public abstract void DestroyPlugin();
    }
}