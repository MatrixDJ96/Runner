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
            this.ListPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ExecutableLabel = new System.Windows.Forms.Label();
            this.ExecutableTextBox = new System.Windows.Forms.TextBox();
            this.ArgumentLabel = new System.Windows.Forms.Label();
            this.ArgumentTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ListPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListPanel
            // 
            this.ListPanel.AutoSize = true;
            this.ListPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ListPanel.ColumnCount = 2;
            this.ListPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ListPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ListPanel.Controls.Add(this.ExecutableLabel, 0, 0);
            this.ListPanel.Controls.Add(this.ExecutableTextBox, 1, 0);
            this.ListPanel.Controls.Add(this.ArgumentLabel, 0, 2);
            this.ListPanel.Controls.Add(this.ArgumentTextBox, 1, 2);
            this.ListPanel.Location = new System.Drawing.Point(3, 3);
            this.ListPanel.Name = "ListPanel";
            this.ListPanel.Padding = new System.Windows.Forms.Padding(5);
            this.ListPanel.RowCount = 3;
            this.ListPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ListPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.ListPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ListPanel.Size = new System.Drawing.Size(285, 72);
            this.ListPanel.TabIndex = 0;
            // 
            // ExecutableLabel
            // 
            this.ExecutableLabel.AutoSize = true;
            this.ExecutableLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ExecutableLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExecutableLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExecutableLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExecutableLabel.Location = new System.Drawing.Point(8, 5);
            this.ExecutableLabel.Name = "ExecutableLabel";
            this.ExecutableLabel.Padding = new System.Windows.Forms.Padding(3);
            this.ExecutableLabel.Size = new System.Drawing.Size(63, 26);
            this.ExecutableLabel.TabIndex = 0;
            this.ExecutableLabel.Text = "Eseguibile";
            this.ExecutableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ExecutableLabel.Click += new System.EventHandler(this.FileToExecuteTextBox_Click);
            // 
            // ExecutableTextBox
            // 
            this.ExecutableTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.ExecutableTextBox.Location = new System.Drawing.Point(77, 8);
            this.ExecutableTextBox.Name = "ExecutableTextBox";
            this.ExecutableTextBox.Size = new System.Drawing.Size(200, 20);
            this.ExecutableTextBox.TabIndex = 1;
            this.ExecutableTextBox.TextChanged += new System.EventHandler(this.FileToExecuteTextBox_TextChanged);
            // 
            // ArgumentLabel
            // 
            this.ArgumentLabel.AutoSize = true;
            this.ArgumentLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ArgumentLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ArgumentLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ArgumentLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArgumentLabel.Location = new System.Drawing.Point(8, 41);
            this.ArgumentLabel.Name = "ArgumentLabel";
            this.ArgumentLabel.Padding = new System.Windows.Forms.Padding(3);
            this.ArgumentLabel.Size = new System.Drawing.Size(63, 26);
            this.ArgumentLabel.TabIndex = 2;
            this.ArgumentLabel.Text = "Argomenti";
            this.ArgumentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ArgumentLabel.Click += new System.EventHandler(this.ArgumentLabel_Click);
            // 
            // ArgumentTextBox
            // 
            this.ArgumentTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.ArgumentTextBox.Location = new System.Drawing.Point(77, 44);
            this.ArgumentTextBox.Name = "ArgumentTextBox";
            this.ArgumentTextBox.Size = new System.Drawing.Size(200, 20);
            this.ArgumentTextBox.TabIndex = 3;
            this.ArgumentTextBox.TextChanged += new System.EventHandler(this.ArgumentTextBox_TextChanged);
            // 
            // SaveButton
            // 
            this.SaveButton.AutoSize = true;
            this.SaveButton.Location = new System.Drawing.Point(10, 83);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Padding = new System.Windows.Forms.Padding(5);
            this.SaveButton.Size = new System.Drawing.Size(75, 33);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Salva";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.AutoSize = true;
            this.MainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainPanel.Controls.Add(this.ListPanel);
            this.MainPanel.Controls.Add(this.SaveButton);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(800, 450);
            this.MainPanel.TabIndex = 2;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainPanel);
            this.MinimumSize = new System.Drawing.Size(200, 100);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ListPanel.ResumeLayout(false);
            this.ListPanel.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel ListPanel;
        private System.Windows.Forms.Label ExecutableLabel;
        private System.Windows.Forms.TextBox ExecutableTextBox;
        private System.Windows.Forms.Label ArgumentLabel;
        private System.Windows.Forms.TextBox ArgumentTextBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.FlowLayoutPanel MainPanel;
    }
}