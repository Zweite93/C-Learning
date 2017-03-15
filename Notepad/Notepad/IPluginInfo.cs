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
}
