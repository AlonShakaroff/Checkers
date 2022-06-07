using System.Collections.Generic;

namespace CheckersLogicEngine
{
    public class GameBoard
    {
        //-------------------------------------------------------------------------------Members-------------------------------------------------------------------------------//
        private readonly BoardCell[,] r_CellsMatrix;
        private readonly int r_NumberOfRows;
        private readonly int r_NumberOfColumns;

        //------------------------------------------------------------------------------Properties-----------------------------------------------------------------------------//
        public int NumberOfRows
        {
            get
            {
                return r_NumberOfRows;
            }
        }

        public int NumberOfColumns
        {
            get
            {
                return r_NumberOfColumns;
            }
        }

        public BoardCell[,] Board
        {
            get
            {
                return r_CellsMatrix;
            }
        }

        //-----------------------------------------------------------------------------Constructors----------------------------------------------------------------------------//
        public GameBoard(int i_NumberOfRows, int i_NumberOfColumns, List<GamePiece> i_FirstPlayerGamePieces, List<GamePiece> i_SecondPlayerGamePieces)
        {
            r_NumberOfRows = i_NumberOfRows;
            r_NumberOfColumns = i_NumberOfColumns;
            r_CellsMatrix = new BoardCell[r_NumberOfRows, r_NumberOfColumns];
            for (int i = 0; i < r_NumberOfRows; ++i)
            {
                for (int j = 0; j < r_NumberOfColumns; ++j)
                {
                    r_CellsMatrix[i, j] = new BoardCell();
                }
            }

            initializeTheGameBoardWithGamePiecesOfAPlayer(i_FirstPlayerGamePieces);
            initializeTheGameBoardWithGamePiecesOfAPlayer(i_SecondPlayerGamePieces);
        }

        private void initializeTheGameBoardWithGamePiecesOfAPlayer(List<GamePiece> i_PlayerGamePieces)
        {
            Position gamePiecePosition;

            foreach(GamePiece playerGamePiece in i_PlayerGamePieces)
            {
                gamePiecePosition = playerGamePiece.Position;
                r_CellsMatrix[gamePiecePosition.Row, gamePiecePosition.Column].GamePiece = playerGamePiece;
            }
        }

        //-------------------------------------------------------------------------------Getters-------------------------------------------------------------------------------//
        public GamePiece GetTheGamePieceOnRequestedPosition(Position i_RequestedPosition)
        {
            return r_CellsMatrix[i_RequestedPosition.Row, i_RequestedPosition.Column].GamePiece;
        }

        //-------------------------------------------------------------------------------Methods-------------------------------------------------------------------------------//
        public void MoveAGamePieceToANewPosition(Position i_CurrentPosition, Position i_NewPosition)
        {
            r_CellsMatrix[i_NewPosition.Row, i_NewPosition.Column].GamePiece = r_CellsMatrix[i_CurrentPosition.Row, i_CurrentPosition.Column].GamePiece;
            r_CellsMatrix[i_NewPosition.Row, i_NewPosition.Column].GamePiece.Position = i_NewPosition;
            r_CellsMatrix[i_CurrentPosition.Row, i_CurrentPosition.Column].GamePiece = null;
        }

        public bool CheckIfThePositionIsInTheBoardBoundaries(Position i_PositionToCheck)
        {
            bool inRowsLines = i_PositionToCheck.Row >= 0 && i_PositionToCheck.Row <= r_NumberOfRows - 1;
            bool inColumnsLines = i_PositionToCheck.Column >= 0 && i_PositionToCheck.Column <= r_NumberOfColumns - 1;

            return inRowsLines && inColumnsLines;
        }

        public bool CheckIfTheCellHasAGamePieceOnIt(Position i_PositionToCheck)
        {
            return r_CellsMatrix[i_PositionToCheck.Row, i_PositionToCheck.Column].IsTheCellTaken();
        }

        public bool CheckIfTheGamePiecesBelongToTheSamePlayer(Position i_FirstPosition, Position i_SecondPosition)
        {
            GamePiece firstGamePiece = GetTheGamePieceOnRequestedPosition(i_FirstPosition);
            GamePiece secondGamePiece = GetTheGamePieceOnRequestedPosition(i_SecondPosition);

            return firstGamePiece.PlayerProperty == secondGamePiece.PlayerProperty;
        }

        public void DeleteTheGamePieceOnRequestedPosition(Position i_RequestedPosition)
        {
            r_CellsMatrix[i_RequestedPosition.Row, i_RequestedPosition.Column].GamePiece = null;
        }
        public void PrepareTheBoardForANewGame(List<GamePiece> i_FirstPlayerGamePieces, List<GamePiece> i_SecondPlayerGamePieces)
        {
            clearTheBoard();
            initializeTheGameBoardWithGamePiecesOfAPlayer(i_FirstPlayerGamePieces);
            initializeTheGameBoardWithGamePiecesOfAPlayer(i_SecondPlayerGamePieces);
        }

        private void clearTheBoard()
        {
            foreach(BoardCell cell in r_CellsMatrix)
            {
                cell.GamePiece = null;
            }
        }
    }
}