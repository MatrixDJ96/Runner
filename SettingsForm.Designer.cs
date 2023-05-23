namespace Runner
{
    partial class SettingsForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.ExecutableLabel = new System.Windows.Forms.Button();
            this.ExecutableTextBox = new System.Windows.Forms.TextBox();
            this.ArgumentLabel = new System.Windows.Forms.Button();
            this.ArgumentTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExecutableLabel
            // 
            this.ExecutableLabel.AutoSize = true;
            this.ExecutableLabel.Location = new System.Drawing.Point(10, 5);
            this.ExecutableLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.ExecutableLabel.Name = "ExecutableLabel";
            this.ExecutableLabel.Padding = new System.Windows.Forms.Padding(5);
            this.ExecutableLabel.Size = new System.Drawing.Size(85, 35);
            this.ExecutableLabel.TabIndex = 0;
            this.ExecutableLabel.Text = "Eseguibile";
            this.ExecutableLabel.Click += new System.EventHandler(this.ExecutableLabel_Click);
            // 
            // ExecutableTextBox
            // 
            this.ExecutableTextBox.Location = new System.Drawing.Point(105, 12);
            this.ExecutableTextBox.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ExecutableTextBox.MinimumSize = new System.Drawing.Size(200, 20);
            this.ExecutableTextBox.Name = "ExecutableTextBox";
            this.ExecutableTextBox.Size = new System.Drawing.Size(200, 20);
            this.ExecutableTextBox.TabIndex = 1;
            this.ExecutableTextBox.TextChanged += new System.EventHandler(this.ExecutableTextBox_TextChanged);
            // 
            // ArgumentLabel
            // 
            this.ArgumentLabel.AutoSize = true;
            this.ArgumentLabel.Location = new System.Drawing.Point(10, 45);
            this.ArgumentLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.ArgumentLabel.Name = "ArgumentLabel";
            this.ArgumentLabel.Padding = new System.Windows.Forms.Padding(5);
            this.ArgumentLabel.Size = new System.Drawing.Size(85, 35);
            this.ArgumentLabel.TabIndex = 2;
            this.ArgumentLabel.Text = "Argomenti";
            this.ArgumentLabel.Click += new System.EventHandler(this.ArgumentLabel_Click);
            // 
            // ArgumentTextBox
            // 
            this.ArgumentTextBox.Location = new System.Drawing.Point(105, 52);
            this.ArgumentTextBox.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ArgumentTextBox.MinimumSize = new System.Drawing.Size(200, 20);
            this.ArgumentTextBox.Name = "ArgumentTextBox";
            this.ArgumentTextBox.Size = new System.Drawing.Size(200, 20);
            this.ArgumentTextBox.TabIndex = 3;
            this.ArgumentTextBox.TextChanged += new System.EventHandler(this.ArgumentTextBox_TextChanged);
            // 
            // SaveButton
            // 
            this.SaveButton.AutoSize = true;
            this.SaveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SaveButton.Location = new System.Drawing.Point(10, 90);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Padding = new System.Windows.Forms.Padding(5);
            this.SaveButton.Size = new System.Drawing.Size(54, 33);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Salva";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.AutoSize = true;
            this.MainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainPanel.Controls.Add(this.ExecutableLabel);
            this.MainPanel.Controls.Add(this.ExecutableTextBox);
            this.MainPanel.Controls.Add(this.ArgumentLabel);
            this.MainPanel.Controls.Add(this.ArgumentTextBox);
            this.MainPanel.Controls.Add(this.SaveButton);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.MainPanel.Size = new System.Drawing.Size(800, 450);
            this.MainPanel.TabIndex = 0;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainPanel);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(200, 100);
            this.Name = "SettingsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button ExecutableLabel;
        private System.Windows.Forms.TextBox ExecutableTextBox;
        private System.Windows.Forms.Button ArgumentLabel;
        private System.Windows.Forms.TextBox ArgumentTextBox;
        private System.Windows.Forms.Button SaveButton;
    }
}
