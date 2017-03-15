using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Notepad
{
    public interface IPluginPresenter
    {
        IPluginInfo Load();
    }

    public class PluginPresenter : IPluginPresenter
    {
        private IPluginsLoader _pluginLoader;

        public PluginPresenter(IPluginsLoader pluginLoader)
        {
            _pluginLoader = pluginLoader;
        }

        public IPluginInfo Load()
        {
            var assembly = _pluginLoader.Load();
            if (assembly == null)
                return null;

            Type executerType;
            try
            {
                executerType = assembly.GetExportedTypes().First<Type>(r => r.Name == "Executer");
            }
            catch (Exception e)
            {
                return null;
            }

            if (executerType == null)
                return null;

            PropertyInfo pinfo = executerType.GetProperty("PluginName", BindingFlags.Public | BindingFlags.Static);
            if (pinfo == null)
                return null;

            string pluginName;
            try
            {
                pluginName = pinfo.GetValue(null, null).ToString();
            }
            catch (Exception e)
            {
                return new PluginInfo(assembly.FullName, assembly);
            }

            return new PluginInfo(pluginName, assembly);
        }
    }
}
