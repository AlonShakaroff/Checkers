using System;
using System.Windows.Forms;

namespace CheckersWindowsApp
{
    public partial class FormCheckersBoard : Form
    {
        private readonly int r_BoardSize;
        private readonly bool r_IsSecondPlayerAComputer;

        public FormCheckersBoard(string i_FirstPlayerName, string i_SecondPlayerName, int i_BoardSize, bool i_IsSecondPlayerAComputer)
        {
            InitializeComponent();

            LabelPlayerOne.Text = i_FirstPlayerName;
            LabelPlayerTwo.Text = i_SecondPlayerName;
            r_BoardSize = i_BoardSize;
            r_IsSecondPlayerAComputer = i_IsSecondPlayerAComputer;
        }
    }
}