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

namespace ControllizerCore.Utils
{
    /// <summary>
    /// This class provides some useful Math related methods
    /// </summary>
    public static class MathHelper
    {
        /// <summary>
        /// Get value from mapped range
        /// </summary>
        /// <param name="value">the value to map</param>
        /// <param name="fromSource">map min source value</param>
        /// <param name="toSource">map max source value</param>
        /// <param name="fromTarget">map min target value</param>
        /// <param name="toTarget">map max target value</param>
        /// <returns>the mapped value</returns>
        public static decimal MapRange(this decimal value, decimal fromSource, decimal toSource, decimal fromTarget, decimal toTarget)
        {
            return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
        }

        /// <summary>
        /// Get value from mapped range
        /// </summary>
        /// <param name="value">the value to map</param>
        /// <param name="fromSource">map min source value</param>
        /// <param name="toSource">map max source value</param>
        /// <param name="fromTarget">map min target value</param>
        /// <param name="toTarget">map max target value</param>
        /// <returns>the mapped value</returns>
        public static int MapRange(this int value, int fromSource, int toSource, int fromTarget, int toTarget)
        {
            return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
        }

        /// <summary>
        /// Convert int to bool
        /// </summary>
        /// <param name="value">the int value (0 or 1)</param>
        /// <returns>the bool representation</returns>
        /// <exception cref="Exception">if number is invalid</exception>
        public static bool BoolFromInt(int value)
        {
            if (value == 0) return false;
            else if (value == 1) return true;
            else throw new Exception("Invalid number value");
        }

        /// <summary>
        /// Convert char to bool
        /// </summary>
        /// <param name="value">the char value ('0' or '1')</param>
        /// <returns>the bool representation</returns>
        /// <exception cref="Exception">if number is invalid</exception>
        public static bool BoolFromChar(char value)
        {
            if (value == '0') return false;
            else if (value == '1') return true;
            else throw new Exception("Invalid number value");
        }
    }
}
