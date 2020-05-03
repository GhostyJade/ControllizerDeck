using ControlizerCore.Serial;
using System;

namespace ControllizerDeckProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SerialManager manager = new SerialManager();
            manager.Start();
        }
    }
}
