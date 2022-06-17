using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using CheckersEngine;
using CheckersWindowsApp.Properties;

namespace CheckersWindowsApp
{
    public partial class FormCheckersGame : Form
    {
        private readonly int r_BoardSize;
        private readonly CheckersGame r_CheckersGame;
        private readonly PictureBoxBoardTile[,] r_PictureBoxBoardTiles;
        private readonly List<BoardCell> r_PossibleMovesCells;
        private BoardCell m_ChosenSourceCell;
        private bool m_ComputerIsCurrentlyPlaying = false;

        internal class PictureBoxBoardTile : PictureBox
        {
            public Position Position { get; }

            public PictureBoxBoardTile(Position i_Position, int i_TileSize)
            {
                Position = i_Position;
                this.Size = new Size(i_TileSize, i_TileSize);
            }
        }

        public FormCheckersGame(string i_PlayerOneName, string i_PlayerTwoName, int i_BoardSize, int i_NumberOfGamePiecesPerPlayer, bool i_IsSecondPlayerAComputer)
        {
            InitializeComponent();
            r_CheckersGame = new CheckersGame(
                i_PlayerOneName,
                i_PlayerTwoName,
                i_BoardSize,
                i_BoardSize,
                i_NumberOfGamePiecesPerPlayer,
                !i_IsSecondPlayerAComputer);
            initializeScoreBoardLabels(i_PlayerOneName, i_PlayerTwoName);
            r_BoardSize = i_BoardSize;
            r_CheckersGame.TurnChanged += OnTurnChanged;
            r_CheckersGame.MoveMade += OnMoveMade;
            r_CheckersGame.GamePieceWasEaten += OnGamePieceWasEaten;
            r_PictureBoxBoardTiles = new PictureBoxBoardTile[r_BoardSize, r_BoardSize];
            initializePictureBoxBoardTileArray();
            m_ChosenSourceCell = null;
            r_PossibleMovesCells = new List<BoardCell>();
            r_CheckersGame.ComputersNeedsToPlay += OnComputerNeedsToPlay;
        }

        private void initializeScoreBoardLabels(string i_PlayerOneName, string i_PlayerTwoName)
        {
            int scorePanelWidth = Math.Max(
                LabelPlayerOne.Width + LabelPlayerOneScore.Width + 50,
                LabelPlayerTwo.Width + LabelPlayerTwoScore.Width + 50);

            LabelPlayerOne.Text = i_PlayerOneName;
            LabelPlayerTwo.Text = i_PlayerTwoName;
            PanelPlayerOne.Width = PanelPlayerTwo.Width = Math.Max(scorePanelWidth, 200);
            PanelPlayerTwo.Enabled = false;
            PanelPlayerTwo.BackgroundImage = Resources.dark_wood_label;
        }

        private void initializePictureBoxBoardTileArray()
        {
            int cellTileSize = r_BoardSize == 6 ? 95 : r_BoardSize == 8 ? 75 : 60;

            initializeComponentsSizesAndLocations(r_BoardSize, cellTileSize);

            for (int i = 0; i < r_BoardSize; ++i)
            {
                for (int j = 0; j < r_BoardSize; ++j)
                {
                    r_PictureBoxBoardTiles[i, j] = new PictureBoxBoardTile(new Position(i, j), cellTileSize);
                    initializePictureBoxBoardTile(r_PictureBoxBoardTiles[i, j]);
                    PanelGameBoard.Controls.Add(r_PictureBoxBoardTiles[i, j]);
                }
            }
        }

        private void initializePictureBoxBoardTile(PictureBoxBoardTile i_PictureBoxBoardTile)
        {
            int row = i_PictureBoxBoardTile.Position.Row;
            int column = i_PictureBoxBoardTile.Position.Column;

            if((Math.Abs(row - column) % 2) == 0)
            {
                i_PictureBoxBoardTile.BackgroundImage = Resources.white_tile;
            }
            else
            {
                i_PictureBoxBoardTile.BackgroundImage = Resources.dark_tile;
                updateDarkTileContent(i_PictureBoxBoardTile);
            }

            i_PictureBoxBoardTile.Location = new Point((column * i_PictureBoxBoardTile.Width) + 50, (row * i_PictureBoxBoardTile.Height) + 50);
            i_PictureBoxBoardTile.SizeMode = PictureBoxSizeMode.StretchImage;
            i_PictureBoxBoardTile.Padding = new Padding(5, 5, 5, 5);
            i_PictureBoxBoardTile.Click += pictureBoxBoardTile_Clicked;
            i_PictureBoxBoardTile.MouseEnter += pictureBoxBoardTile_MouseEnter;
        }

        private void updateDarkTileContent(PictureBoxBoardTile i_PictureBoxBoardTile)
        {
            GamePiece gamePieceOnTile = 
                r_CheckersGame.GameBoard.GetTheGamePieceOnRequestedPosition(i_PictureBoxBoardTile.Position);

            if (gamePieceOnTile != null)
            {
                switch(gamePieceOnTile.Symbol)
                {
                    case GamePiece.eSymbol.WhitePawn:
                        i_PictureBoxBoardTile.Image = Resources.white_pawn;
                        break;

                    case GamePiece.eSymbol.WhiteKing:
                        i_PictureBoxBoardTile.Image = Resources.white_king;
                        break;

                    case GamePiece.eSymbol.BlackPawn:
                        i_PictureBoxBoardTile.Image = Resources.black_pawn;
                        break;

                    case GamePiece.eSymbol.BlackKing:
                        i_PictureBoxBoardTile.Image = Resources.black_king;
                        break;
                }
            }
            else
            {
                i_PictureBoxBoardTile.Image = null;
            }
        }

        private void initializeComponentsSizesAndLocations(int i_Size, int i_CellSize)
        {
            PanelGameBoard.Size = new Size((i_Size * i_CellSize) + 100, (i_Size * i_CellSize) + 100);
            Size = new Size(PanelGameBoard.Width + 100, PanelGameBoard.Height + 130);
            PanelPlayerOne.Left = 50;
            PanelPlayerOne.Top = 20;
            PanelPlayerTwo.Left = this.Size.Width - PanelPlayerTwo.Width - 50;
            PanelPlayerTwo.Top = 20;
            MinimumSize = Size;
            PanelGameBoard.Left = 50;
            PanelGameBoard.Top = PanelPlayerOne.Top + PanelPlayerOne.Height + 10;
        }

        public void OnTurnChanged()
        {
            Image swappedImage = PanelPlayerOne.BackgroundImage;

            PanelPlayerOne.Enabled = !PanelPlayerOne.Enabled;
            PanelPlayerTwo.Enabled = !PanelPlayerTwo.Enabled;
            PanelPlayerOne.BackgroundImage = PanelPlayerTwo.BackgroundImage;
            PanelPlayerTwo.BackgroundImage = swappedImage;
        }

        public void OnMoveMade(BoardCell i_SourceBoardCell, BoardCell i_DestinationBoardCell)
        {
            updateDarkTileContent(r_PictureBoxBoardTiles[i_SourceBoardCell.Position.Row, i_SourceBoardCell.Position.Column]);
            updateDarkTileContent(r_PictureBoxBoardTiles[i_DestinationBoardCell.Position.Row, i_DestinationBoardCell.Position.Column]);

            if(r_CheckersGame.CheckIfTheGameIsStillGoing())
            {
                updatePlayersScore();
                if(!announceAboutTheEndOfTheGameAndAskForARematch())
                {
                    this.Close();
                }
            }
        }

        private void updatePlayersScore()
        {
            LabelPlayerOneScore.Text = r_CheckersGame.Player1.WinningPoints.ToString();
            LabelPlayerTwoScore.Text = r_CheckersGame.Player2.WinningPoints.ToString();
        }

        private bool announceAboutTheEndOfTheGameAndAskForARematch()
        {
            StringBuilder endOfTheGameMessage = new StringBuilder();
            DialogResult dialogResult;
            bool rematch;

            switch (r_CheckersGame.GameStatus)
            {
                case CheckersGame.eGameStatus.Draw:
                    endOfTheGameMessage.Append("It's a draw!");
                    break;
                case CheckersGame.eGameStatus.HasAWinner:
                    endOfTheGameMessage.AppendFormat("The winner is {0}!{1}", r_CheckersGame.Winner, Environment.NewLine);
                    break;
            }

            endOfTheGameMessage.AppendFormat("Would you like to play another round?");
            dialogResult = MessageBox.Show(endOfTheGameMessage.ToString(), "Game Over!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                r_CheckersGame.PrepareForANewGame();
                restartTurnLabels();
                refreshAllTilesContent();
                rematch = true;
            }
            else
            {
                rematch = false;
            }

            return rematch;
        }

        private void restartTurnLabels()
        {
            PanelPlayerOne.Enabled = true;
            PanelPlayerTwo.Enabled = false;
            PanelPlayerOne.BackgroundImage = Resources.wood_label;
            PanelPlayerTwo.BackgroundImage = Resources.dark_wood_label;
        }

        private void refreshAllTilesContent()
        {
            foreach (PictureBoxBoardTile pictureBoxBoardTile in r_PictureBoxBoardTiles)
            {
                if ((Math.Abs(pictureBoxBoardTile.Position.Row - pictureBoxBoardTile.Position.Column) % 2) != 0)
                {
                    updateDarkTileContent(pictureBoxBoardTile);
                }
            }
        }

        public void OnGamePieceWasEaten(BoardCell i_EatenBoardCell)
        {
            updateDarkTileContent(r_PictureBoxBoardTiles[i_EatenBoardCell.Position.Row, i_EatenBoardCell.Position.Column]);
        }

        private void pictureBoxBoardTile_Clicked(object i_Sender, EventArgs i_E)
        {
            PictureBoxBoardTile clickedBoardTile = i_Sender as PictureBoxBoardTile;
            BoardCell clickedBoardCell;

            if (clickedBoardTile != null && !m_ComputerIsCurrentlyPlaying)
            {
                clickedBoardCell = r_CheckersGame.GameBoard.Board[clickedBoardTile.Position.Row, clickedBoardTile.Position.Column];

                if(m_ChosenSourceCell == null && clickedBoardCell.IsTheCellTaken() && clickedBoardCell.GamePiece.CheckIfTheGamePieceHasAnyPossibleMoves())
                {
                    selectPictureBoxBoardCellTile(clickedBoardCell, clickedBoardTile);
                }
                else if(m_ChosenSourceCell == clickedBoardCell)
                {
                    deselectPictureBoxBoardCellTile();
                }
                else if(r_PossibleMovesCells.Contains(clickedBoardCell))
                {
                    r_CheckersGame.MakeAMove(m_ChosenSourceCell?.Position, clickedBoardCell.Position);
                    deselectPictureBoxBoardCellTile();
                }
                else if(m_ChosenSourceCell == null)
                {
                    MessageBox.Show("There aren't any available moves from that tile", "Invalid move");
                }
                else
                {
                    MessageBox.Show("That is not a possible move for this game piece.", "Invalid move");
                }
            }
        }

        private void selectPictureBoxBoardCellTile(BoardCell i_ChosenBoardCell, PictureBoxBoardTile i_ChosenPictureBoxBoardTile)
        {
            m_ChosenSourceCell = i_ChosenBoardCell;
            foreach(Position possibleMove in m_ChosenSourceCell.GamePiece.PossibleMoves)
            {
                BoardCell possibleMoveBoardCell = r_CheckersGame.GameBoard.Board[possibleMove.Row, possibleMove.Column];
                r_PossibleMovesCells.Add(possibleMoveBoardCell);
                emphasizePictureBoxTile(r_PictureBoxBoardTiles[possibleMove.Row, possibleMove.Column]);
            }

            emphasizePictureBoxTile(i_ChosenPictureBoxBoardTile);
        }

        private void deselectPictureBoxBoardCellTile()
        {
            Position possibleMovePosition;
            PictureBoxBoardTile chosenPictureBoxBoardTile = r_PictureBoxBoardTiles[m_ChosenSourceCell.Position.Row, m_ChosenSourceCell.Position.Column];

            m_ChosenSourceCell = null;
            foreach (BoardCell possibleMoveCell in r_PossibleMovesCells)
            {
                possibleMovePosition = possibleMoveCell.Position;
                deEmphasizePictureBoxTile(r_PictureBoxBoardTiles[possibleMovePosition.Row, possibleMovePosition.Column]);
            }

            deEmphasizePictureBoxTile(chosenPictureBoxBoardTile);
            r_PossibleMovesCells.Clear();
        }

        private void emphasizePictureBoxTile(PictureBoxBoardTile i_ChosenPictureBoxBoardTile)
        {
            i_ChosenPictureBoxBoardTile.BackgroundImage = Resources.chosen_dark_tile;
            i_ChosenPictureBoxBoardTile.MouseEnter -= pictureBoxBoardTile_MouseEnter;
            i_ChosenPictureBoxBoardTile.MouseLeave -= pictureBoxBoardTile_MouseLeave;
            i_ChosenPictureBoxBoardTile.Cursor = Cursors.Hand;
        }

        private void deEmphasizePictureBoxTile(PictureBoxBoardTile i_ChosenPictureBoxBoardTile)
        {
            i_ChosenPictureBoxBoardTile.BackgroundImage = Resources.dark_tile;
            i_ChosenPictureBoxBoardTile.MouseEnter += pictureBoxBoardTile_MouseEnter;
            i_ChosenPictureBoxBoardTile.MouseLeave += pictureBoxBoardTile_MouseLeave;
            i_ChosenPictureBoxBoardTile.Cursor = Cursors.Default;
        }

        private void pictureBoxBoardTile_MouseEnter(object i_Sender, EventArgs i_E)
        {
            PictureBoxBoardTile enteredPictureBoxBoardTile = i_Sender as PictureBoxBoardTile;
            BoardCell enteredBoardCell;

            if (enteredPictureBoxBoardTile != null && !m_ComputerIsCurrentlyPlaying)
            {
                enteredBoardCell = r_CheckersGame.GameBoard.Board[enteredPictureBoxBoardTile.Position.Row, enteredPictureBoxBoardTile.Position.Column];

                if(m_ChosenSourceCell == null && enteredBoardCell.IsTheCellTaken() && enteredBoardCell.GamePiece.CheckIfTheGamePieceHasAnyPossibleMoves())
                {
                    enteredPictureBoxBoardTile.BackgroundImage = Resources.chosen_dark_tile;
                    enteredPictureBoxBoardTile.Cursor = Cursors.Hand;
                    enteredPictureBoxBoardTile.MouseLeave += pictureBoxBoardTile_MouseLeave;
                }
            }
        }

        private void pictureBoxBoardTile_MouseLeave(object i_Sender, EventArgs i_E)
        {
            PictureBoxBoardTile leftPictureBoxBoardTile = i_Sender as PictureBoxBoardTile;

            if(leftPictureBoxBoardTile != null && !m_ComputerIsCurrentlyPlaying)
            {
                leftPictureBoxBoardTile.BackgroundImage = Resources.dark_tile;
                leftPictureBoxBoardTile.Cursor = Cursors.Default;
                leftPictureBoxBoardTile.MouseLeave -= pictureBoxBoardTile_MouseLeave;
            }
        }

        private void OnComputerNeedsToPlay()
        {
            m_ComputerIsCurrentlyPlaying = true;
            TimerComputerTurnDelay.Start();
        }

        private void formCheckersGame_FormClosing(object i_Sender, FormClosingEventArgs i_E)
        {
            if(m_ComputerIsCurrentlyPlaying)
            {
                i_E.Cancel = true;
            }
            else
            {
                r_CheckersGame.SwitchPlayersTurns();
                r_CheckersGame.FinishTheGame();
                i_E.Cancel = announceAboutTheEndOfTheGameAndAskForARematch();
            }
        }

        private void timerComputerTurnDelay_Tick(object i_Sender, EventArgs i_E)
        {
            Position sourcePosition, destinationPosition;

            TimerComputerTurnDelay.Stop();
            r_CheckersGame.GetAMoveFromTheComputer(out sourcePosition, out destinationPosition);
            r_CheckersGame.MakeAMove(sourcePosition, destinationPosition);
            m_ComputerIsCurrentlyPlaying = false;
        }
    }
}