using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using Notepad.Data;
using Notepad.Data.NHibernate;

namespace Notepad
{
    static class ContainerForUnity
    {
        public static UnityContainer MainContainer
        {
            get;
            set;
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            ContainerForUnity.MainContainer = new UnityContainer();
            ContainerForUnity.MainContainer.RegisterType<ITextSaver, DBSystemSaver>();
            ContainerForUnity.MainContainer.RegisterType<ISettingsSaver, FileSystemSettingsSaver>();
            ContainerForUnity.MainContainer.RegisterType<INotepadPresenter, NotepadPresenter>();
            ContainerForUnity.MainContainer.RegisterType<IPluginsLoader, PluginsLoader>();
            ContainerForUnity.MainContainer.RegisterType<IPluginExecutor, PluginExecutor>();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NotepadForm());
        }

    }
}
