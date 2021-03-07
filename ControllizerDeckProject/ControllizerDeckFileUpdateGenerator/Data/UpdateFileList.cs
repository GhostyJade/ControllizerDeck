using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace ControllizerDeck.FileUpdateGenerator.Data
{
    public class UpdateFileList
    {
        private List<UpdateFile> files = new List<UpdateFile>();

        public void Add(UpdateFile f) => files.Add(f);

        public static implicit operator UpdateFileList(JObject o)
        {
            return new UpdateFileList { };
        }

        public JObject ConvertToJObject()
        {
            JArray filesList = new JArray();
            foreach (var item in files)
            {
                filesList.Add(item);
            }

            return new JObject
            {
                { "Files", filesList }
            };
        }
    }
}
