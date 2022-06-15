using System;
using System.Drawing;
using System.Windows.Forms;
using CheckersEngine;
using CheckersWindowsApp.Properties;
using System.Collections.Generic;
using System.Text;

namespace CheckersWindowsApp
{
    public partial class FormCheckersGame : Form
    {
        private readonly int r_BoardSize;
        private readonly bool r_IsSecondPlayerAComputer;
        private readonly CheckersGame r_CheckersGame;
        private readonly PictureBoxBoardTile[,] r_PictureBoxBoardTiles;
        private readonly List<BoardCell> r_PossibleMovesCells;
        private BoardCell m_ChosenSourceCell;

        internal class PictureBoxBoardTile : PictureBox
        {
            public Position Position { get; private set; }

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
                i_PlayerOneName,
                i_BoardSize,
                i_BoardSize,
                i_NumberOfGamePiecesPerPlayer,
                !i_IsSecondPlayerAComputer);
            initializeScoreBoardLabels(i_PlayerOneName, i_PlayerTwoName);
            r_BoardSize = i_BoardSize;
            r_IsSecondPlayerAComputer = i_IsSecondPlayerAComputer;
            r_CheckersGame.TurnChanged += OnTurnChanged;
            r_CheckersGame.MoveMade += OnMoveMade;
            r_CheckersGame.GamePieceWasEaten += OnGamePieceWasEaten;
            r_PictureBoxBoardTiles = new PictureBoxBoardTile[r_BoardSize, r_BoardSize];
            initializePictureBoxBoardTileArray();
            m_ChosenSourceCell = null;
            r_PossibleMovesCells = new List<BoardCell>();
        }

        private void initializeScoreBoardLabels(string i_PlayerOneName, string i_PlayerTwoName)
        {
            int scorePanelWidth = Math.Max(LabelPlayerOne.Width + LabelPlayerOneScore.Width + 50,
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

        private void initializePictureBoxBoardTile(PictureBoxBoardTile pictureBoxBoardTile)
        {
            int row = pictureBoxBoardTile.Position.Row;
            int column = pictureBoxBoardTile.Position.Column;

            if((Math.Abs(row - column) % 2) == 0)
            {
                pictureBoxBoardTile.BackgroundImage = Resources.white_tile;
            }
            else
            {
                pictureBoxBoardTile.BackgroundImage = Resources.dark_tile;
                updateDarkTileContent(pictureBoxBoardTile);
            }

            pictureBoxBoardTile.Location = new Point(column * pictureBoxBoardTile.Width + 50, row * pictureBoxBoardTile.Height + 50);
            pictureBoxBoardTile.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxBoardTile.Padding = new Padding(5, 5, 5, 5);
            pictureBoxBoardTile.Click += pictureBoxBoardTile_Clicked;
            pictureBoxBoardTile.MouseEnter += pictureBoxBoardTile_MouseEnter;
        }

        private void updateDarkTileContent(PictureBoxBoardTile pictureBoxBoardTile)
        {
            GamePiece gamePieceOnTile = 
                r_CheckersGame.GameBoard.GetTheGamePieceOnRequestedPosition(pictureBoxBoardTile.Position);

            if (gamePieceOnTile != null)
            {
                switch(gamePieceOnTile.Symbol)
                {
                    case GamePiece.eSymbol.WhitePawn:
                        pictureBoxBoardTile.Image = Resources.white_pawn;
                        break;

                    case GamePiece.eSymbol.WhiteKing:
                        pictureBoxBoardTile.Image = Resources.white_king;
                        break;

                    case GamePiece.eSymbol.BlackPawn:
                        pictureBoxBoardTile.Image = Resources.black_pawn;
                        break;

                    case GamePiece.eSymbol.BlackKing:
                        pictureBoxBoardTile.Image = Resources.black_king;
                        break;
                }
            }
            else
            {
                pictureBoxBoardTile.Image = null;
            }
        }

        private void initializeComponentsSizesAndLocations(int i_Size, int i_CellSize)
        {
            PanelGameBoard.Size = new Size(i_Size * i_CellSize + 100, i_Size * i_CellSize + 100);
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
                annouceAboutTheEndOfTheGameAndAskForARematch();
            }
        }

        private void updatePlayersScore()
        {
            LabelPlayerOneScore.Text = r_CheckersGame.Player1.WinningPoints.ToString();
            LabelPlayerTwoScore.Text = r_CheckersGame.Player2.WinningPoints.ToString();
        }

        private void annouceAboutTheEndOfTheGameAndAskForARematch()
        {
            StringBuilder endOfTheGameMessage = new StringBuilder();
            DialogResult dialogResult;

            endOfTheGameMessage.AppendFormat("The winner is {0}!{1}", r_CheckersGame.Winner, Environment.NewLine);
            endOfTheGameMessage.AppendFormat("Would you like to play another round?");
            dialogResult = MessageBox.Show(endOfTheGameMessage.ToString(), "Game Over!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                r_CheckersGame.PrepareForANewGame();
                restartTurnLabels();
                refreshAllTilesContent();
            }
            else
            {
                this.Close();
            }
        }

        private void restartTurnLabels()
        {
            PanelPlayerOne.Enabled = true;
            PanelPlayerTwo.Enabled = false;
            PanelPlayerOne.BackgroundImage = Properties.Resources.wood_label;
            PanelPlayerTwo.BackgroundImage = Properties.Resources.dark_wood_label;
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

        private void pictureBoxBoardTile_Clicked(object sender, EventArgs e)
        {
            PictureBoxBoardTile clickedBoardTile = sender as PictureBoxBoardTile;
            BoardCell clickedBoardCell = r_CheckersGame.GameBoard.Board[clickedBoardTile.Position.Row, clickedBoardTile.Position.Column];

            if(m_ChosenSourceCell == null && clickedBoardCell.IsTheCellTaken() && clickedBoardCell.GamePiece.CheckIfTheGamePieceHasAnyPossibleMoves())
            {
                choosePictureBoxBoardCellTile(clickedBoardCell, clickedBoardTile);
            }
            else if(m_ChosenSourceCell == clickedBoardCell)
            {
                unchoosePictureBoxBoardCellTile();
            }
            else if(r_PossibleMovesCells.Contains(clickedBoardCell))
            {
                r_CheckersGame.MakeAMove(m_ChosenSourceCell.Position, clickedBoardCell.Position);
                unchoosePictureBoxBoardCellTile();
            }
        }

        private void choosePictureBoxBoardCellTile(BoardCell i_ChosenBoardCell, PictureBoxBoardTile i_ChosenPictureBoxBoardTile)
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

        private void unchoosePictureBoxBoardCellTile()
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

        private void emphasizePictureBoxTile(PictureBoxBoardTile chosenPictureBoxBoardTile)
        {
            chosenPictureBoxBoardTile.BackgroundImage = Resources.chosen_dark_tile;
            chosenPictureBoxBoardTile.MouseEnter -= pictureBoxBoardTile_MouseEnter;
            chosenPictureBoxBoardTile.MouseLeave -= pictureBoxBoardTile_MouseLeave;
            chosenPictureBoxBoardTile.Cursor = Cursors.Hand;
        }

        private void deEmphasizePictureBoxTile(PictureBoxBoardTile chosenPictureBoxBoardTile)
        {
            chosenPictureBoxBoardTile.BackgroundImage = Resources.dark_tile;
            chosenPictureBoxBoardTile.MouseEnter += pictureBoxBoardTile_MouseEnter;
            chosenPictureBoxBoardTile.MouseLeave += pictureBoxBoardTile_MouseLeave;
            chosenPictureBoxBoardTile.Cursor = Cursors.Default;
        }

        private void pictureBoxBoardTile_MouseEnter(object sender, EventArgs e)
        {
            PictureBoxBoardTile enteredPictureBoxBoardTile = sender as PictureBoxBoardTile;
            BoardCell enteredBoardCell = r_CheckersGame.GameBoard.Board[enteredPictureBoxBoardTile.Position.Row, enteredPictureBoxBoardTile.Position.Column];

            if(m_ChosenSourceCell == null && enteredBoardCell.IsTheCellTaken() && enteredBoardCell.GamePiece.CheckIfTheGamePieceHasAnyPossibleMoves())
            {
                enteredPictureBoxBoardTile.BackgroundImage = Resources.chosen_dark_tile;
                enteredPictureBoxBoardTile.Cursor = Cursors.Hand;
                enteredPictureBoxBoardTile.MouseLeave += pictureBoxBoardTile_MouseLeave;
            }
        }

        private void pictureBoxBoardTile_MouseLeave(object sender, EventArgs e)
        {
            PictureBoxBoardTile leftPictureBoxBoardTile = sender as PictureBoxBoardTile;

            leftPictureBoxBoardTile.BackgroundImage = Resources.dark_tile;
            leftPictureBoxBoardTile.Cursor = Cursors.Default;
            leftPictureBoxBoardTile.MouseLeave -= pictureBoxBoardTile_MouseLeave;
        }

        private void PanelPlayerOne_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}