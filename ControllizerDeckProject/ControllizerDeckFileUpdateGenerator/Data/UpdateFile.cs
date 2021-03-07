using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Security.Cryptography;

namespace ControllizerDeck.FileUpdateGenerator.Data
{
    public class UpdateFile
    {
        public string filename;
        public string sha1File;

        public UpdateFile(string path, string rootPath)
        {
            filename = path.Replace(rootPath, "");
            GetDateAsSha1(path);
        }

        private void GetDateAsSha1(string path)
        {
            using (var sha1 = SHA1.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    sha1File = BitConverter.ToString(sha1.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        public static implicit operator JObject(UpdateFile f)
        {
            return new JObject
            {
                { "Filename" , f.filename},
                { "Hash", f.sha1File }
            };
        }
    }
}
