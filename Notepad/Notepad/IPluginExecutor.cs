using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Notepad
{
    public interface IPluginExecutor
    {
        string Execute(Assembly plugin);
    }

    public class PluginExecutor : IPluginExecutor
    {
        public string Execute(Assembly plugin)
        {
            return "";
        }
    }

}
