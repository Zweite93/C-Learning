namespace Notepad
{
    partial class PluginManagerForm
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
            this.ListOfPlugins = new System.Windows.Forms.ListBox();
            this.AddPluginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListOfPlugins
            // 
            this.ListOfPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListOfPlugins.FormattingEnabled = true;
            this.ListOfPlugins.Location = new System.Drawing.Point(12, 12);
            this.ListOfPlugins.Name = "ListOfPlugins";
            this.ListOfPlugins.Size = new System.Drawing.Size(448, 290);
            this.ListOfPlugins.TabIndex = 0;
            // 
            // AddPluginButton
            // 
            this.AddPluginButton.Location = new System.Drawing.Point(12, 305);
            this.AddPluginButton.Name = "AddPluginButton";
            this.AddPluginButton.Size = new System.Drawing.Size(75, 25);
            this.AddPluginButton.TabIndex = 1;
            this.AddPluginButton.Text = "Add";
            this.AddPluginButton.UseVisualStyleBackColor = true;
            this.AddPluginButton.Click += new System.EventHandler(this.AddPluginCickEventHandler);
            // 
            // PluginManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 342);
            this.Controls.Add(this.AddPluginButton);
            this.Controls.Add(this.ListOfPlugins);
            this.Name = "PluginManagerForm";
            this.Text = "Plugin Manager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListOfPlugins;
        private System.Windows.Forms.Button AddPluginButton;
    }
}