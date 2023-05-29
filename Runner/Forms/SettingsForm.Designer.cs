namespace Runner.Forms
{
    partial class SettingsForm
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        protected override void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.ExecutableButton = new System.Windows.Forms.Button();
            this.ArgumentsButton = new System.Windows.Forms.Button();
            this.ExecutableTextBox = new System.Windows.Forms.TextBox();
            this.ArgumentsTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            this.TablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.AutoSize = true;
            this.MainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainPanel.Controls.Add(this.TablePanel);
            this.MainPanel.Controls.Add(this.SaveButton);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.MainPanel.Size = new System.Drawing.Size(800, 450);
            this.MainPanel.TabIndex = 0;
            // 
            // TablePanel
            // 
            this.TablePanel.AutoSize = true;
            this.TablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TablePanel.ColumnCount = 2;
            this.TablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TablePanel.Controls.Add(this.ExecutableButton, 0, 0);
            this.TablePanel.Controls.Add(this.ArgumentsButton, 0, 2);
            this.TablePanel.Controls.Add(this.ExecutableTextBox, 1, 0);
            this.TablePanel.Controls.Add(this.ArgumentsTextBox, 1, 2);
            this.TablePanel.Location = new System.Drawing.Point(10, 5);
            this.TablePanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.TablePanel.Name = "TablePanel";
            this.TablePanel.RowCount = 3;
            this.TablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.TablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TablePanel.Size = new System.Drawing.Size(285, 71);
            this.TablePanel.TabIndex = 0;
            // 
            // ExecutableButton
            // 
            this.ExecutableButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ExecutableButton.AutoSize = true;
            this.ExecutableButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExecutableButton.Location = new System.Drawing.Point(0, 0);
            this.ExecutableButton.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.ExecutableButton.Name = "ExecutableButton";
            this.ExecutableButton.Padding = new System.Windows.Forms.Padding(5);
            this.ExecutableButton.Size = new System.Drawing.Size(75, 33);
            this.ExecutableButton.TabIndex = 0;
            this.ExecutableButton.Text = "Eseguibile";
            this.ExecutableButton.Click += new System.EventHandler(this.ExecutableButton_Click);
            // 
            // ArgumentsButton
            // 
            this.ArgumentsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ArgumentsButton.AutoSize = true;
            this.ArgumentsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ArgumentsButton.Location = new System.Drawing.Point(0, 38);
            this.ArgumentsButton.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.ArgumentsButton.Name = "ArgumentsButton";
            this.ArgumentsButton.Padding = new System.Windows.Forms.Padding(5);
            this.ArgumentsButton.Size = new System.Drawing.Size(75, 33);
            this.ArgumentsButton.TabIndex = 2;
            this.ArgumentsButton.Text = "Argomenti";
            this.ArgumentsButton.Click += new System.EventHandler(this.ArgumentsButton_Click);
            // 
            // ExecutableTextBox
            // 
            this.ExecutableTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ExecutableTextBox.Location = new System.Drawing.Point(85, 6);
            this.ExecutableTextBox.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ExecutableTextBox.MinimumSize = new System.Drawing.Size(200, 20);
            this.ExecutableTextBox.Name = "ExecutableTextBox";
            this.ExecutableTextBox.Size = new System.Drawing.Size(200, 20);
            this.ExecutableTextBox.TabIndex = 3;
            this.ExecutableTextBox.TextChanged += new System.EventHandler(this.ExecutableTextBox_TextChanged);
            // 
            // ArgumentsTextBox
            // 
            this.ArgumentsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ArgumentsTextBox.Location = new System.Drawing.Point(85, 44);
            this.ArgumentsTextBox.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ArgumentsTextBox.MinimumSize = new System.Drawing.Size(200, 20);
            this.ArgumentsTextBox.Name = "ArgumentsTextBox";
            this.ArgumentsTextBox.Size = new System.Drawing.Size(200, 20);
            this.ArgumentsTextBox.TabIndex = 1;
            this.ArgumentsTextBox.TextChanged += new System.EventHandler(this.ArgumentsTextBox_TextChanged);
            // 
            // SaveButton
            // 
            this.SaveButton.AutoSize = true;
            this.SaveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SaveButton.Location = new System.Drawing.Point(10, 86);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Padding = new System.Windows.Forms.Padding(5);
            this.SaveButton.Size = new System.Drawing.Size(54, 33);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Salva";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
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
            this.TablePanel.ResumeLayout(false);
            this.TablePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel MainPanel;
        private System.Windows.Forms.TableLayoutPanel TablePanel;
        private System.Windows.Forms.TextBox ExecutableTextBox;
        private System.Windows.Forms.Button ExecutableButton;
        private System.Windows.Forms.TextBox ArgumentsTextBox;
        private System.Windows.Forms.Button ArgumentsButton;
        private System.Windows.Forms.Button SaveButton;
    }
}
