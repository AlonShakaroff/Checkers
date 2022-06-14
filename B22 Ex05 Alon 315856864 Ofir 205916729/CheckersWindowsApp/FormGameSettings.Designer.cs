﻿
namespace CheckersWindowsApp
{
    partial class FormGameSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGameSettings));
            this.labelPlayerOneName = new System.Windows.Forms.Label();
            this.labelPlayerTwoName = new System.Windows.Forms.Label();
            this.textBoxPlayerOneName = new System.Windows.Forms.TextBox();
            this.textBoxPlayerTwoName = new System.Windows.Forms.TextBox();
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
            // labelPlayerOneName
            // 
            this.labelPlayerOneName.AutoSize = true;
            this.labelPlayerOneName.Location = new System.Drawing.Point(36, 40);
            this.labelPlayerOneName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlayerOneName.Name = "labelPlayerOneName";
            this.labelPlayerOneName.Size = new System.Drawing.Size(145, 20);
            this.labelPlayerOneName.TabIndex = 0;
            this.labelPlayerOneName.Text = "First player\'s name:";
            // 
            // labelPlayerTwoName
            // 
            this.labelPlayerTwoName.AutoSize = true;
            this.labelPlayerTwoName.Location = new System.Drawing.Point(36, 122);
            this.labelPlayerTwoName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlayerTwoName.Name = "labelPlayerTwoName";
            this.labelPlayerTwoName.Size = new System.Drawing.Size(169, 20);
            this.labelPlayerTwoName.TabIndex = 1;
            this.labelPlayerTwoName.Text = "Second player\'s name:";
            // 
            // textBoxPlayerOneName
            // 
            this.textBoxPlayerOneName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPlayerOneName.Location = new System.Drawing.Point(224, 35);
            this.textBoxPlayerOneName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPlayerOneName.Name = "textBoxPlayerOneName";
            this.textBoxPlayerOneName.Size = new System.Drawing.Size(149, 26);
            this.textBoxPlayerOneName.TabIndex = 2;
            // 
            // textBoxPlayerTwoName
            // 
            this.textBoxPlayerTwoName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPlayerTwoName.Location = new System.Drawing.Point(224, 117);
            this.textBoxPlayerTwoName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPlayerTwoName.Name = "textBoxPlayerTwoName";
            this.textBoxPlayerTwoName.Size = new System.Drawing.Size(149, 26);
            this.textBoxPlayerTwoName.TabIndex = 3;
            // 
            // radioButton6x6
            // 
            this.radioButton6x6.AutoSize = true;
            this.radioButton6x6.Location = new System.Drawing.Point(36, 29);
            this.radioButton6x6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton6x6.Name = "radioButton6x6";
            this.radioButton6x6.Size = new System.Drawing.Size(67, 24);
            this.radioButton6x6.TabIndex = 4;
            this.radioButton6x6.Text = "6 x 6";
            this.radioButton6x6.UseVisualStyleBackColor = true;
            // 
            // radioButton10x10
            // 
            this.radioButton10x10.AutoSize = true;
            this.radioButton10x10.Location = new System.Drawing.Point(201, 29);
            this.radioButton10x10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton10x10.Name = "radioButton10x10";
            this.radioButton10x10.Size = new System.Drawing.Size(85, 24);
            this.radioButton10x10.TabIndex = 5;
            this.radioButton10x10.Text = "10 x 10";
            this.radioButton10x10.UseVisualStyleBackColor = true;
            // 
            // radioButton8x8
            // 
            this.radioButton8x8.AutoSize = true;
            this.radioButton8x8.Checked = true;
            this.radioButton8x8.Location = new System.Drawing.Point(117, 29);
            this.radioButton8x8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton8x8.Name = "radioButton8x8";
            this.radioButton8x8.Size = new System.Drawing.Size(67, 24);
            this.radioButton8x8.TabIndex = 6;
            this.radioButton8x8.TabStop = true;
            this.radioButton8x8.Text = "8 x 8";
            this.radioButton8x8.UseVisualStyleBackColor = true;
            // 
            // groupBoxBoardSize
            // 
            this.groupBoxBoardSize.Controls.Add(this.radioButton6x6);
            this.groupBoxBoardSize.Controls.Add(this.radioButton10x10);
            this.groupBoxBoardSize.Controls.Add(this.radioButton8x8);
            this.groupBoxBoardSize.Location = new System.Drawing.Point(18, 22);
            this.groupBoxBoardSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxBoardSize.Name = "groupBoxBoardSize";
            this.groupBoxBoardSize.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxBoardSize.Size = new System.Drawing.Size(426, 71);
            this.groupBoxBoardSize.TabIndex = 7;
            this.groupBoxBoardSize.TabStop = false;
            this.groupBoxBoardSize.Text = "Board Size";
            // 
            // groupBoxPlayersNames
            // 
            this.groupBoxPlayersNames.Controls.Add(this.radioButtonAgainstComputer);
            this.groupBoxPlayersNames.Controls.Add(this.radioButtonAgainstHuman);
            this.groupBoxPlayersNames.Controls.Add(this.labelPlayerOneName);
            this.groupBoxPlayersNames.Controls.Add(this.textBoxPlayerOneName);
            this.groupBoxPlayersNames.Controls.Add(this.textBoxPlayerTwoName);
            this.groupBoxPlayersNames.Controls.Add(this.labelPlayerTwoName);
            this.groupBoxPlayersNames.Location = new System.Drawing.Point(18, 102);
            this.groupBoxPlayersNames.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxPlayersNames.Name = "groupBoxPlayersNames";
            this.groupBoxPlayersNames.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxPlayersNames.Size = new System.Drawing.Size(426, 165);
            this.groupBoxPlayersNames.TabIndex = 8;
            this.groupBoxPlayersNames.TabStop = false;
            this.groupBoxPlayersNames.Text = "Players";
            // 
            // radioButtonAgainstComputer
            // 
            this.radioButtonAgainstComputer.AutoSize = true;
            this.radioButtonAgainstComputer.Location = new System.Drawing.Point(138, 91);
            this.radioButtonAgainstComputer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonAgainstComputer.Name = "radioButtonAgainstComputer";
            this.radioButtonAgainstComputer.Size = new System.Drawing.Size(104, 24);
            this.radioButtonAgainstComputer.TabIndex = 7;
            this.radioButtonAgainstComputer.Text = "Computer";
            this.radioButtonAgainstComputer.UseVisualStyleBackColor = true;
            this.radioButtonAgainstComputer.CheckedChanged += new System.EventHandler(this.radioButtonAgainstComputer_CheckedChanged);
            // 
            // radioButtonAgainstHuman
            // 
            this.radioButtonAgainstHuman.AutoSize = true;
            this.radioButtonAgainstHuman.Checked = true;
            this.radioButtonAgainstHuman.Location = new System.Drawing.Point(40, 91);
            this.radioButtonAgainstHuman.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonAgainstHuman.Name = "radioButtonAgainstHuman";
            this.radioButtonAgainstHuman.Size = new System.Drawing.Size(86, 24);
            this.radioButtonAgainstHuman.TabIndex = 8;
            this.radioButtonAgainstHuman.TabStop = true;
            this.radioButtonAgainstHuman.Text = "Human";
            this.radioButtonAgainstHuman.UseVisualStyleBackColor = true;
            this.radioButtonAgainstHuman.CheckedChanged += new System.EventHandler(this.radioButtonAgainstHuman_CheckedChanged);
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.Location = new System.Drawing.Point(324, 275);
            this.buttonStartGame.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(120, 52);
            this.buttonStartGame.TabIndex = 9;
            this.buttonStartGame.Text = "Start Game";
            this.buttonStartGame.UseVisualStyleBackColor = true;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // FormGameSettings
            // 
            this.AcceptButton = this.buttonStartGame;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 338);
            this.Controls.Add(this.buttonStartGame);
            this.Controls.Add(this.groupBoxPlayersNames);
            this.Controls.Add(this.groupBoxBoardSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormGameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.groupBoxBoardSize.ResumeLayout(false);
            this.groupBoxBoardSize.PerformLayout();
            this.groupBoxPlayersNames.ResumeLayout(false);
            this.groupBoxPlayersNames.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelPlayerOneName;
        private System.Windows.Forms.Label labelPlayerTwoName;
        private System.Windows.Forms.TextBox textBoxPlayerOneName;
        private System.Windows.Forms.TextBox textBoxPlayerTwoName;
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