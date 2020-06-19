using System;

namespace ControllizerDeckProject.Utils
{
    public static class ConsoleManager
    {
        public static void LogError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
