using ControllizerDeckProject.Core;
using ControllizerDeckProject.Core.Hardware;

using Newtonsoft.Json;

using System;
using System.IO;

namespace ControllizerDeckProject.Utils
{
    public static class HardwareHelper
    {
        private const string HardwareDescriptionFile = "Data/Hardware/hardwaredescription.json";

        public static void InitHardware()
        {
            HardwareDataManager hardware = new HardwareDataManager();
            HardwareAction actions = new HardwareAction(hardware);
            InputDispatcher.RegisterHardware(actions.HardwareCreator());
        }

        public static void StoreConfiguration(HardwareDescription description)
        {
            JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
            using (StreamWriter writer = new StreamWriter(string.Format("{0}/{1}", AppContext.BaseDirectory, HardwareDescriptionFile)))
            using (JsonWriter jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, description.Serialize());
            }
        }
    }
}
