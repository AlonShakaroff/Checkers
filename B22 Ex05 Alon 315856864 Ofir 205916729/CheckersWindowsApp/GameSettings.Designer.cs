﻿
namespace CheckersWindowsApp
{
    partial class GameSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameSettings));
            this.labelFirstPlayersName = new System.Windows.Forms.Label();
            this.labelSecondPlayersName = new System.Windows.Forms.Label();
            this.textBoxFirstPlayersName = new System.Windows.Forms.TextBox();
            this.textBoxSecondPlayersName = new System.Windows.Forms.TextBox();
            this.radioButton6x6 = new System.Windows.Forms.RadioButton();
            this.radioButton10x10 = new System.Windows.Forms.RadioButton();
            this.radioButton8x8 = new System.Windows.Forms.RadioButton();
            this.groupBoxBoardSize = new System.Windows.Forms.GroupBox();
            this.groupBoxPlayersNames = new System.Windows.Forms.GroupBox();
            this.radioButtonAgainstComputer = new System.Windows.Forms.RadioButton();
            this.radioButtonAgainstHuman = new System.Windows.Forms.RadioButton();
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.groupBoxBoardSize.SuspendLayout();
            this.groupBoxPlayersNames.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelFirstPlayersName
            // 
            this.labelFirstPlayersName.AutoSize = true;
            this.labelFirstPlayersName.Location = new System.Drawing.Point(24, 26);
            this.labelFirstPlayersName.Name = "labelFirstPlayersName";
            this.labelFirstPlayersName.Size = new System.Drawing.Size(96, 13);
            this.labelFirstPlayersName.TabIndex = 0;
            this.labelFirstPlayersName.Text = "First player\'s name:";
            // 
            // labelSecondPlayersName
            // 
            this.labelSecondPlayersName.AutoSize = true;
            this.labelSecondPlayersName.Location = new System.Drawing.Point(24, 79);
            this.labelSecondPlayersName.Name = "labelSecondPlayersName";
            this.labelSecondPlayersName.Size = new System.Drawing.Size(114, 13);
            this.labelSecondPlayersName.TabIndex = 1;
            this.labelSecondPlayersName.Text = "Second player\'s name:";
            // 
            // textBoxFirstPlayersName
            // 
            this.textBoxFirstPlayersName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFirstPlayersName.Location = new System.Drawing.Point(149, 23);
            this.textBoxFirstPlayersName.Name = "textBoxFirstPlayersName";
            this.textBoxFirstPlayersName.Size = new System.Drawing.Size(100, 20);
            this.textBoxFirstPlayersName.TabIndex = 2;
            this.textBoxFirstPlayersName.TextChanged += new System.EventHandler(this.textBoxFirstPlayersName_TextChanged);
            // 
            // textBoxSecondPlayersName
            // 
            this.textBoxSecondPlayersName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSecondPlayersName.Location = new System.Drawing.Point(149, 76);
            this.textBoxSecondPlayersName.Name = "textBoxSecondPlayersName";
            this.textBoxSecondPlayersName.Size = new System.Drawing.Size(100, 20);
            this.textBoxSecondPlayersName.TabIndex = 3;
            this.textBoxSecondPlayersName.TextChanged += new System.EventHandler(this.textBoxSecondPlayersName_TextChanged);
            // 
            // radioButton6x6
            // 
            this.radioButton6x6.AutoSize = true;
            this.radioButton6x6.Location = new System.Drawing.Point(24, 19);
            this.radioButton6x6.Name = "radioButton6x6";
            this.radioButton6x6.Size = new System.Drawing.Size(48, 17);
            this.radioButton6x6.TabIndex = 4;
            this.radioButton6x6.Text = "6 x 6";
            this.radioButton6x6.UseVisualStyleBackColor = true;
            this.radioButton6x6.CheckedChanged += new System.EventHandler(this.radioButton6x6_CheckedChanged);
            // 
            // radioButton10x10
            // 
            this.radioButton10x10.AutoSize = true;
            this.radioButton10x10.Location = new System.Drawing.Point(134, 19);
            this.radioButton10x10.Name = "radioButton10x10";
            this.radioButton10x10.Size = new System.Drawing.Size(60, 17);
            this.radioButton10x10.TabIndex = 5;
            this.radioButton10x10.Text = "10 x 10";
            this.radioButton10x10.UseVisualStyleBackColor = true;
            this.radioButton10x10.CheckedChanged += new System.EventHandler(this.radioButton10x10_CheckedChanged);
            // 
            // radioButton8x8
            // 
            this.radioButton8x8.AutoSize = true;
            this.radioButton8x8.Checked = true;
            this.radioButton8x8.Location = new System.Drawing.Point(78, 19);
            this.radioButton8x8.Name = "radioButton8x8";
            this.radioButton8x8.Size = new System.Drawing.Size(48, 17);
            this.radioButton8x8.TabIndex = 6;
            this.radioButton8x8.TabStop = true;
            this.radioButton8x8.Text = "8 x 8";
            this.radioButton8x8.UseVisualStyleBackColor = true;
            this.radioButton8x8.CheckedChanged += new System.EventHandler(this.radioButton8x8_CheckedChanged);
            // 
            // groupBoxBoardSize
            // 
            this.groupBoxBoardSize.Controls.Add(this.radioButton6x6);
            this.groupBoxBoardSize.Controls.Add(this.radioButton10x10);
            this.groupBoxBoardSize.Controls.Add(this.radioButton8x8);
            this.groupBoxBoardSize.Location = new System.Drawing.Point(12, 14);
            this.groupBoxBoardSize.Name = "groupBoxBoardSize";
            this.groupBoxBoardSize.Size = new System.Drawing.Size(284, 46);
            this.groupBoxBoardSize.TabIndex = 7;
            this.groupBoxBoardSize.TabStop = false;
            this.groupBoxBoardSize.Text = "Board Size";
            // 
            // groupBoxPlayersNames
            // 
            this.groupBoxPlayersNames.Controls.Add(this.radioButtonAgainstComputer);
            this.groupBoxPlayersNames.Controls.Add(this.radioButtonAgainstHuman);
            this.groupBoxPlayersNames.Controls.Add(this.labelFirstPlayersName);
            this.groupBoxPlayersNames.Controls.Add(this.textBoxFirstPlayersName);
            this.groupBoxPlayersNames.Controls.Add(this.textBoxSecondPlayersName);
            this.groupBoxPlayersNames.Controls.Add(this.labelSecondPlayersName);
            this.groupBoxPlayersNames.Location = new System.Drawing.Point(12, 66);
            this.groupBoxPlayersNames.Name = "groupBoxPlayersNames";
            this.groupBoxPlayersNames.Size = new System.Drawing.Size(284, 107);
            this.groupBoxPlayersNames.TabIndex = 8;
            this.groupBoxPlayersNames.TabStop = false;
            this.groupBoxPlayersNames.Text = "Players";
            // 
            // radioButtonAgainstComputer
            // 
            this.radioButtonAgainstComputer.AutoSize = true;
            this.radioButtonAgainstComputer.Location = new System.Drawing.Point(92, 59);
            this.radioButtonAgainstComputer.Name = "radioButtonAgainstComputer";
            this.radioButtonAgainstComputer.Size = new System.Drawing.Size(70, 17);
            this.radioButtonAgainstComputer.TabIndex = 7;
            this.radioButtonAgainstComputer.Text = "Computer";
            this.radioButtonAgainstComputer.UseVisualStyleBackColor = true;
            this.radioButtonAgainstComputer.CheckedChanged += new System.EventHandler(this.radioButtonAgainstComputer_CheckedChanged);
            // 
            // radioButtonAgainstHuman
            // 
            this.radioButtonAgainstHuman.AutoSize = true;
            this.radioButtonAgainstHuman.Checked = true;
            this.radioButtonAgainstHuman.Location = new System.Drawing.Point(27, 59);
            this.radioButtonAgainstHuman.Name = "radioButtonAgainstHuman";
            this.radioButtonAgainstHuman.Size = new System.Drawing.Size(59, 17);
            this.radioButtonAgainstHuman.TabIndex = 8;
            this.radioButtonAgainstHuman.TabStop = true;
            this.radioButtonAgainstHuman.Text = "Human";
            this.radioButtonAgainstHuman.UseVisualStyleBackColor = true;
            this.radioButtonAgainstHuman.CheckedChanged += new System.EventHandler(this.radioButtonAgainstHuman_CheckedChanged);
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.Location = new System.Drawing.Point(216, 179);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(80, 34);
            this.buttonStartGame.TabIndex = 9;
            this.buttonStartGame.Text = "Start Game";
            this.buttonStartGame.UseVisualStyleBackColor = true;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // GameSettings
            // 
            this.AcceptButton = this.buttonStartGame;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 220);
            this.Controls.Add(this.buttonStartGame);
            this.Controls.Add(this.groupBoxPlayersNames);
            this.Controls.Add(this.groupBoxBoardSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameSettings";
            this.Text = "Game Settings";
            this.groupBoxBoardSize.ResumeLayout(false);
            this.groupBoxBoardSize.PerformLayout();
            this.groupBoxPlayersNames.ResumeLayout(false);
            this.groupBoxPlayersNames.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelFirstPlayersName;
        private System.Windows.Forms.Label labelSecondPlayersName;
        private System.Windows.Forms.TextBox textBoxFirstPlayersName;
        private System.Windows.Forms.TextBox textBoxSecondPlayersName;
        private System.Windows.Forms.RadioButton radioButton6x6;
        private System.Windows.Forms.RadioButton radioButton10x10;
        private System.Windows.Forms.RadioButton radioButton8x8;
        private System.Windows.Forms.GroupBox groupBoxBoardSize;
        private System.Windows.Forms.GroupBox groupBoxPlayersNames;
        private System.Windows.Forms.RadioButton radioButtonAgainstComputer;
        private System.Windows.Forms.RadioButton radioButtonAgainstHuman;
        private System.Windows.Forms.Button buttonStartGame;
    }
}