using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Notepad.Data;
using Notepad.Data.NHibernate;
using Notepad.Models;

namespace Notepad
{
    public class FileSystemSaver : ITextSaver
    {
        private string _filePath;

        public Result Save(bool isNew, Content content)
        {
            if (isNew)
            {
                var dialog = new SaveFileDialog();
                dialog.Filter = "Text file|*.txt";
                dialog.ShowDialog();
                _filePath = dialog.FileName;
            }
            if (!String.IsNullOrEmpty(_filePath))
            {
                File.WriteAllText(_filePath, content.Text);
                return Result.Saved;
            }
            return Result.NotSaved;
        }

        public Content Load()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Text file|*.txt";
            dialog.ShowDialog();
            if (!String.IsNullOrEmpty(dialog.FileName))
                return new Content() { Text = File.ReadAllText(dialog.FileName) };
            else
                return null;
        }
    }
}
