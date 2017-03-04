using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class NotepadForm : Form
    {
        private NotepadHandler _notepadHandlerInstance;
        private Settings _settings;
        private bool _contentHasBeenChanged;

        public NotepadForm(NotepadHandler notepadHandlerInstance)
        {
            InitializeComponent();
            _notepadHandlerInstance = notepadHandlerInstance;
            _settings = _notepadHandlerInstance.LoadSettings();
            ChangeFontSize(_settings.FontSize);
        }

        private DialogResult AskIfWantToSave()
        {
            var messageBoxResult = MessageBox.Show("Save your changes before exit?", "Save changes?", MessageBoxButtons.YesNoCancel);
            if (messageBoxResult == DialogResult.Yes)
            {
                _notepadHandlerInstance.Save(mainTextBox.Text);
            }
            return messageBoxResult;
        }

        private void Clear()
        {
            mainTextBox.Clear();
            _notepadHandlerInstance = new NotepadHandler(new FileSystemSaver(), new FileSystemSettingsSaver());
        }

        private void SubscribeContentChangesTracking(bool subscribe)
        {
            if (subscribe)
                mainTextBox.TextChanged += TextChangedEventHandler;
            else
                mainTextBox.TextChanged -= TextChangedEventHandler;
            _contentHasBeenChanged = !subscribe;
        }

        private void ChangeFontSize(float fontSize)
        {
            mainTextBox.Font = new Font(mainTextBox.Font.FontFamily, fontSize);
        }

        private void NewClickEventHandler(object sender, EventArgs e)
        {
            if (_contentHasBeenChanged)
                if (AskIfWantToSave() != DialogResult.Cancel)
                {
                    Clear();
                    SubscribeContentChangesTracking(true);
                }
        }

        private void SaveClickEventHandler(object sender, EventArgs e)
        {
            if (_notepadHandlerInstance.Save(mainTextBox.Text) == Result.Saved)
                if (_contentHasBeenChanged)
                    SubscribeContentChangesTracking(true);
        }

        private void SaveAsClickEventHandler(object sender, EventArgs e)
        {
            if (_notepadHandlerInstance.SaveAs(mainTextBox.Text) == Result.Saved)
                if (_contentHasBeenChanged)
                    SubscribeContentChangesTracking(true);
        }

        private void LoadClickEventHandler(object sender, EventArgs e)
        {
            if (_contentHasBeenChanged)
                if (AskIfWantToSave() == DialogResult.Cancel)
                    return;

            string textFromLoadMethod = _notepadHandlerInstance.Load();
            if (textFromLoadMethod != null)
            {
                mainTextBox.Text = textFromLoadMethod;
                if (_contentHasBeenChanged)
                    SubscribeContentChangesTracking(true);
                mainTextBox.TextChanged += TextChangedEventHandler;
            }
        }

        private void FontClickEventHandler(object sender, EventArgs e)
        {
            var dialogInstance = new FontSizeDialog(mainTextBox.Font.Size);
            dialogInstance.ShowDialog();
            if (dialogInstance.DialogResult == DialogResult.OK)
            {
                ChangeFontSize(dialogInstance.FontSize);
                _settings.FontSize = dialogInstance.FontSize;
                _notepadHandlerInstance.SaveSettings(_settings);
            }
        }

        private void TextChangedEventHandler(object sender, EventArgs e)
        {
            SubscribeContentChangesTracking(false);
        }

        private void NotepadFormClosingEventHandler(object sender, FormClosingEventArgs e)
        {
            if (_contentHasBeenChanged)
                if (AskIfWantToSave() == DialogResult.Cancel)
                    e.Cancel = true;
        }
    }
}
