﻿using System;
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
        NotSaved,
        Loaded,
        NotLoaded
    }
    public interface ITextSaver
    {
        Result Save(bool isNew, string text);
        string Load();
    }

    public class FileSystemSaver : ITextSaver
    {
        private string _filePath;

        public Result Save(bool isNew, string text)
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

        public string Load()
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
