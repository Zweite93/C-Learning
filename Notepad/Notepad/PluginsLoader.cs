using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Notepad
{
    public interface IPluginsLoader
    {
        PluginInfo Load();
    }

    public class PluginsLoader : IPluginsLoader
    {
        const int maxParameters = 1;
        public PluginInfo Load()
        {
            var openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Assemby|*.dll";
            openFileDialog.ShowDialog();
            Assembly assembly;
            if (!String.IsNullOrEmpty(openFileDialog.FileName))
                try
                {
                    assembly = Assembly.LoadFile(openFileDialog.FileName);
                }
                catch(Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Incorrect plugin.", "Error.", System.Windows.Forms.MessageBoxButtons.OK);
                    return null;
                }
            else
                return null;

            Type executerType = assembly.GetExportedTypes().FirstOrDefault<Type>(r => r.Name == "Executer");
            if (executerType == null)
            {
                System.Windows.Forms.MessageBox.Show("Incorrect plugin.", "Error.", System.Windows.Forms.MessageBoxButtons.OK);
                return null;
            }

            MethodInfo pluginExecuter = executerType.GetMethod("ExecutePluginWork", BindingFlags.Public | BindingFlags.Static);
            if (pluginExecuter == null || pluginExecuter.ReturnType != typeof(string))
            {
                System.Windows.Forms.MessageBox.Show("Incorrect plugin.", "Error.", System.Windows.Forms.MessageBoxButtons.OK);
                return null;
            }

            ParameterInfo[] pluginExecuterParameters = pluginExecuter.GetParameters();
            if (pluginExecuterParameters.Length > maxParameters || pluginExecuterParameters.FirstOrDefault<ParameterInfo>(r => r.ParameterType == typeof(string)) == null)
            {
                System.Windows.Forms.MessageBox.Show("Incorrect plugin.", "Error.", System.Windows.Forms.MessageBoxButtons.OK);
                return null;
            }

            PropertyInfo pinfo = executerType.GetProperty("PluginName", BindingFlags.Public | BindingFlags.Static);
            if (pinfo == null)
                return new PluginInfo(assembly.FullName, pluginExecuter);

            string pluginName;
            try
            {
                pluginName = pinfo.GetValue(null, null).ToString();
            }
            catch (Exception e)
            {
                return new PluginInfo(assembly.FullName, pluginExecuter);
            }

            return new PluginInfo(pluginName, pluginExecuter);
        }
    }
}
