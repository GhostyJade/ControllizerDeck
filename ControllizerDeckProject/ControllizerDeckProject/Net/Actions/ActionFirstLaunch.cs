using ControllizerDeckProject.Utils;

using System.Net;

namespace ControllizerDeckProject.Net.Actions
{
    public class ActionFirstLaunch : ActionBase
    {
        public ActionFirstLaunch() : base("ActionIsFirstLaunch", "/firstlaunch/", HTTPType.GET)
        { }

        public override void OnGet(HttpListenerRequest request, HttpListenerResponse response)
        {

            ResponseFactory.GenerateResponse(response, "{\"status\":false}");
        }
    }
}
