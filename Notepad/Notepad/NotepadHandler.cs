using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad
{
    public class NotepadHandler
    {
        private bool _isNew;
        private ITextSaver _saveMethod;

        public NotepadHandler(ITextSaver saveMethod)
        {
            _isNew = true;
            _saveMethod = saveMethod;

        }

        public Result Save(string Text)
        {
            if (_saveMethod.Save(_isNew, Text) == Result.Saved)
            {
                _isNew = false;
                return Result.Saved;
            }
            return Result.NotSaved;

        }

        public Result SaveAs(string Text)
        {
            if (_saveMethod.SaveAs(Text) == Result.Saved)
            {
                _isNew = false;
                return Result.Saved;
            }
            return Result.NotSaved;
        }

        public string Load()
        {
            return _saveMethod.Load();
            _isNew = true;
        }
    }
}
