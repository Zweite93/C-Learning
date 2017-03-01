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
    public partial class FontSizeDialog : Form
    {
        public float FontSizeValue { get; private set; }

        public FontSizeDialog()
        {
            InitializeComponent();
        }
        

        private void OKClickEventHandler(object sender, EventArgs e)
        {
            float tempFloatForTryParse;
            Single.TryParse(FontSizeTextBox.Text, out tempFloatForTryParse);
            if (tempFloatForTryParse > 0)
            {
                FontSizeValue = tempFloatForTryParse;
                this.Close();
                DialogResult =  DialogResult.OK;
            }
            else
                MessageBox.Show("Incorrect font size", "Error", MessageBoxButtons.OK);
        }

        private void CanсelClickEventHandler(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
