using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    static class Container
    {
        public static IoCContainer MainContainer
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
            Container.MainContainer = new IoCContainer();
            Container.MainContainer.Register<ITextSaver, FileSystemSaver>();
            Container.MainContainer.Register<ISettingsSaver, FileSystemSettingsSaver>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NotepadForm(new NotepadHandler(Container.MainContainer.Create<ITextSaver>(), (Container.MainContainer.Create<ISettingsSaver>()))));
        }

    }
}
