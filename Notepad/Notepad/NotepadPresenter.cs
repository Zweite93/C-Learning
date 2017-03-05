using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad
{
    class NotepadPresenter
    {
        private INotepadModel _notepadModel;
        private INotepadView _notepadView;
        public Settings Settings { get; private set; }

        public NotepadPresenter(INotepadModel notepadModel, INotepadView notepadView)
        {
            _notepadModel = notepadModel;
            _notepadView = notepadView;
            Settings = this.LoadSettings();
        }

        public string Clear()
        {
            _notepadModel.Clear();
            return "";
        }

        public Result Save()
        {
            return _notepadModel.Save(_notepadView.MainTextBoxText);
        }

        public Result SaveAs()
        {
            return _notepadModel.SaveAs(_notepadView.MainTextBoxText);
        }

        public string Load()
        {
            return _notepadModel.Load();
        }

        public void SaveSettings()
        {
            _notepadModel.SaveSettings(Settings);
        }

        public Settings LoadSettings()
        {
            return _notepadModel.LoadSettings();
        }
    }
}
