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
    public interface INotepadView
    {
        string MainTextBoxText { get; set; }
    }

    public partial class NotepadForm : Form, INotepadView
    {
        private NotepadPresenter _notepadPresenter;
        private bool ContentHasBeenChanged { get; set; }

        public string MainTextBoxText
        {
            get { return mainTextBox.Text; }
            set { mainTextBox.Text = value; }
        }

        public NotepadForm(INotepadModel notepadModel)
        {
            InitializeComponent();
            _notepadPresenter = new NotepadPresenter(notepadModel, this);
            ChangeFontSize(_notepadPresenter.Settings.FontSize);
        }

        private DialogResult AskIfWantToSave()
        {
            var messageBoxResult = MessageBox.Show("Save your changes before exit?", "Save changes?", MessageBoxButtons.YesNoCancel);
            if (messageBoxResult == DialogResult.Yes)
            {
                _notepadPresenter.Save();
            }
            return messageBoxResult;
        }

        private void SubscribeContentChangesTracking(bool subscribe)
        {
            if (subscribe)
                mainTextBox.TextChanged += TextChangedEventHandler;
            else
                mainTextBox.TextChanged -= TextChangedEventHandler;
            ContentHasBeenChanged = !subscribe;
        }

        private void ChangeFontSize(float fontSize)
        {
            mainTextBox.Font = new Font(mainTextBox.Font.FontFamily, fontSize);
        }

        private void NewClickEventHandler(object sender, EventArgs e)
        {
            if (ContentHasBeenChanged)
                if (AskIfWantToSave() != DialogResult.Cancel)
                {
                    mainTextBox.Text = _notepadPresenter.Clear();
                    SubscribeContentChangesTracking(true);
                }
        }

        private void SaveClickEventHandler(object sender, EventArgs e)
        {
            if (_notepadPresenter.Save() == Result.Saved)
                if (ContentHasBeenChanged)
                    SubscribeContentChangesTracking(true);
        }

        private void SaveAsClickEventHandler(object sender, EventArgs e)
        {
            if (_notepadPresenter.SaveAs() == Result.Saved)
                if (ContentHasBeenChanged)
                    SubscribeContentChangesTracking(true);
        }

        private void LoadClickEventHandler(object sender, EventArgs e)
        {
            if (ContentHasBeenChanged)
                if (AskIfWantToSave() == DialogResult.Cancel)
                    return;

            string textFromLoadMethod = _notepadPresenter.Load();
            if (textFromLoadMethod != null)
            {
                mainTextBox.Text = textFromLoadMethod;
                if (ContentHasBeenChanged)
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
                _notepadPresenter.Settings.FontSize = dialogInstance.FontSize;
                _notepadPresenter.SaveSettings();
            }
        }

        private void TextChangedEventHandler(object sender, EventArgs e)
        {
            SubscribeContentChangesTracking(false);
        }

        private void NotepadFormClosingEventHandler(object sender, FormClosingEventArgs e)
        {
            if (ContentHasBeenChanged)
                if (AskIfWantToSave() == DialogResult.Cancel)
                    e.Cancel = true;
        }
    }
}
