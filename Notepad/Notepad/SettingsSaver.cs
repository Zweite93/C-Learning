using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Notepad
{
    public interface ISettingsSaver<T>
    {
        void Save(T settings);
        T Load();
    }

    public class FileSystemSettingsSaver : ISettingsSaver<Settings>
    {
        private const string DefaultFileName = "./settings.json";
        public FileSystemSettingsSaver()
        {

        }

        public void Save(Settings settings)
        {
            string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(DefaultFileName, json);
        }

        public Settings Load()
        {
            return JsonConvert.DeserializeObject<Settings>(File.ReadAllText(DefaultFileName));
        }
    }
}
