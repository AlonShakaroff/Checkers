namespace CheckersWindowsApp
{
    partial class FormCheckersBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCheckersBoard));
            this.PlayerTwoPanel = new System.Windows.Forms.Panel();
            this.LabelPlayerTwoScore = new System.Windows.Forms.Label();
            this.LabelPlayerTwo = new System.Windows.Forms.Label();
            this.PlayerOnePanel = new System.Windows.Forms.Panel();
            this.LabelPlayerOneScore = new System.Windows.Forms.Label();
            this.LabelPlayerOne = new System.Windows.Forms.Label();
            this.PlayerTwoPanel.SuspendLayout();
            this.PlayerOnePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayerTwoPanel
            // 
            this.PlayerTwoPanel.BackColor = System.Drawing.Color.Transparent;
            this.PlayerTwoPanel.BackgroundImage = global::CheckersWindowsApp.Properties.Resources.dark_wood_label;
            this.PlayerTwoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlayerTwoPanel.Controls.Add(this.LabelPlayerTwoScore);
            this.PlayerTwoPanel.Controls.Add(this.LabelPlayerTwo);
            this.PlayerTwoPanel.Location = new System.Drawing.Point(367, 12);
            this.PlayerTwoPanel.Name = "PlayerTwoPanel";
            this.PlayerTwoPanel.Size = new System.Drawing.Size(203, 69);
            this.PlayerTwoPanel.TabIndex = 0;
            // 
            // LabelPlayerTwoScore
            // 
            this.LabelPlayerTwoScore.AutoSize = true;
            this.LabelPlayerTwoScore.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPlayerTwoScore.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LabelPlayerTwoScore.Location = new System.Drawing.Point(141, 26);
            this.LabelPlayerTwoScore.Name = "LabelPlayerTwoScore";
            this.LabelPlayerTwoScore.Size = new System.Drawing.Size(21, 24);
            this.LabelPlayerTwoScore.TabIndex = 2;
            this.LabelPlayerTwoScore.Text = "0";
            // 
            // LabelPlayerTwo
            // 
            this.LabelPlayerTwo.AutoSize = true;
            this.LabelPlayerTwo.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPlayerTwo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LabelPlayerTwo.Location = new System.Drawing.Point(20, 26);
            this.LabelPlayerTwo.Name = "LabelPlayerTwo";
            this.LabelPlayerTwo.Size = new System.Drawing.Size(111, 24);
            this.LabelPlayerTwo.TabIndex = 1;
            this.LabelPlayerTwo.Text = "Player 2: ";
            // 
            // PlayerOnePanel
            // 
            this.PlayerOnePanel.BackColor = System.Drawing.Color.Transparent;
            this.PlayerOnePanel.BackgroundImage = global::CheckersWindowsApp.Properties.Resources.dark_wood_label;
            this.PlayerOnePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlayerOnePanel.Controls.Add(this.LabelPlayerOneScore);
            this.PlayerOnePanel.Controls.Add(this.LabelPlayerOne);
            this.PlayerOnePanel.Location = new System.Drawing.Point(12, 12);
            this.PlayerOnePanel.Name = "PlayerOnePanel";
            this.PlayerOnePanel.Size = new System.Drawing.Size(203, 69);
            this.PlayerOnePanel.TabIndex = 1;
            // 
            // LabelPlayerOneScore
            // 
            this.LabelPlayerOneScore.AutoSize = true;
            this.LabelPlayerOneScore.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPlayerOneScore.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LabelPlayerOneScore.Location = new System.Drawing.Point(141, 26);
            this.LabelPlayerOneScore.Name = "LabelPlayerOneScore";
            this.LabelPlayerOneScore.Size = new System.Drawing.Size(21, 24);
            this.LabelPlayerOneScore.TabIndex = 3;
            this.LabelPlayerOneScore.Text = "0";
            // 
            // LabelPlayerOne
            // 
            this.LabelPlayerOne.AutoSize = true;
            this.LabelPlayerOne.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPlayerOne.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LabelPlayerOne.Location = new System.Drawing.Point(17, 26);
            this.LabelPlayerOne.Name = "LabelPlayerOne";
            this.LabelPlayerOne.Size = new System.Drawing.Size(111, 24);
            this.LabelPlayerOne.TabIndex = 2;
            this.LabelPlayerOne.Text = "Player 1: ";
            // 
            // FormCheckersBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CheckersWindowsApp.Properties.Resources.dark_wood_texture;
            this.ClientSize = new System.Drawing.Size(582, 503);
            this.Controls.Add(this.PlayerOnePanel);
            this.Controls.Add(this.PlayerTwoPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCheckersBoard";
            this.Text = "CheckersBoard";
            this.PlayerTwoPanel.ResumeLayout(false);
            this.PlayerTwoPanel.PerformLayout();
            this.PlayerOnePanel.ResumeLayout(false);
            this.PlayerOnePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PlayerTwoPanel;
        private System.Windows.Forms.Panel PlayerOnePanel;
        private System.Windows.Forms.Label LabelPlayerTwo;
        private System.Windows.Forms.Label LabelPlayerTwoScore;
        private System.Windows.Forms.Label LabelPlayerOneScore;
        private System.Windows.Forms.Label LabelPlayerOne;
    }
}