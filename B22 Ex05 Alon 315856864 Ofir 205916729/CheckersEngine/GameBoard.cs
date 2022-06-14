using System.Collections.Generic;

namespace CheckersEngine
{
    public class GameBoard
    {
        //------------------------------------------------------------------------------Properties-----------------------------------------------------------------------------//
        public int NumberOfRows { get; }

        public int NumberOfColumns { get; }

        public BoardCell[,] Board { get; }

        //-----------------------------------------------------------------------------Constructors----------------------------------------------------------------------------//
        public GameBoard(int i_NumberOfRows, int i_NumberOfColumns, List<GamePiece> i_FirstPlayerGamePieces, List<GamePiece> i_SecondPlayerGamePieces)
        {
            NumberOfRows = i_NumberOfRows;
            NumberOfColumns = i_NumberOfColumns;
            Board = new BoardCell[NumberOfRows, NumberOfColumns];
            for (int i = 0; i < NumberOfRows; ++i)
            {
                for (int j = 0; j < NumberOfColumns; ++j)
                {
                    Board[i, j] = new BoardCell(new Position(i, j));
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
                Board[gamePiecePosition.Row, gamePiecePosition.Column].GamePiece = playerGamePiece;
            }
        }

        //-------------------------------------------------------------------------------Getters-------------------------------------------------------------------------------//
        public GamePiece GetTheGamePieceOnRequestedPosition(Position i_RequestedPosition)
        {
            return Board[i_RequestedPosition.Row, i_RequestedPosition.Column].GamePiece;
        }

        //-------------------------------------------------------------------------------Methods-------------------------------------------------------------------------------//
        public void MoveAGamePieceToANewPosition(Position i_CurrentPosition, Position i_NewPosition)
        {
            Board[i_NewPosition.Row, i_NewPosition.Column].GamePiece = Board[i_CurrentPosition.Row, i_CurrentPosition.Column].GamePiece;
            Board[i_NewPosition.Row, i_NewPosition.Column].GamePiece.Position = i_NewPosition;
            Board[i_CurrentPosition.Row, i_CurrentPosition.Column].GamePiece = null;
        }

        public bool CheckIfThePositionIsInTheBoardBoundaries(Position i_PositionToCheck)
        {
            bool inRowsLines = i_PositionToCheck.Row >= 0 && i_PositionToCheck.Row <= NumberOfRows - 1;
            bool inColumnsLines = i_PositionToCheck.Column >= 0 && i_PositionToCheck.Column <= NumberOfColumns - 1;

            return inRowsLines && inColumnsLines;
        }

        public bool CheckIfTheCellHasAGamePieceOnIt(Position i_PositionToCheck)
        {
            return Board[i_PositionToCheck.Row, i_PositionToCheck.Column].IsTheCellTaken();
        }

        public bool CheckIfTheGamePiecesBelongToTheSamePlayer(Position i_FirstPosition, Position i_SecondPosition)
        {
            GamePiece firstGamePiece = GetTheGamePieceOnRequestedPosition(i_FirstPosition);
            GamePiece secondGamePiece = GetTheGamePieceOnRequestedPosition(i_SecondPosition);

            return firstGamePiece.PlayerProperty == secondGamePiece.PlayerProperty;
        }

        public void DeleteTheGamePieceOnRequestedPosition(Position i_RequestedPosition)
        {
            Board[i_RequestedPosition.Row, i_RequestedPosition.Column].GamePiece = null;
        }
        public void PrepareTheBoardForANewGame(List<GamePiece> i_FirstPlayerGamePieces, List<GamePiece> i_SecondPlayerGamePieces)
        {
            clearTheBoard();
            initializeTheGameBoardWithGamePiecesOfAPlayer(i_FirstPlayerGamePieces);
            initializeTheGameBoardWithGamePiecesOfAPlayer(i_SecondPlayerGamePieces);
        }

        private void clearTheBoard()
        {
            foreach(BoardCell cell in Board)
            {
                cell.GamePiece = null;
            }
        }
    }
}