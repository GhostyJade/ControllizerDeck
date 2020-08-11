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

using System.Collections.Generic;

namespace ControllizerDeckProject.Core.Hardware
{
    /// <summary>
    /// This class provides the exact representation of the hardwareconfiguration.json file.
    /// Here, there are some struct to represent data for the file.
    /// 
    /// Note. If you want to get the file you must call the <see cref="Serialize"/> method
    /// </summary>
    public class HardwareDescription
    {
        public struct ButtonsData
        {
            public string type;
            public string layout;
            public string identifier;
            public int size;

            public override string ToString()
            {
                return string.Format("Type:{0}, Layout:{1}, Id:{2}, Size:{3}", type, layout, identifier, size);
            }
        }

        public struct KnobsData
        {
            public string identifier;
            public int size;

            public override string ToString()
            {
                return string.Format("Id:{0}, Size:{1}", identifier, size);
            }
        }

        public struct Encoder
        {
            public int Id;
            public bool HasButton;

            public override string ToString()
            {
                return string.Format("Id:{0}, HasButton{1}", Id, HasButton);
            }
        }

        public struct EncodersData
        {
            public List<Encoder> encoders;
            //TODO add identifiers for btn and encoder

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
