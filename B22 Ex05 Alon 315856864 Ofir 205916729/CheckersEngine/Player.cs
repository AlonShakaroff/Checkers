using System.Collections.Generic;

namespace CheckersEngine
{
    public class Player
    {
        //-------------------------------------------------------------------------------Members-------------------------------------------------------------------------------//
        private readonly int r_InitialStoneAmount;
        private readonly bool r_IsPlayingFirst;

        //------------------------------------------------------------------------------Properties-----------------------------------------------------------------------------//
        public int NumberOfGamePiecesLeft { get; private set; }

        public int WinningPoints { get; set; }

        public string Name { get; }

        public List<GamePiece> GamePieces { get; }

        //-----------------------------------------------------------------------------Constructors----------------------------------------------------------------------------//
        public Player(string i_PlayerName, int i_NumberOfGamePieces, bool i_IsThePlayerPlayingFirst, int i_NumberOfRowsOnTheGameBoard)
        {
            Name = i_PlayerName;
            GamePieces = new List<GamePiece>(i_NumberOfGamePieces);
            r_InitialStoneAmount = i_NumberOfGamePieces;
            r_IsPlayingFirst = i_IsThePlayerPlayingFirst;
            WinningPoints = 0;

            InitializeGamePiecesPositions(i_NumberOfRowsOnTheGameBoard);
        }

        //----------------------------------------------------------------------------Initialization---------------------------------------------------------------------------//
        public void InitializeGamePiecesPositions(int i_NumberOfRowsOnTheGameBoard)
        {
            int numberOfGamePiecesInARow = i_NumberOfRowsOnTheGameBoard / 2;
            Position currentGamePiecePosition = calculateTheStartingPositionOfTheGamePiecesDeployment(i_NumberOfRowsOnTheGameBoard);
            int currentRow = currentGamePiecePosition.Row, currentColumn = currentGamePiecePosition.Column;
            char pawnSymbol = r_IsPlayingFirst ? GamePiece.k_FirstPlayerPawnSymbol : GamePiece.k_SecondPlayerPawnSymbol;
            GamePiece.ePlayerProperty playerProperty = r_IsPlayingFirst ? GamePiece.ePlayerProperty.Player1 : GamePiece.ePlayerProperty.Player2;

            NumberOfGamePiecesLeft = r_InitialStoneAmount;
            GamePieces.Clear();
            for (int pieceCounter = 0; pieceCounter < r_InitialStoneAmount; ++pieceCounter)
            {
                GamePieces.Add(new GamePiece(pawnSymbol, currentGamePiecePosition, playerProperty));
                calculateTheStartingPositionOfTheNextGamePiece(pieceCounter + 1, ref currentRow, ref currentColumn, out currentGamePiecePosition, numberOfGamePiecesInARow);
            }
        }

        private Position calculateTheStartingPositionOfTheGamePiecesDeployment(int i_NumberOfRowsOnTheGameBoard)
        {
            int startingRow, startingColumn;

            if (r_IsPlayingFirst == false)
            {
                startingRow = 0;
                startingColumn = 1;
            }
            else
            {
                switch (i_NumberOfRowsOnTheGameBoard)
                {
                    case 6:
                        startingRow = 4;
                        startingColumn = 1;
                        break;
                    case 10:
                        startingRow = 6;
                        startingColumn = 1;
                        break;
                    default:
                        startingRow = 5;
                        startingColumn = 0;
                        break;
                }
            }

            return new Position(startingRow, startingColumn);
        }

        public int CalculateGamePiecesPoints()
        {
            int calculatedPoints = 0;

            foreach(GamePiece currentGamePiece in GamePieces)
            {
                if(currentGamePiece.IsKing)
                {
                    calculatedPoints += GamePiece.k_PointsForAKing;
                }
                else
                {
                    calculatedPoints += GamePiece.k_PointsForAPawn;
                }
            }

            return calculatedPoints;
        }

        private void calculateTheStartingPositionOfTheNextGamePiece(
            int i_PieceCounter,
            ref int io_CurrentRow,
            ref int io_CurrentColumn,
            out Position o_GamePiecePosition,
            int i_NumberOfGamePiecesInARow
            )
        {
            if (i_PieceCounter % i_NumberOfGamePiecesInARow == 0)
            {
                io_CurrentRow++;

                if(io_CurrentRow % 2 == 0)
                {
                    io_CurrentColumn = 1;
                }
                else
                {
                    io_CurrentColumn = 0;
                }
            }
            else
            {
                io_CurrentColumn += 2;
            }

            o_GamePiecePosition = new Position(io_CurrentRow, io_CurrentColumn);
        }


        //-------------------------------------------------------------------------------Checks--------------------------------------------------------------------------------//
        public bool CheckIfThePlayerHasAnyPossibleMoves()
        {
            bool thePlayerHasPossibleMoves = false;

            foreach(GamePiece currentGamePiece in GamePieces)
            {
                if (currentGamePiece.CheckIfTheGamePieceHasAnyPossibleMoves())
                {
                    thePlayerHasPossibleMoves = true;
                    break;
                }
            }

            return thePlayerHasPossibleMoves;
        }

        public bool CheckIfThePlayerIsPlayingFirst()
        {
            return r_IsPlayingFirst;
        }

        //-------------------------------------------------------------------------------Methods-------------------------------------------------------------------------------//

        public void ClearPlayersPossibleMoves()
        {
            foreach (GamePiece currentGamePiece in GamePieces)
            {
                currentGamePiece.ClearGamePiecePossibleMoves();
            }
        }

        public void DeleteAGamePieceFromGamePiecesList(GamePiece i_DeletedGamePiece)
        {
            GamePieces.Remove(i_DeletedGamePiece);
            NumberOfGamePiecesLeft--;
        }
    }
}