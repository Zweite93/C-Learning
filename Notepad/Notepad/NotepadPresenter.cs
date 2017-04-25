using Notepad.Data;
using Notepad.Models;
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
        private readonly ITextSaver _textSaver;
        private readonly ISettingsSaver _settingsSaver;
        private readonly INotepadView _notepadView;
        private Content _content;
        public Dictionary<string, MethodInfo> Plugins { get; set; }

        public Settings Settings { get; set; }

        public NotepadPresenter(ITextSaver textSaver, ISettingsSaver settingsSaver, INotepadView notepadView)
        {
            _isNew = true;
            _textSaver = textSaver;
            _settingsSaver = settingsSaver;
            _notepadView = notepadView;
            _content = new Content();
            Plugins = new Dictionary<string, MethodInfo>();
            LoadSettings();
        }

        public Result Save()
        {
            _content.Text = _notepadView.MainTextBoxText;
            if (_textSaver.Save(_isNew, _content) == Result.Saved)
            {
                _isNew = false;
                return Result.Saved;
            }
            return Result.NotSaved;

        }

        public Result SaveAs()
        {
            _content.Text = _notepadView.MainTextBoxText;
            if (_textSaver.Save(true, _content) == Result.Saved)
            {
                _isNew = false;
                return Result.Saved;
            }
            return Result.NotSaved;
        }

        public Result Load()
        {
            _content = _textSaver.Load();

            if (_content == null)
                return Result.NotLoaded;

            _isNew = false;
            _notepadView.MainTextBoxText = _content.Text;
            return Result.Loaded;

        }

        public void SaveSettings()
        {
            _settingsSaver.Save(Settings);
        }

        public void LoadSettings()
        {
            Settings loadResult = _settingsSaver.Load();
            Settings = loadResult ?? new Settings();
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
