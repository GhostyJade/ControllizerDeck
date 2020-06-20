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

using ControllizerDeckProject;
using ControllizerDeckProject.Core;

using System;
using System.Threading;

namespace ControlizerCore.Serial
{

    /// <summary>
    /// This class manage communication with a serial device (such as an Arduino)
    /// </summary>
    public class SerialManager : IDisposable
    {
        private static SerialManager instance;
        public static SerialManager ManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SerialManager();
                    CoreState.AddDisposable(instance.Dispose);
                }
                return instance;
            }
        }

        /// <summary>
        /// The thread on which the program listen data to
        /// </summary>
        private Thread serialThread;

        /// <summary>
        /// Initialize the SerialIO instance and start the listening thread
        /// </summary>
        public void Start()
        {
            //Create setters for these properties
            SerialIO.BaudRate = 9600;
            SerialIO.PortName = CoreState.COMPort;
            SerialIO.GetInstance().Init();
            SerialIO.GetInstance().Listen();
            serialThread = new Thread(Listen);
            serialThread.Start();
        }

        /// <summary>
        /// Listen on the serial port while the SerialIO instance is open
        /// </summary>
        private void Listen()
        {
            while (SerialIO.GetInstance().Active())
            {
                try
                {
                    string msg = SerialIO.GetInstance().Read();
                    InputDispatcher.PerformAction(msg);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString()); //TODO better exceptions
                }
            }
        }

        public void Dispose()
        {
            SerialIO.GetInstance().Close();
        }
    }
}
