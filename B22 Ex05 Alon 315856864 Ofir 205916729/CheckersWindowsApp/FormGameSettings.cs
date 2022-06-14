using System;
using System.Windows.Forms;

namespace CheckersWindowsApp
{
    public partial class FormGameSettings : Form
    {
        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void checkIfTheSecondPlayerIsAComputer()
        {
            m_IsSecondPlayerAComputer = radioButtonAgainstComputer.Checked;
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
            textBoxSecondPlayersName.Text = "Computer";
            textBoxSecondPlayersName.Enabled = false;
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
            textBoxSecondPlayersName.Text = String.Empty;
            textBoxSecondPlayersName.Enabled = true;
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
            m_FirstPlayerName = textBoxFirstPlayersName.Text;
            m_SecondPlayerName = textBoxSecondPlayersName.Text;
            getChosenBoardSize();
            checkIfTheSecondPlayerIsAComputer();
        }

        private bool checkIfAnyPlayersNameContainNonAlphabeticalCharacter()
        {
            return checkIfPlayersNameContainsNoneAlphabeticalCharacters(textBoxFirstPlayersName) 
                || checkIfPlayersNameContainsNoneAlphabeticalCharacters(textBoxSecondPlayersName);
        }

        private void StartTheGame()
        {
            CheckersBoard checkers = new CheckersBoard();

            this.Hide();
            checkers.ShowDialog();
        }

        private bool CheckIfBothPlayersHaveTheSameName()
        {
            return textBoxFirstPlayersName.Text.Equals(textBoxSecondPlayersName.Text);
        }

        private bool checkIfAnyPlayersNameIsMissing()
        {
            return textBoxFirstPlayersName.Text.Equals(String.Empty) || textBoxSecondPlayersName.Text.Equals(String.Empty);
        }
    }
}