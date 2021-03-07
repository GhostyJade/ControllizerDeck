using Terminal.Gui;

namespace ControllizerDeck.FileUpdateGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Application.Init();
            var top = Application.Top;

            ConsoleManager manager = new ConsoleManager();
            manager.Init(top);
            Application.Run();
        }
    }
}
