using System;

namespace ControllizerDeckProject.Net.Actions
{
    public class ActionExit : ActionBase
    {
        public ActionExit() : base("exit", "/exit/", HTTPType.POST)
        { }

        public override void OnPost()
        {
            Console.WriteLine("called exit");
        }
    }
}
