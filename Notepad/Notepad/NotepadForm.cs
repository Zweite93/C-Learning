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
        private bool _contentHasBeenChanged;


        public NotepadForm()
        {
            InitializeComponent();
            notepadHandlerInstance = new NotepadHandler(new FileSystemSaver());
        }

        private DialogResult AskIfWantToSave()
        {
            var messageBoxResult = MessageBox.Show("Save your changes before exit?", "Save changes?", MessageBoxButtons.YesNoCancel);
            if (messageBoxResult == DialogResult.Yes)
            {
                notepadHandlerInstance.Save(textBox1.Text);
            }
            return messageBoxResult;
        }

        private void Clear()
        {
            textBox1.Clear();
            notepadHandlerInstance = new NotepadHandler(new FileSystemSaver());
        }

        private void SubscribeContentChangesTracking(bool subscribe)
        {
            if (subscribe)
                textBox1.TextChanged += TextChangedEventHandler;
            else
                textBox1.TextChanged -= TextChangedEventHandler;
            _contentHasBeenChanged = !subscribe;
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
            if (notepadHandlerInstance.Save(textBox1.Text) == Result.Saved)
                if (_contentHasBeenChanged)
                    SubscribeContentChangesTracking(true);
        }

        private void SaveAsClickEventHandler(object sender, EventArgs e)
        {
            if (notepadHandlerInstance.SaveAs(textBox1.Text) == Result.Saved)
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
                textBox1.Text = textFromLoadMethod;
                if (_contentHasBeenChanged)
                    SubscribeContentChangesTracking(true);
                textBox1.TextChanged += TextChangedEventHandler;
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
