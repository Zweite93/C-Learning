using Notepad.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Notepad
{
    public interface INotepadPresenter
    {
        Dictionary<string, MethodInfo> Plugins { get; set; }
        Settings Settings { get; set; }

        Result Save();
        Result SaveAs();
        Result Load();
        void SaveSettings();
        void LoadSettings();
        void Clear();
        void ExecutePluginWork(string pluginName);
    }

    class NotepadPresenter : INotepadPresenter
    {
        private bool _isNew;
        private ITextSaver _textSaver;
        private ISettingsSaver _settingsSaver;
        private INotepadView _notepadView;
        public Dictionary<string, MethodInfo> Plugins { get; set; }

        public Settings Settings { get; set; }

        public NotepadPresenter(ITextSaver textSaver, ISettingsSaver settingsSaver, INotepadView notepadView)
        {
            _isNew = true;
            _textSaver = textSaver;
            _settingsSaver = settingsSaver;
            _notepadView = notepadView;
            Plugins = new Dictionary<string, MethodInfo>();
            LoadSettings();
        }

        public Result Save()
        {
            if (_textSaver.Save(_isNew, _notepadView.MainTextBoxText) == Result.Saved)
            {
                _isNew = false;
                return Result.Saved;
            }
            return Result.NotSaved;

        }

        public Result SaveAs()
        {
            if (_textSaver.Save(true, _notepadView.MainTextBoxText) == Result.Saved)
            {
                _isNew = false;
                return Result.Saved;
            }
            return Result.NotSaved;
        }

        public Result Load()
        {
            string loadResult = _textSaver.Load();
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
            _settingsSaver.Save(Settings);
        }

        public void LoadSettings()
        {
            Settings loadResult = _settingsSaver.Load();
            if (loadResult != null)
                Settings = loadResult;
            else
                Settings = new Settings();
        }

        public void Clear()
        {
            _isNew = true;
        }

        public void ExecutePluginWork(string pluginName)
        {
            _notepadView.MainTextBoxText = Plugins[pluginName].Invoke(null, new object[] { _notepadView.MainTextBoxText }).ToString();
        }
    }
}
