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

using System.Collections.Generic;

namespace ControllizerDeckProject.Core.Hardware
{
    /// <summary>
    /// This class provides the exact representation of the hardwareconfiguration.json file.
    /// Here, there are some struct to represent data for the file.
    /// 
    /// Note. If you want to get the file content, you must call the <see cref="HardwareDataManager.Serialize(HardwareDescription)"/> method
    /// </summary>
    public class HardwareDescription
    {
        /// <summary>
        /// The button data object
        /// </summary>
        public struct ButtonsData
        {
            /// <summary>
            /// The button configuration type (matrix or list)
            /// </summary>
            public string type;
            /// <summary>
            /// If the <see cref="type"/> is "matrix", this represent the layout of the matrix (like 3x2)
            /// </summary>
            public string layout;
            /// <summary>
            /// The pushbutton identifier (default is "PB")
            /// </summary>
            public string identifier;
            /// <summary>
            /// The button count
            /// </summary>
            public int size;

            public override string ToString()
            {
                return string.Format("Type:{0}, Layout:{1}, ButtonIdentifier:{2}, Size:{3}", type, layout, identifier, size);
            }
        }

        /// <summary>
        /// The knob data object
        /// </summary>
        public struct KnobsData
        {
            /// <summary>
            /// The knob identifier (default is "K")
            /// </summary>
            public string identifier;
            /// <summary>
            /// The knob count
            /// </summary>
            public int size;

            public override string ToString()
            {
                return string.Format("KnobIdentifier:{0}, Size:{1}", identifier, size);
            }
        }

        public struct Encoder
        {
            /// <summary>
            /// The encoder id
            /// </summary>
            public int Id;
            /// <summary>
            /// If <see langword="true"/>, the encoder has a button, <see langword="false"/> otherwise.
            /// </summary>
            public bool HasButton;
            /// <summary>
            /// 
            /// </summary>

            public override string ToString()
            {
                return string.Format("Id:{0}, HasButton: {1}", Id, HasButton);
            }
        }

        public struct EncodersData
        {
            public List<Encoder> encoders;

            public string encoderIdentifier;
            public string encoderButtonIdentifier;

            public override string ToString()
            {
                return encoders.ToString();
            }
        }

        public ButtonsData btnData;
        public KnobsData knbData;
        public EncodersData encData;
    }
}
