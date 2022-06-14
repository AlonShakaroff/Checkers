using System;
using System.Windows.Forms;

namespace CheckersWindowsApp
{
    public partial class FormCheckersBoard : Form
    {
        private int m_BoardSize;
        private bool m_IsSecondPlayerAComputer;

        public FormCheckersBoard(string i_FirstPlayerName, string i_SecondPlayerName, int i_BoardSize, bool i_IsSecondPlayerAComputer)
        {
            InitializeComponent();

            LabelPlayerOne.Text = i_FirstPlayerName;
            LabelPlayerTwo.Text = i_SecondPlayerName;
            m_BoardSize = i_BoardSize;
            m_IsSecondPlayerAComputer = i_IsSecondPlayerAComputer;
        }

        private void CheckersBoard_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PlayerOneLabel_Click(object sender, EventArgs e)
        {

        }

        private void PlayerTwoLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
