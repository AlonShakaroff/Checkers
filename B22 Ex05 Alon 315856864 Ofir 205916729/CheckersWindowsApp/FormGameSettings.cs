using System;
using System.Windows.Forms;

namespace CheckersWindowsApp
{
    public partial class FormGameSettings : Form
    {
        private const int k_AmountOfGamePiecesPerPlayerIn6X6Board = 6;
        private const int k_AmountOfGamePiecesPerPlayerIn8X8Board = 12;
        private const int k_AmountOfGamePiecesPerPlayerIn10X10Board = 20;
        private string m_PlayerOneName;
        private string m_PlayerTwoName;
        private int m_BoardSize;
        private int m_NumberOfGamePiecesPerPlayer;
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
                m_NumberOfGamePiecesPerPlayer = k_AmountOfGamePiecesPerPlayerIn6X6Board;
            }
            else if (radioButton8x8.Checked)
            {
                m_BoardSize = 8;
                m_NumberOfGamePiecesPerPlayer = k_AmountOfGamePiecesPerPlayerIn8X8Board;
            }
            else
            {
                m_BoardSize = 10;
                m_NumberOfGamePiecesPerPlayer = k_AmountOfGamePiecesPerPlayerIn10X10Board;
            }
        }

        private void radioButtonAgainstComputer_CheckedChanged(object i_Sender, EventArgs i_E)
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

        private void radioButtonAgainstHuman_CheckedChanged(object i_Sender, EventArgs i_E)
        {
            textBoxPlayerTwoName.Text = string.Empty;
            textBoxPlayerTwoName.Enabled = true;
        }

        private void buttonStartGame_Click(object i_Sender, EventArgs i_E)
        {
            if(checkIfAnyPlayersNameIsMissing())
            {
                MessageBox.Show("You must enter players' names before starting the game.");
            }
            else if(checkIfAnyPlayersNameContainNonAlphabeticalCharacter())
            {
                MessageBox.Show("Player's name should be contained only by alphabetical characters.");
            }
            else if(checkIfBothPlayersHaveTheSameName())
            {
                MessageBox.Show("The players must have different names.");
            }
            else
            {
                gatherGameSettings();
                startTheGame();
            }
        }

        private void gatherGameSettings()
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

        private void startTheGame()
        {
            FormCheckersGame checkers = new FormCheckersGame(
                m_PlayerOneName,
                m_PlayerTwoName,
                m_BoardSize,
                m_NumberOfGamePiecesPerPlayer,
                m_IsPlayerTwoAComputer);

            this.Hide();
            checkers.ShowDialog();
            this.Close();
        }

        private bool checkIfBothPlayersHaveTheSameName()
        {
            return textBoxPlayerOneName.Text.Equals(textBoxPlayerTwoName.Text);
        }

        private bool checkIfAnyPlayersNameIsMissing()
        {
            return textBoxPlayerOneName.Text.Equals(string.Empty) || textBoxPlayerTwoName.Text.Equals(string.Empty);
        }
    }
}