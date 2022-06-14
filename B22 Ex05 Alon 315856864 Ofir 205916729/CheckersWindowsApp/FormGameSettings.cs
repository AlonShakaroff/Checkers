using System;
using System.Windows.Forms;

namespace CheckersWindowsApp
{
    public partial class FormGameSettings : Form
    {
        private string m_PlayerOneName;
        private string m_PlayerTwoName;
        private int m_BoardSize;
        private bool m_IsPlayerTwoAComputer;

        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void checkIfTheSecondPlayerIsAComputer()
        {
            m_IsPlayerTwoAComputer = radioButtonAgainstComputer.Checked;
        }

        private void getChosenBoardSize()
        {
            if (radioButton6x6.Checked)
            {
                m_BoardSize = 6;
            }
            else if (radioButton8x8.Checked)
            {
                m_BoardSize = 8;
            }
            else
            {
                m_BoardSize = 10;
            }
        }

        private void radioButtonAgainstComputer_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPlayerTwoName.Text = "Computer";
            textBoxPlayerTwoName.Enabled = false;
        }

        private bool checkIfPlayersNameContainsNoneAlphabeticalCharacters(TextBox i_TextBox)
        {
            bool validName = true;

            foreach(char currentCharacter in i_TextBox.Text)
            {
                if (!char.IsLetter(currentCharacter))
                {
                    validName = false;
                    break;
                }
            }

            return !validName;
        }

        private void radioButtonAgainstHuman_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPlayerTwoName.Text = String.Empty;
            textBoxPlayerTwoName.Enabled = true;
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            if(checkIfAnyPlayersNameIsMissing())
            {
                MessageBox.Show("You must enter players' names before starting the game.");
            }
            else if(checkIfAnyPlayersNameContainNonAlphabeticalCharacter())
            {
                MessageBox.Show("Player's name should be contained only by alphabetical characters.");
            }
            else if(CheckIfBothPlayersHaveTheSameName())
            {
                MessageBox.Show("The players must have different names.");
            }
            else
            {
                GatherGameSettings();
                StartTheGame();
            }
        }

        private void GatherGameSettings()
        {
            m_PlayerOneName = textBoxPlayerOneName.Text;
            m_PlayerTwoName = textBoxPlayerTwoName.Text;
            getChosenBoardSize();
            checkIfTheSecondPlayerIsAComputer();
        }

        private bool checkIfAnyPlayersNameContainNonAlphabeticalCharacter()
        {
            return checkIfPlayersNameContainsNoneAlphabeticalCharacters(textBoxPlayerOneName) 
                || checkIfPlayersNameContainsNoneAlphabeticalCharacters(textBoxPlayerTwoName);
        }

        private void StartTheGame()
        {
            FormCheckersBoard checkers = new FormCheckersBoard(m_PlayerOneName, m_PlayerTwoName, m_BoardSize, m_IsPlayerTwoAComputer);

            this.Hide();
            checkers.ShowDialog();
        }

        private bool CheckIfBothPlayersHaveTheSameName()
        {
            return textBoxPlayerOneName.Text.Equals(textBoxPlayerTwoName.Text);
        }

        private bool checkIfAnyPlayersNameIsMissing()
        {
            return textBoxPlayerOneName.Text.Equals(String.Empty) || textBoxPlayerTwoName.Text.Equals(String.Empty);
        }
    }
}