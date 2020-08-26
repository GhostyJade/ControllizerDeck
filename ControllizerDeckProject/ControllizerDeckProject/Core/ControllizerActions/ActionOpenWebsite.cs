using ControllizerDeckProject.Core.ControllizerActions.Types;

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ControllizerDeckProject.Core.ControllizerActions
{
    public class ActionOpenWebsite : DigitalInputActionBase
    {
        public string WebsiteName;
        public string WebsiteUri;

        public ActionOpenWebsite() : base("OpenWebsite", DigitalActionType.OpenWebsite)
        { }

        public override void Execute()
        {
            try
            {
                Process.Start(WebsiteUri);
            }
            catch
            { //NOTE: LINUX AND MACOS NOT YET TESTED
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    WebsiteUri = WebsiteUri.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {WebsiteUri}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start(new ProcessStartInfo("xdg-open", WebsiteUri));
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start(new ProcessStartInfo("open", WebsiteUri));
                }
                else
                {
                    throw;
                }
            }
        }

        public override void Init()
        {
            if (!WebsiteUri.StartsWith("www"))
                WebsiteUri = "www." + WebsiteUri;
        }
    }
}
