using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    static class ContainerForIoCContainer
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
            ContainerForIoCContainer.MainContainer = new IoCContainer();
            ContainerForIoCContainer.MainContainer.Register<ITextSaver, FileSystemSaver>();
            ContainerForIoCContainer.MainContainer.Register<ISettingsSaver, FileSystemSettingsSaver>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NotepadForm());
        }

    }
}
