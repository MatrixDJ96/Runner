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
            this.FullExecutableLabel = new System.Windows.Forms.Label();
            this.FillPanel = new System.Windows.Forms.Panel();
            this.ErrorTextBox = new System.Windows.Forms.RichTextBox();
            this.OutputTextBox = new System.Windows.Forms.RichTextBox();
            this.RightPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.ErrorButton = new System.Windows.Forms.Button();
            this.TopPanel.SuspendLayout();
            this.FillPanel.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.AutoSize = true;
            this.TopPanel.Controls.Add(this.FullExecutableLabel);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Padding = new System.Windows.Forms.Padding(5);
            this.TopPanel.Size = new System.Drawing.Size(800, 34);
            this.TopPanel.TabIndex = 0;
            // 
            // FullExecutableLabel
            // 
            this.FullExecutableLabel.AutoSize = true;
            this.FullExecutableLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.FullExecutableLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FullExecutableLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FullExecutableLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FullExecutableLabel.Location = new System.Drawing.Point(5, 5);
            this.FullExecutableLabel.Name = "FullExecutableLabel";
            this.FullExecutableLabel.Padding = new System.Windows.Forms.Padding(3);
            this.FullExecutableLabel.Size = new System.Drawing.Size(272, 24);
            this.FullExecutableLabel.TabIndex = 0;
            this.FullExecutableLabel.Text = "Clicca qui per selezionare un file eseguibile";
            this.FullExecutableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FullExecutableLabel.Click += new System.EventHandler(this.ExecutableLabel_Click);
            // 
            // FillPanel
            // 
            this.FillPanel.AutoSize = true;
            this.FillPanel.Controls.Add(this.ErrorTextBox);
            this.FillPanel.Controls.Add(this.OutputTextBox);
            this.FillPanel.Controls.Add(this.RightPanel);
            this.FillPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FillPanel.Location = new System.Drawing.Point(0, 34);
            this.FillPanel.Name = "FillPanel";
            this.FillPanel.Padding = new System.Windows.Forms.Padding(5);
            this.FillPanel.Size = new System.Drawing.Size(800, 416);
            this.FillPanel.TabIndex = 1;
            // 
            // ErrorTextBox
            // 
            this.ErrorTextBox.BackColor = System.Drawing.Color.White;
            this.ErrorTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorTextBox.ForeColor = System.Drawing.Color.Red;
            this.ErrorTextBox.Location = new System.Drawing.Point(5, 5);
            this.ErrorTextBox.Name = "ErrorTextBox";
            this.ErrorTextBox.ReadOnly = true;
            this.ErrorTextBox.Size = new System.Drawing.Size(681, 406);
            this.ErrorTextBox.TabIndex = 1;
            this.ErrorTextBox.Text = "";
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.BackColor = System.Drawing.Color.White;
            this.OutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputTextBox.Location = new System.Drawing.Point(5, 5);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.Size = new System.Drawing.Size(681, 406);
            this.OutputTextBox.TabIndex = 2;
            this.OutputTextBox.Text = "";
            // 
            // RightPanel
            // 
            this.RightPanel.AutoSize = true;
            this.RightPanel.Controls.Add(this.StartButton);
            this.RightPanel.Controls.Add(this.StopButton);
            this.RightPanel.Controls.Add(this.ErrorButton);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.RightPanel.Location = new System.Drawing.Point(686, 5);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(109, 406);
            this.RightPanel.TabIndex = 2;
            // 
            // StartButton
            // 
            this.StartButton.AutoSize = true;
            this.StartButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartButton.Enabled = false;
            this.StartButton.Location = new System.Drawing.Point(3, 3);
            this.StartButton.Name = "StartButton";
            this.StartButton.Padding = new System.Windows.Forms.Padding(5);
            this.StartButton.Size = new System.Drawing.Size(103, 36);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Avvia";
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.AutoSize = true;
            this.StopButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(3, 45);
            this.StopButton.Name = "StopButton";
            this.StopButton.Padding = new System.Windows.Forms.Padding(5);
            this.StopButton.Size = new System.Drawing.Size(103, 36);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Interrompi";
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // ErrorButton
            // 
            this.ErrorButton.AutoSize = true;
            this.ErrorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorButton.Enabled = false;
            this.ErrorButton.Location = new System.Drawing.Point(3, 87);
            this.ErrorButton.Name = "ErrorButton";
            this.ErrorButton.Padding = new System.Windows.Forms.Padding(5);
            this.ErrorButton.Size = new System.Drawing.Size(103, 36);
            this.ErrorButton.TabIndex = 2;
            this.ErrorButton.Text = "Mostra errori";
            this.ErrorButton.Click += new System.EventHandler(this.ErrorButton_Click);
            // 
            // RunnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FillPanel);
            this.Controls.Add(this.TopPanel);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "RunnerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Runner";
            this.Load += new System.EventHandler(this.RunnerForm_Load);
            this.ResizeEnd += new System.EventHandler(this.RunnerForm_ResizeEnd);
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
        private System.Windows.Forms.Label FullExecutableLabel;
        private System.Windows.Forms.Panel FillPanel;
        private System.Windows.Forms.RichTextBox ErrorTextBox;
        private System.Windows.Forms.RichTextBox OutputTextBox;
        private System.Windows.Forms.FlowLayoutPanel RightPanel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button ErrorButton;
    }
}

