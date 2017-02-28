using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notepad
{
    public enum Result
    {
        Saved,
        NotSaved
    }
    abstract class TextSaver
    {
        public abstract Result Save(bool isNew, string text);
        public abstract Result SaveAs(string text);
        public abstract string Load();
    }

    class FileSystemSaver : TextSaver
    {
        private string _filePath; // just test

        public override Result Save(bool isNew, string text)
        {
            if (isNew)
            {
                var dialog = new SaveFileDialog();
                dialog.ShowDialog();
                _filePath = dialog.FileName;
            }
            if (!String.IsNullOrEmpty(_filePath))
            {
                File.WriteAllText(_filePath, text);
                return Result.Saved;
            }
            return Result.NotSaved;
        }

        public override Result SaveAs(string text)
        {
            return Save(true, text);
        }

        public override string Load()
        {
            var dialog = new OpenFileDialog();
            dialog.ShowDialog();
            if (!String.IsNullOrEmpty(dialog.FileName))
                return File.ReadAllText(dialog.FileName);
            else
                return null;
        }
    }
}
