using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Linq;

namespace ControllizerDeckUpdater
{
    class Program
    {
        public const string RemotePath = "https://controllizer-deck.ghostyjade.com/version";
        public const string RemoteFilesList = "version.json";
        public const string RemoteFilesPath = "files";

        private static HttpClient client = new HttpClient();

        private static async Task Run()
        {
            // Get file list
            var result = await client.GetAsync($"{RemotePath}/{RemoteFilesList}");
            if (result.IsSuccessStatusCode)
            {
                var fileData = JObject.Parse(await result.Content.ReadAsStringAsync());
                using (var sha1 = SHA1.Create())
                {
                    foreach (JObject obj in fileData.SelectToken("Files").ToObject<JArray>())
                    {
                        string filename = obj.SelectToken("Filename").ToString();
                        string filehash = obj.SelectToken("Hash").ToString();
                        // File doesn't exists. Download it.
                        if (!File.Exists(Environment.CurrentDirectory + filename))
                        {
                            string targetDirectory = Path.GetDirectoryName(Environment.CurrentDirectory + filename);
                            if (!Directory.Exists(targetDirectory))
                                Directory.CreateDirectory(targetDirectory);
                            try
                            {
                                using (FileStream fs = new FileStream(Environment.CurrentDirectory + filename, FileMode.Create))
                                {
                                    var fileResult = await client.GetAsync($"{RemotePath}/{RemoteFilesPath}/{filename}");
                                    if (fileResult.IsSuccessStatusCode)
                                        await fileResult.Content.CopyToAsync(fs);
                                    // TODO handle error
                                }
                            }
                            catch (IOException e)
                            {
                                Console.WriteLine("Skipped {0}", e.Message);
                            }
                        }
                        // File exists. Compare it to the current production version and if it's new, download it
                        else
                        {
                            using (var filestream = File.OpenRead(Environment.CurrentDirectory + filename))
                            {
                                if (!BitConverter.ToString(sha1.ComputeHash(filestream)).Replace("-", "").ToLowerInvariant().Equals(filehash))
                                {
                                    File.Delete(filename);
                                    using (FileStream fs = new FileStream(Environment.CurrentDirectory + filename, FileMode.Create))
                                    {
                                        var fileResult = await client.GetAsync($"{RemotePath}/{RemoteFilesPath}/{filename}");
                                        if (fileResult.IsSuccessStatusCode)
                                            await fileResult.Content.CopyToAsync(fs);
                                        // TODO handle error
                                    }
                                }
                                // Otherwise file is the same and should be skipped
                            }
                        }
                    }
                }
                // TODO Check if some file has been deleted and remove the local versions
            }
            // TODO else : manage request failed
        }

        public static void Main(string[] args)
        {
            Run().GetAwaiter().GetResult();
        }
    }
}
