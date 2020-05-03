using System;
using System.Threading;

namespace ControlizerCore.Serial
{

    /// <summary>
    /// This class manage communication with a serial device (such as an Arduino)
    /// </summary>
    public class SerialManager
    {
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
            SerialIO.PortName = "COM6"; //TODO this should changed to a selectable value
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
                    Console.WriteLine(msg); //Return somewhere and use this values
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString()); //TODO better exceptions
                }
            }
        }
    }
}
