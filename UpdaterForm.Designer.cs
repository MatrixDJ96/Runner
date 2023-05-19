namespace Runner
{
    partial class UpdaterForm
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
            this.MainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ListPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.AbortButton = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            this.ListPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.AutoSize = true;
            this.MainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainPanel.Controls.Add(this.ListPanel);
            this.MainPanel.Controls.Add(this.AbortButton);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(800, 450);
            this.MainPanel.TabIndex = 3;
            // 
            // ListPanel
            // 
            this.ListPanel.AutoSize = true;
            this.ListPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ListPanel.ColumnCount = 1;
            this.ListPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ListPanel.Controls.Add(this.DownloadProgressBar, 0, 0);
            this.ListPanel.Location = new System.Drawing.Point(3, 3);
            this.ListPanel.Name = "ListPanel";
            this.ListPanel.Padding = new System.Windows.Forms.Padding(5);
            this.ListPanel.RowCount = 1;
            this.ListPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ListPanel.Size = new System.Drawing.Size(216, 46);
            this.ListPanel.TabIndex = 0;
            // 
            // DownloadProgressBar
            // 
            this.DownloadProgressBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.DownloadProgressBar.Location = new System.Drawing.Point(8, 8);
            this.DownloadProgressBar.Name = "DownloadProgressBar";
            this.DownloadProgressBar.Size = new System.Drawing.Size(200, 30);
            this.DownloadProgressBar.TabIndex = 3;
            // 
            // AbortButton
            // 
            this.AbortButton.AutoSize = true;
            this.AbortButton.Location = new System.Drawing.Point(10, 57);
            this.AbortButton.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Padding = new System.Windows.Forms.Padding(5);
            this.AbortButton.Size = new System.Drawing.Size(75, 33);
            this.AbortButton.TabIndex = 1;
            this.AbortButton.Text = "Annulla";
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            // 
            // UpdaterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainPanel);
            this.Name = "UpdaterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Updater";
            this.Load += new System.EventHandler(this.UpdaterForm_Load);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ListPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel MainPanel;
        private System.Windows.Forms.TableLayoutPanel ListPanel;
        private System.Windows.Forms.ProgressBar DownloadProgressBar;
        private System.Windows.Forms.Button AbortButton;
    }
}

