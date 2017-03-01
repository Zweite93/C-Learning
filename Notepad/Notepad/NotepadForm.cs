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
        private NotepadHandler notepadHandlerInstance;
        private Settings settings;
        private bool _contentHasBeenChanged;

        public NotepadForm()
        {
            InitializeComponent();
            notepadHandlerInstance = new NotepadHandler(new FileSystemSaver(), new FileSystemSettingsSaver());
            settings = notepadHandlerInstance.LoadSettings();
            ChangeFontSize(settings.FontSize);
        }

        private DialogResult AskIfWantToSave()
        {
            var messageBoxResult = MessageBox.Show("Save your changes before exit?", "Save changes?", MessageBoxButtons.YesNoCancel);
            if (messageBoxResult == DialogResult.Yes)
            {
                notepadHandlerInstance.Save(mainTextBox.Text);
            }
            return messageBoxResult;
        }

        private void Clear()
        {
            mainTextBox.Clear();
            notepadHandlerInstance = new NotepadHandler(new FileSystemSaver(), new FileSystemSettingsSaver());
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
            if (notepadHandlerInstance.Save(mainTextBox.Text) == Result.Saved)
                if (_contentHasBeenChanged)
                    SubscribeContentChangesTracking(true);
        }

        private void SaveAsClickEventHandler(object sender, EventArgs e)
        {
            if (notepadHandlerInstance.SaveAs(mainTextBox.Text) == Result.Saved)
                if (_contentHasBeenChanged)
                    SubscribeContentChangesTracking(true);
        }

        private void LoadClickEventHandler(object sender, EventArgs e)
        {
            if (_contentHasBeenChanged)
                if (AskIfWantToSave() == DialogResult.Cancel)
                    return;

            string textFromLoadMethod = notepadHandlerInstance.Load();
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
                settings.FontSize = dialogInstance.FontSize;
                notepadHandlerInstance.SaveSettings(settings);
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
