using System;
using System.Drawing;
using System.Windows.Forms;
using CheckersEngine;

namespace CheckersWindowsApp
{
    public partial class FormCheckersGame : Form
    {
        private readonly int r_BoardSize;
        private readonly bool r_IsSecondPlayerAComputer;
        private readonly CheckersGame r_CheckersGame;
        private readonly PictureBoxBoardTile[,] r_PictureBoxBoardTiles;

        internal class PictureBoxBoardTile : PictureBox
        {
            public Position Position { get; private set; }

            public PictureBoxBoardTile(Position i_Position, int i_TileSize)
            {
                Position = i_Position;
                this.Size = new Size(i_TileSize, i_TileSize);
            }
        }

        public FormCheckersGame(string i_FirstPlayerName, string i_SecondPlayerName, int i_BoardSize, int i_NumberOfGamePiecesPerPlayer, bool i_IsSecondPlayerAComputer)
        {
            InitializeComponent();
            r_CheckersGame = new CheckersGame(
                i_FirstPlayerName,
                i_FirstPlayerName,
                i_BoardSize,
                i_BoardSize,
                i_NumberOfGamePiecesPerPlayer,
                !i_IsSecondPlayerAComputer);
            initializeScoreBoardLabels(i_FirstPlayerName, i_SecondPlayerName);
            r_BoardSize = i_BoardSize;
            r_IsSecondPlayerAComputer = i_IsSecondPlayerAComputer;
            r_CheckersGame.TurnChanged += OnTurnChanged;
            r_CheckersGame.MoveMade += OnMoveMade;
            r_CheckersGame.GamePieceWasEaten += OnGamePieceWasEaten;
            r_PictureBoxBoardTiles = new PictureBoxBoardTile[r_BoardSize, r_BoardSize];
            initializePictureBoxBoardTileArray();
        }

        private void initializeScoreBoardLabels(string i_FirstPlayerName, string i_SecondPlayerName)
        {
            int scorePanelWidth = Math.Max(LabelPlayerOne.Width + LabelPlayerOneScore.Width + 50,
                LabelPlayerTwo.Width + LabelPlayerTwoScore.Width + 50);
            PanelPlayerOne.Width = PanelPlayerTwo.Width = Math.Max(scorePanelWidth, 200);
        }

        private void initializePictureBoxBoardTileArray()
        {
            int cellTileSize = r_BoardSize == 6 ? 95 : r_BoardSize == 8 ? 75 : 60;

            initializeComponentsSizes(r_BoardSize, cellTileSize);

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
                pictureBoxBoardTile.BackgroundImage = Properties.Resources.white_tile;
            }
            else
            {
                pictureBoxBoardTile.BackgroundImage = Properties.Resources.dark_tile;
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
                        pictureBoxBoardTile.Image = Properties.Resources.white_pawn;
                        break;

                    case GamePiece.eSymbol.WhiteKing:
                        pictureBoxBoardTile.Image = Properties.Resources.white_king;
                        break;

                    case GamePiece.eSymbol.BlackPawn:
                        pictureBoxBoardTile.Image = Properties.Resources.black_pawn;
                        break;

                    case GamePiece.eSymbol.BlackKing:
                        pictureBoxBoardTile.Image = Properties.Resources.black_king;
                        break;
                }
            }
            else
            {
                pictureBoxBoardTile.Image = null;
            }
        }

        private void initializeComponentsSizes(int i_Size, int i_CellSize)
        {
            PanelGameBoard.Size = new Size(i_Size * i_CellSize + 100, i_Size * i_CellSize + 100);
            Size = new Size(PanelGameBoard.Width + 100, PanelGameBoard.Height + 120);
            PanelPlayerOne.Left = 50;
            PanelPlayerOne.Top = 20;
            PanelPlayerTwo.Left = this.Size.Width - PanelPlayerTwo.Width - 50;
            PanelPlayerTwo.Top = 20;
            MinimumSize = Size;
            PanelGameBoard.Left = 50;
            PanelGameBoard.Top = PanelPlayerOne.Top + PanelPlayerOne.Height;
        }

        public void OnTurnChanged()
        {

        }

        public void OnMoveMade(BoardCell i_SourceBoardCell, BoardCell i_DestinationBoardCell)
        {

        }

        public void OnGamePieceWasEaten(BoardCell i_EatenBoardCell)
        {

        }

        private void pictureBoxBoardTile_Clicked(object sender, EventArgs e)
        {

        }

        private void pictureBoxBoardTile_MouseEnter(object sender, EventArgs e)
        {

        }

        private void PanelPlayerOne_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}