namespace Runner
{
    partial class RunnerForm
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
            this.TopPanel = new System.Windows.Forms.Panel();
            this.FileToExecuteLabel = new System.Windows.Forms.Label();
            this.FillPanel = new System.Windows.Forms.Panel();
            this.OutputTextBox = new System.Windows.Forms.RichTextBox();
            this.RightPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.TopPanel.SuspendLayout();
            this.FillPanel.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.AutoSize = true;
            this.TopPanel.Controls.Add(this.FileToExecuteLabel);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(800, 23);
            this.TopPanel.TabIndex = 0;
            // 
            // FileToExecuteLabel
            // 
            this.FileToExecuteLabel.AutoSize = true;
            this.FileToExecuteLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FileToExecuteLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileToExecuteLabel.Location = new System.Drawing.Point(0, 0);
            this.FileToExecuteLabel.Name = "FileToExecuteLabel";
            this.FileToExecuteLabel.Padding = new System.Windows.Forms.Padding(5);
            this.FileToExecuteLabel.Size = new System.Drawing.Size(85, 23);
            this.FileToExecuteLabel.TabIndex = 0;
            this.FileToExecuteLabel.Text = "FileToExecute";
            this.FileToExecuteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FillPanel
            // 
            this.FillPanel.AutoSize = true;
            this.FillPanel.Controls.Add(this.OutputTextBox);
            this.FillPanel.Controls.Add(this.RightPanel);
            this.FillPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FillPanel.Location = new System.Drawing.Point(0, 23);
            this.FillPanel.Name = "FillPanel";
            this.FillPanel.Padding = new System.Windows.Forms.Padding(5);
            this.FillPanel.Size = new System.Drawing.Size(800, 427);
            this.FillPanel.TabIndex = 1;
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.BackColor = System.Drawing.Color.White;
            this.OutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputTextBox.Location = new System.Drawing.Point(5, 5);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.Size = new System.Drawing.Size(709, 417);
            this.OutputTextBox.TabIndex = 1;
            this.OutputTextBox.Text = "Output";
            // 
            // RightPanel
            // 
            this.RightPanel.AutoSize = true;
            this.RightPanel.Controls.Add(this.StartButton);
            this.RightPanel.Controls.Add(this.StopButton);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.RightPanel.Location = new System.Drawing.Point(714, 5);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(81, 417);
            this.RightPanel.TabIndex = 2;
            // 
            // StartButton
            // 
            this.StartButton.AutoSize = true;
            this.StartButton.Enabled = false;
            this.StartButton.Location = new System.Drawing.Point(3, 3);
            this.StartButton.Name = "StartButton";
            this.StartButton.Padding = new System.Windows.Forms.Padding(5);
            this.StartButton.Size = new System.Drawing.Size(75, 33);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            // 
            // StopButton
            // 
            this.StopButton.AutoSize = true;
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(3, 42);
            this.StopButton.Name = "StopButton";
            this.StopButton.Padding = new System.Windows.Forms.Padding(5);
            this.StopButton.Size = new System.Drawing.Size(75, 33);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            // 
            // RunnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FillPanel);
            this.Controls.Add(this.TopPanel);
            this.Name = "RunnerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Runner";
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.FillPanel.ResumeLayout(false);
            this.FillPanel.PerformLayout();
            this.RightPanel.ResumeLayout(false);
            this.RightPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label FileToExecuteLabel;
        private System.Windows.Forms.Panel FillPanel;
        private System.Windows.Forms.RichTextBox OutputTextBox;
        private System.Windows.Forms.FlowLayoutPanel RightPanel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
    }
}

