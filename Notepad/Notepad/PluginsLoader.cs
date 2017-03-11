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
        Assembly Load();
    }

    public class PluginsLoader : IPluginsLoader
    {
        public Assembly Load()
        {
            var openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Assemby|*.dll";
            openFileDialog.ShowDialog();
            if (!String.IsNullOrEmpty(openFileDialog.FileName))
                return Assembly.LoadFile(openFileDialog.FileName);
            else
                return null;
        }
    }
}
