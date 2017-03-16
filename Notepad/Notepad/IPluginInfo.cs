using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Notepad
{
    public interface IPluginInfo
    {
        string PluginName { get; set; }
        Assembly PluginAssemby { get; set; }
    }

    public interface IChangesInfo
    {
        List<string> Added { get; set; }
        List<string> Removed { get; set; }
    }

    public class PluginInfo : IPluginInfo
    {
        public string PluginName { get; set; }
        public Assembly PluginAssemby { get; set; }
        public PluginInfo(string name, Assembly assembly)
        {
            PluginName = name;
            PluginAssemby = assembly;
        }
    }

    public class ChangesInfo : IChangesInfo
    {
        public List<string> Added { get; set; }
        public List<string> Removed { get; set; }

        public ChangesInfo() 
        {
            Added = new List<string>();
            Removed = new List<string>();
        }
    }
}
