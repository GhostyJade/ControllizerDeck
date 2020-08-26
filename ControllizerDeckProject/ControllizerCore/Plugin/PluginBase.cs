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

namespace ControllizerCore.Plugin
{
    /// <summary>
    /// This class is used to define an instantiatable plugin for the backend.
    /// A plugin is used to expand basic features of this app (add custom actions, expand hardware support, ...)
    /// </summary>
    public abstract class PluginBase
    {
        /// <summary>
        /// The plugin name
        /// </summary>
        public string PluginName { get; private set; }
        /// <summary>
        /// The plugin version
        /// </summary>
        public string PluginVersion { get; private set; }

        protected PluginBase(string name, string version)
        {
            PluginName = name;
            PluginVersion = version;
        }

        /// <summary>
        /// This method is called when the plugin is initialized
        /// </summary>
        public abstract void InitPlugin();
        /// <summary>
        /// This method is called when the plugin must be executed
        /// </summary>
        public abstract void ExecutePlugin();
        /// <summary>
        /// This method is called when the app is closing. Use this if the plugin need to destroy stuff or store data
        /// </summary>
        public abstract void DestroyPlugin();
    }
}
