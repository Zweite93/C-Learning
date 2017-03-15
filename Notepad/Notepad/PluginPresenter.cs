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
        Dictionary<string, Assembly> Load();
        void Remove(string pluginName);
    }

    public class PluginPresenter : IPluginPresenter
    {
        private IPluginsLoader _pluginLoader;
        private IPluginExecutor _pluginExecutor;
        private Dictionary<string, Assembly> _plugins;

        public PluginPresenter(IPluginsLoader pluginLoader, IPluginExecutor pluginExecutor)
        {
            _pluginLoader = pluginLoader;
            _pluginExecutor = pluginExecutor;
            _plugins = new Dictionary<string, Assembly>();
        }

        public Dictionary<string, Assembly> Load()
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
                return null;
            }

            _plugins.Add(pluginName, assembly);
        }

        public void Remove(string pluginName)
        {
            _plugins.Remove(pluginName);
        }
    }
}
