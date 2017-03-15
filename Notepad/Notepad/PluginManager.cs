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
        private IPluginInfo _pluginInfo;
        public PluginManager()
        {
            InitializeComponent();
            _pluginPresenter = (PluginPresenter)(ContainerForUnity.MainContainer.Resolve<IPluginPresenter>(
                new ResolverOverride[]
                    {
                        new ParameterOverride("pluginLoader", ContainerForUnity.MainContainer.Resolve<IPluginsLoader>())
                    }));
        }

        private void AddPluginCickEventHandler(object sender, EventArgs e)
        {
            //_pluginInfo = _pluginPresenter.Load();
            if (_pluginInfo == null)
            {
                MessageBox.Show("Incorrect plugin.", "Error.", MessageBoxButtons.OK);
                return;
            }
            ListOfPlugins.Items.Add(_pluginInfo.PluginName);
        }

        private void RemovePluginCickEventHandler(object sender, EventArgs e)
        {

        }
    }
}
