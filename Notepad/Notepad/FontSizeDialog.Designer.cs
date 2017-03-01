namespace Notepad
{
    partial class FontSizeDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FontSizeTextBox = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.CanсelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FontSizeTextBox
            // 
            this.FontSizeTextBox.Location = new System.Drawing.Point(12, 12);
            this.FontSizeTextBox.MaxLength = 4;
            this.FontSizeTextBox.Name = "FontSizeTextBox";
            this.FontSizeTextBox.Size = new System.Drawing.Size(71, 20);
            this.FontSizeTextBox.TabIndex = 0;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(12, 42);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(71, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKClickEventHandler);
            // 
            // CanсelButton
            // 
            this.CanсelButton.Location = new System.Drawing.Point(121, 42);
            this.CanсelButton.Name = "CanсelButton";
            this.CanсelButton.Size = new System.Drawing.Size(71, 23);
            this.CanсelButton.TabIndex = 2;
            this.CanсelButton.Text = "Сancel";
            this.CanсelButton.UseVisualStyleBackColor = true;
            this.CanсelButton.Click += new System.EventHandler(this.CanсelClickEventHandler);
            // 
            // FontSizeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 77);
            this.Controls.Add(this.CanсelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.FontSizeTextBox);
            this.Name = "FontSizeDialog";
            this.Text = "Font";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FontSizeTextBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CanсelButton;
    }
}