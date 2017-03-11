using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Notepad
{
    public partial class PluginManagerForm : Form
    {
        private IPluginsLoader _pluginsLoader;
        public PluginManagerForm(IPluginsLoader pluginsLoader)
        {
            InitializeComponent();
            _pluginsLoader = pluginsLoader;
        }

        private void AddPluginCickEventHandler(object sender, EventArgs e)
        {
            var assembly = _pluginsLoader.Load();
            var types = assembly.GetExportedTypes();
            MethodInfo method;

            foreach (var type in types)
            {
                method = type.GetMethod("ExecutePluginWork");
                if (method != null)
                    break;
            }
        }
    }
}
