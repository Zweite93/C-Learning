using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad
{
    public interface INotepadPresenter
    {
        Result Save();
        Result SaveAs();
        Result Load();
        void SaveSettings();
        void LoadSettings();
        void Clear();
    }

    class NotepadPresenter : INotepadPresenter
    {
        private bool _isNew;
        private ITextSaver _saveMethod;
        private ISettingsSaver _settingsSaveMethod;
        private INotepadView _notepadView;

        public Settings Settings { get; private set; }

        public NotepadPresenter(ITextSaver saveMethod, ISettingsSaver settingsSaveMethod, INotepadView notepadView)
        {
            _isNew = true;
            _saveMethod = saveMethod;
            _settingsSaveMethod = settingsSaveMethod;
            _notepadView = notepadView;
            LoadSettings();
        }

        public Result Save()
        {
            if (_saveMethod.Save(_isNew, _notepadView.MainTextBoxText) == Result.Saved)
            {
                _isNew = false;
                return Result.Saved;
            }
            return Result.NotSaved;

        }

        public Result SaveAs()
        {
            if (_saveMethod.Save(true, _notepadView.MainTextBoxText) == Result.Saved)
            {
                _isNew = false;
                return Result.Saved;
            }
            return Result.NotSaved;
        }

        public Result Load()
        {
            string loadResult = _saveMethod.Load();
            if (loadResult != null)
            {
                _isNew = false;
                _notepadView.MainTextBoxText = loadResult;
                return Result.Loaded;
            }
            return Result.NotLoaded;
        }

        public void SaveSettings()
        {
            _settingsSaveMethod.Save(Settings);
        }

        public void LoadSettings()
        {
            Settings loadResult = _settingsSaveMethod.Load();
            if (loadResult != null)
                Settings = loadResult;
            else
                Settings = new Settings();
        }

        public void Clear()
        {
            _isNew = true;
        }
    }
}
