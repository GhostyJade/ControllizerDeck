using System;
using System.Collections.Generic;
using System.Text;

namespace ControllizerDeckProject.Net.Actions
{
    public class ActionExit : ActionBase
    {
        public ActionExit() : base("exit", "/exit/", HTTPType.POST)
        { }

        public override void Execute()
        {
            Console.WriteLine("called exit");
        }
    }
}
