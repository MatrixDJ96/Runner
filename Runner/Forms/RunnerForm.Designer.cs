namespace Runner.Forms
{
    partial class RunnerForm
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        protected override void InitializeComponent()
        {
            this.TopPanel = new System.Windows.Forms.Panel();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.FillPanel = new System.Windows.Forms.Panel();
            this.OutputTextBox = new System.Windows.Forms.RichTextBox();
            this.ErrorTextBox = new System.Windows.Forms.RichTextBox();
            this.RightPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.ErrorButton = new System.Windows.Forms.Button();
            this.CounterText = new System.Windows.Forms.Label();
            this.TopPanel.SuspendLayout();
            this.FillPanel.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.AutoSize = true;
            this.TopPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TopPanel.Controls.Add(this.SettingsButton);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.TopPanel.Size = new System.Drawing.Size(800, 43);
            this.TopPanel.TabIndex = 0;
            // 
            // SettingsButton
            // 
            this.SettingsButton.AutoSize = true;
            this.SettingsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SettingsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsButton.Location = new System.Drawing.Point(10, 5);
            this.SettingsButton.Margin = new System.Windows.Forms.Padding(0);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Padding = new System.Windows.Forms.Padding(5);
            this.SettingsButton.Size = new System.Drawing.Size(780, 33);
            this.SettingsButton.TabIndex = 0;
            this.SettingsButton.Text = "Clicca qui per selezionare un file eseguibile";
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // FillPanel
            // 
            this.FillPanel.AutoSize = true;
            this.FillPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FillPanel.Controls.Add(this.OutputTextBox);
            this.FillPanel.Controls.Add(this.ErrorTextBox);
            this.FillPanel.Controls.Add(this.RightPanel);
            this.FillPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FillPanel.Location = new System.Drawing.Point(0, 43);
            this.FillPanel.Margin = new System.Windows.Forms.Padding(0);
            this.FillPanel.Name = "FillPanel";
            this.FillPanel.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.FillPanel.Size = new System.Drawing.Size(800, 407);
            this.FillPanel.TabIndex = 1;
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.BackColor = System.Drawing.Color.White;
            this.OutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputTextBox.Location = new System.Drawing.Point(10, 5);
            this.OutputTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.Size = new System.Drawing.Size(685, 397);
            this.OutputTextBox.TabIndex = 1;
            this.OutputTextBox.TabStop = false;
            this.OutputTextBox.Text = "";
            // 
            // ErrorTextBox
            // 
            this.ErrorTextBox.BackColor = System.Drawing.Color.White;
            this.ErrorTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorTextBox.ForeColor = System.Drawing.Color.Red;
            this.ErrorTextBox.Location = new System.Drawing.Point(10, 5);
            this.ErrorTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.ErrorTextBox.Name = "ErrorTextBox";
            this.ErrorTextBox.ReadOnly = true;
            this.ErrorTextBox.Size = new System.Drawing.Size(685, 397);
            this.ErrorTextBox.TabIndex = 0;
            this.ErrorTextBox.TabStop = false;
            this.ErrorTextBox.Text = "";
            // 
            // RightPanel
            // 
            this.RightPanel.AutoSize = true;
            this.RightPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RightPanel.Controls.Add(this.StartButton);
            this.RightPanel.Controls.Add(this.StopButton);
            this.RightPanel.Controls.Add(this.ErrorButton);
            this.RightPanel.Controls.Add(this.CounterText);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.RightPanel.Location = new System.Drawing.Point(695, 5);
            this.RightPanel.Margin = new System.Windows.Forms.Padding(0);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(100, 397);
            this.RightPanel.TabIndex = 2;
            // 
            // StartButton
            // 
            this.StartButton.AutoSize = true;
            this.StartButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StartButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartButton.Location = new System.Drawing.Point(10, 0);
            this.StartButton.Margin = new System.Windows.Forms.Padding(10, 0, 5, 5);
            this.StartButton.Name = "StartButton";
            this.StartButton.Padding = new System.Windows.Forms.Padding(5);
            this.StartButton.Size = new System.Drawing.Size(85, 33);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Avvia";
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.AutoSize = true;
            this.StopButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StopButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StopButton.Location = new System.Drawing.Point(10, 38);
            this.StopButton.Margin = new System.Windows.Forms.Padding(10, 0, 5, 5);
            this.StopButton.Name = "StopButton";
            this.StopButton.Padding = new System.Windows.Forms.Padding(5);
            this.StopButton.Size = new System.Drawing.Size(85, 33);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Interrompi";
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // ErrorButton
            // 
            this.ErrorButton.AutoSize = true;
            this.ErrorButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ErrorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorButton.Location = new System.Drawing.Point(10, 76);
            this.ErrorButton.Margin = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.ErrorButton.Name = "ErrorButton";
            this.ErrorButton.Padding = new System.Windows.Forms.Padding(5);
            this.ErrorButton.Size = new System.Drawing.Size(85, 33);
            this.ErrorButton.TabIndex = 2;
            this.ErrorButton.Text = "Mostra errori";
            this.ErrorButton.Click += new System.EventHandler(this.ErrorButton_Click);
            // 
            // CounterText
            // 
            this.CounterText.AutoSize = true;
            this.CounterText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CounterText.Location = new System.Drawing.Point(10, 119);
            this.CounterText.Margin = new System.Windows.Forms.Padding(10, 10, 5, 0);
            this.CounterText.Name = "CounterText";
            this.CounterText.Size = new System.Drawing.Size(85, 13);
            this.CounterText.TabIndex = 3;
            this.CounterText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RunnerForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FillPanel);
            this.Controls.Add(this.TopPanel);
            this.MinimumSize = new System.Drawing.Size(400, 225);
            this.Name = "RunnerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Runner";
            this.Load += new System.EventHandler(this.RunnerForm_Load);
            this.ResizeBegin += new System.EventHandler(this.RunnerForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.RunnerForm_ResizeEnd);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.RunnerForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.RunnerForm_DragEnter);
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
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Panel FillPanel;
        private System.Windows.Forms.RichTextBox ErrorTextBox;
        private System.Windows.Forms.RichTextBox OutputTextBox;
        private System.Windows.Forms.FlowLayoutPanel RightPanel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button ErrorButton;
        private System.Windows.Forms.Label CounterText;
    }
}
