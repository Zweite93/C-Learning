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
using Microsoft.Practices.Unity;

namespace Notepad
{
    public partial class PluginManager : Form
    {
        private IPluginPresenter _pluginPresenter;
        public IChangesInfo _changesInfo;
        public Dictionary<string, Assembly> Plugins { get; private set; }

        public PluginManager(Dictionary<string, Assembly> plugins)
        {
            InitializeComponent();
            Plugins = plugins;

            foreach (var plugin in plugins)
            {
                ListOfPlugins.Items.Add(plugin.Key);
            }

            _changesInfo = ContainerForUnity.MainContainer.Resolve<IChangesInfo>();
            _pluginPresenter = (PluginPresenter)(ContainerForUnity.MainContainer.Resolve<IPluginPresenter>(
                new ResolverOverride[]
                    {
                        new ParameterOverride("pluginLoader", ContainerForUnity.MainContainer.Resolve<IPluginsLoader>())
                    }));
        }

        private void AddPluginCickEventHandler(object sender, EventArgs e)
        {
            IPluginInfo pluginInfo = _pluginPresenter.Load();

            if (pluginInfo == null)
            {
                MessageBox.Show("Incorrect plugin.", "Error.", MessageBoxButtons.OK);
                return;
            }

            if (ListOfPlugins.Items.Contains(pluginInfo.PluginName))
            {
                MessageBox.Show("Plugin already loaded", "Error.", MessageBoxButtons.OK);
                return;
            }

            _changesInfo.Added.Add(pluginInfo.PluginName);
            Plugins.Add(pluginInfo.PluginName, pluginInfo.PluginAssemby);
            ListOfPlugins.Items.Add(pluginInfo.PluginName);
        }

        private void RemovePluginCickEventHandler(object sender, EventArgs e)
        {
            if (ListOfPlugins.SelectedItem == null)
                return;

            string selectedPluginName = ListOfPlugins.SelectedItem.ToString();

            if (_changesInfo.Added.Contains(selectedPluginName))
                _changesInfo.Added.Remove(selectedPluginName);
            else
                _changesInfo.Removed.Add(selectedPluginName);

            Plugins.Remove(selectedPluginName);
            ListOfPlugins.Items.Remove(ListOfPlugins.SelectedItem);
        }
    }
}
