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
        private ISettingsSaver _settingsSaveMethod;

        public NotepadHandler(ITextSaver saveMethod, ISettingsSaver settingsSaveMethod)
        {
            _isNew = true;
            _saveMethod = saveMethod;
            _settingsSaveMethod = settingsSaveMethod;

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
            if (_saveMethod.Save(true, Text) == Result.Saved)
            {
                _isNew = false;
                return Result.Saved;
            }
            return Result.NotSaved;
        }

        public string Load()
        {
            _isNew = true;
            return _saveMethod.Load();
        }

        public void SaveSettings(Settings settings)
        {
            _settingsSaveMethod.Save(settings);
        }

        public Settings LoadSettings()
        {
            return _settingsSaveMethod.Load();
        }
    }
}
