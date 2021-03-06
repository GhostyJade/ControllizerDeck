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

namespace ControllizerDeckProject.Utils
{
    /// <summary>
    /// The settings class
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// The COM port value
        /// </summary>
        public string COMPort { get; set; } = string.Empty;

        /// <summary>
        /// The Local port on which the server listen to
        /// </summary>
        public int LocalServerPort { get; set; } = 8192;

        /// <summary>
        /// The Local address on which the server listen to
        /// </summary>
        public string LocalServerAddress { get; set; } = "localhost";

        /// <summary>
        /// If <see langword="true"/>, the backend await to load the mapping and prepare the configuration instead
        /// </summary>
        public bool IsFirstLaunch { get; set; } = true;

        public bool useWifi { get; set; } = false;
        public int WifiServerPort { get; set; } = 5001;
    }
}
