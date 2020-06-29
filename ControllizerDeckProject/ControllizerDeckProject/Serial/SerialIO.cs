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
using System.IO.Ports;

namespace ControlizerCore.Serial
{
    /// <summary>
    /// This class provide a level of abstraction for serial communication.
    /// </summary>
    public class SerialIO
    {
        /// <summary>
        /// Singleton instance
        /// </summary>
        private static SerialIO instance;
        /// <summary>
        /// The serial port baudrate
        /// </summary>
        public static int BaudRate { get; set; }

        /// <summary>
        /// The serial port name
        /// </summary>
        public static string PortName { get; set; }

        /// <summary>
        /// Return a singleton of this class.
        /// </summary>
        /// <returns>The SerialIO instance</returns>
        public static SerialIO GetInstance()
        {
            if (instance == null)
                instance = new SerialIO();
            return instance;
        }

        /// <summary>
        /// The SerialPort instance
        /// </summary>
        private SerialPort serial;

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A System.Collections.Generic.List of string containing the names of the available connected serial devices </returns>
        public static List<string> GetPortNames()
        {
            return new List<string>(SerialPort.GetPortNames());
        }

        /// <summary>
        /// Initialize a serial port using the specified PortName and BaudRate.
        /// This MUST be called before calling <see cref="Listen()"/>
        /// </summary>
        public void Init()
        {
            serial = new SerialPort(PortName, BaudRate);
        }

        /// <summary>
        /// Open serial communication for the specified Port
        /// You MUST call <see cref="Init()"/> before calling this method
        /// </summary>
        public void Listen()
        {
            if (!serial.IsOpen)
                serial.Open();
        }

        /// <summary>
        /// Read a line (terminated by \n) from the serial and return it
        /// </summary>
        /// <returns>a string containing the readed line</returns>
        public string Read() => serial.ReadLine();

        /// <summary>
        /// Write message to the serial port
        /// </summary>
        /// <param name="msg">The message string terminated by "\n"</param>
        public void Write(string msg)
        {
            serial.WriteLine(msg);
        }

        /// <summary>
        /// Close the Serial port instance
        /// </summary>
        public void Close()
        {
            serial.Close();
        }

        /// <summary>
        /// Return <see langword="true"/> if serial communication is open, <see langword="false"/> otherwise
        /// </summary>
        /// <returns><see langword="true"/> if serial communication is open, <see langword="false"/> otherwise</returns>
        public bool Active()
        {
            return serial.IsOpen;
        }


    }
}
