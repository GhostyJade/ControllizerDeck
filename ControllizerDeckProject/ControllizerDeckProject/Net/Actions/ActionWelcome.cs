using System.Net;

namespace ControllizerDeckProject.Net.Actions
{
    /// <summary>
    /// This class is used to create the hardwaredescription file by the frontend
    /// </summary>
    public class ActionWelcome : ActionBase
    {
        public ActionWelcome() : base("ActionWelcome", "/welcome/", HTTPType.POST)
        { }

        public override void OnPost(HttpListenerRequest request, HttpListenerResponse response)
        {

        }
    }
}
