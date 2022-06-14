namespace CheckersWindowsApp
{
    partial class FormCheckersGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCheckersGame));
            this.PanelPlayerTwo = new System.Windows.Forms.Panel();
            this.LabelPlayerTwoScore = new System.Windows.Forms.Label();
            this.LabelPlayerTwo = new System.Windows.Forms.Label();
            this.PanelPlayerOne = new System.Windows.Forms.Panel();
            this.LabelPlayerOneScore = new System.Windows.Forms.Label();
            this.LabelPlayerOne = new System.Windows.Forms.Label();
            this.PanelGameBoard = new System.Windows.Forms.Panel();
            this.PanelPlayerTwo.SuspendLayout();
            this.PanelPlayerOne.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelPlayerTwo
            // 
            this.PanelPlayerTwo.BackColor = System.Drawing.Color.Transparent;
            this.PanelPlayerTwo.BackgroundImage = global::CheckersWindowsApp.Properties.Resources.dark_wood_label;
            this.PanelPlayerTwo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelPlayerTwo.Controls.Add(this.LabelPlayerTwoScore);
            this.PanelPlayerTwo.Controls.Add(this.LabelPlayerTwo);
            this.PanelPlayerTwo.Location = new System.Drawing.Point(367, 12);
            this.PanelPlayerTwo.Name = "PanelPlayerTwo";
            this.PanelPlayerTwo.Size = new System.Drawing.Size(203, 69);
            this.PanelPlayerTwo.TabIndex = 0;
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
            // PanelPlayerOne
            // 
            this.PanelPlayerOne.BackColor = System.Drawing.Color.Transparent;
            this.PanelPlayerOne.BackgroundImage = global::CheckersWindowsApp.Properties.Resources.dark_wood_label;
            this.PanelPlayerOne.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelPlayerOne.Controls.Add(this.LabelPlayerOneScore);
            this.PanelPlayerOne.Controls.Add(this.LabelPlayerOne);
            this.PanelPlayerOne.Location = new System.Drawing.Point(12, 12);
            this.PanelPlayerOne.Name = "PanelPlayerOne";
            this.PanelPlayerOne.Size = new System.Drawing.Size(203, 69);
            this.PanelPlayerOne.TabIndex = 1;
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
            this.LabelPlayerOne.Cursor = System.Windows.Forms.Cursors.Default;
            this.LabelPlayerOne.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPlayerOne.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LabelPlayerOne.Location = new System.Drawing.Point(17, 26);
            this.LabelPlayerOne.Name = "LabelPlayerOne";
            this.LabelPlayerOne.Size = new System.Drawing.Size(111, 24);
            this.LabelPlayerOne.TabIndex = 2;
            this.LabelPlayerOne.Text = "Player 1: ";
            // 
            // PanelGameBoard
            // 
            this.PanelGameBoard.BackColor = System.Drawing.Color.Transparent;
            this.PanelGameBoard.Location = new System.Drawing.Point(52, 100);
            this.PanelGameBoard.Name = "PanelGameBoard";
            this.PanelGameBoard.Size = new System.Drawing.Size(483, 362);
            this.PanelGameBoard.TabIndex = 2;
            // 
            // FormCheckersGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CheckersWindowsApp.Properties.Resources.dark_wood_texture;
            this.ClientSize = new System.Drawing.Size(582, 503);
            this.Controls.Add(this.PanelGameBoard);
            this.Controls.Add(this.PanelPlayerOne);
            this.Controls.Add(this.PanelPlayerTwo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCheckersGame";
            this.Text = "Checkers";
            this.PanelPlayerTwo.ResumeLayout(false);
            this.PanelPlayerTwo.PerformLayout();
            this.PanelPlayerOne.ResumeLayout(false);
            this.PanelPlayerOne.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelPlayerTwo;
        private System.Windows.Forms.Panel PanelPlayerOne;
        private System.Windows.Forms.Label LabelPlayerTwo;
        private System.Windows.Forms.Label LabelPlayerTwoScore;
        private System.Windows.Forms.Label LabelPlayerOneScore;
        private System.Windows.Forms.Label LabelPlayerOne;
        private System.Windows.Forms.Panel PanelGameBoard;
    }
}