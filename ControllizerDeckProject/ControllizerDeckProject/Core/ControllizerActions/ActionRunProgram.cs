using System;
using System.Diagnostics;

namespace ControllizerDeckProject.Core.ControllizerActions
{
    public class ActionRunProgram : InputActionBase
    {
        public string AppName = "";
        public string FullAppDirectory = "";

        public ActionRunProgram(string actionName) : base(actionName)
        { }

        public override void Execute()
        {
            var process = Process.Start(FullAppDirectory);
            if (process == null)
            {
                // throw error
                Console.WriteLine("Failed to start {0}", AppName);
            }
        }

        public override void Init()
        { }
    }
}
