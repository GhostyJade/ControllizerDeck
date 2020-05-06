using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace ControllizerDeckProject.Utils
{
    public static class SettingsManager
    {
        public static async Task SaveSettingsAsync(Settings s, string filename)
        {
            using (FileStream fs = File.Create(filename))
            {
                await JsonSerializer.SerializeAsync(fs, s);
            }
        }

        public static void SaveSettings(Settings s, string filename)
        {
            string json = JsonSerializer.Serialize(s);
            File.WriteAllText(filename, json);
        }

        public static void LoadSettings()
        {

        }
    }
}
