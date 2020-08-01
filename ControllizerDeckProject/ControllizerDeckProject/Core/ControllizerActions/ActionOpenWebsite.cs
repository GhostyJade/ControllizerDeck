using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ControllizerDeckProject.Core.ControllizerActions
{
    public class ActionOpenWebsite : DigitalInputActionBase
    {
        private string websiteUri;

        public ActionOpenWebsite(string websiteUri) : base("OpenWebsite", EventTypeMapping.OpenWebsite)
        {
            this.websiteUri = websiteUri;
            Init();
        }

        public override void Execute()
        {
            try
            {

                Process.Start(websiteUri);
            }
            catch
            { //NOTE: LINUX AND MACOS NOT YET TESTED
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    websiteUri = websiteUri.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {websiteUri}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start(new ProcessStartInfo("xdg-open", websiteUri));
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start(new ProcessStartInfo("open", websiteUri));
                }
                else
                {
                    throw;
                }
            }
        }

        public override void Init()
        {
            if (!websiteUri.StartsWith("http") || !websiteUri.StartsWith("www"))
                websiteUri = "www." + websiteUri;
            Console.WriteLine(websiteUri);
        }
    }
}
