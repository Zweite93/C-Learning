using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Notepad
{
    public class PluginInfo
    {
        public string PluginName { get; set; }
        public MethodInfo PluginExecuter { get; set; }
        public Result LoadResult { get; set; }
        public PluginInfo(string name, MethodInfo assembly)
        {
            PluginName = name;
            PluginExecuter = assembly;
        }
    }

    public class ChangesInfo
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
