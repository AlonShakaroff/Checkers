namespace CheckersWindowsApp
{
    partial class CheckersBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckersBoard));
            this.PlayerTwoPanel = new System.Windows.Forms.Panel();
            this.PlayerOnePanel = new System.Windows.Forms.Panel();
            this.PlayerOneLabel = new System.Windows.Forms.Label();
            this.PlayerTwoLabel = new System.Windows.Forms.Label();
            this.PlayerTwoPanel.SuspendLayout();
            this.PlayerOnePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayerTwoPanel
            // 
            this.PlayerTwoPanel.BackColor = System.Drawing.Color.Transparent;
            this.PlayerTwoPanel.BackgroundImage = global::CheckersWindowsApp.Properties.Resources.dark_wood_label;
            this.PlayerTwoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlayerTwoPanel.Controls.Add(this.PlayerTwoLabel);
            this.PlayerTwoPanel.Location = new System.Drawing.Point(367, 12);
            this.PlayerTwoPanel.Name = "PlayerTwoPanel";
            this.PlayerTwoPanel.Size = new System.Drawing.Size(203, 69);
            this.PlayerTwoPanel.TabIndex = 0;
            this.PlayerTwoPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // PlayerOnePanel
            // 
            this.PlayerOnePanel.BackColor = System.Drawing.Color.Transparent;
            this.PlayerOnePanel.BackgroundImage = global::CheckersWindowsApp.Properties.Resources.dark_wood_label;
            this.PlayerOnePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlayerOnePanel.Controls.Add(this.PlayerOneLabel);
            this.PlayerOnePanel.Location = new System.Drawing.Point(12, 12);
            this.PlayerOnePanel.Name = "PlayerOnePanel";
            this.PlayerOnePanel.Size = new System.Drawing.Size(203, 69);
            this.PlayerOnePanel.TabIndex = 1;
            // 
            // PlayerOneLabel
            // 
            this.PlayerOneLabel.AutoSize = true;
            this.PlayerOneLabel.Location = new System.Drawing.Point(31, 26);
            this.PlayerOneLabel.Name = "PlayerOneLabel";
            this.PlayerOneLabel.Size = new System.Drawing.Size(56, 16);
            this.PlayerOneLabel.TabIndex = 0;
            this.PlayerOneLabel.Text = "Player 1";
            this.PlayerOneLabel.Click += new System.EventHandler(this.PlayerOneLabel_Click);
            // 
            // PlayerTwoLabel
            // 
            this.PlayerTwoLabel.AutoSize = true;
            this.PlayerTwoLabel.Location = new System.Drawing.Point(29, 26);
            this.PlayerTwoLabel.Name = "PlayerTwoLabel";
            this.PlayerTwoLabel.Size = new System.Drawing.Size(56, 16);
            this.PlayerTwoLabel.TabIndex = 1;
            this.PlayerTwoLabel.Text = "Player 2";
            // 
            // CheckersBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CheckersWindowsApp.Properties.Resources.dark_wood_texture;
            this.ClientSize = new System.Drawing.Size(582, 503);
            this.Controls.Add(this.PlayerOnePanel);
            this.Controls.Add(this.PlayerTwoPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CheckersBoard";
            this.Text = "CheckersBoard";
            this.Load += new System.EventHandler(this.CheckersBoard_Load);
            this.PlayerTwoPanel.ResumeLayout(false);
            this.PlayerTwoPanel.PerformLayout();
            this.PlayerOnePanel.ResumeLayout(false);
            this.PlayerOnePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PlayerTwoPanel;
        private System.Windows.Forms.Panel PlayerOnePanel;
        private System.Windows.Forms.Label PlayerTwoLabel;
        private System.Windows.Forms.Label PlayerOneLabel;
    }
}