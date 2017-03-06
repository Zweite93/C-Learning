using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Notepad
{
    public interface ISettingsSaver
    {
        void Save(Settings settings);
        Settings Load();
    }

    public class FileSystemSettingsSaver : ISettingsSaver
    {
        private const string DefaultFileName = "./settings.json";

        public void Save(Settings settings)
        {
            string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(DefaultFileName, json);
        }

        public Settings Load()
        {
            if (File.Exists(DefaultFileName))
                return JsonConvert.DeserializeObject<Settings>(File.ReadAllText(DefaultFileName));
            else
                return null;
        }
    }
}
