
using System.Globalization;

namespace CheckersOnConsole
{
    class BoardGame
    {
        //-------------------------------------------------------------------------------Members-------------------------------------------------------------------------------//
        BoardCell[,] m_CellsMatrix;
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

        public BoardCell[,] GameBoard
        {
            get
            {
                return m_CellsMatrix;
            }
        }

        //-----------------------------------------------------------------------------Constructors----------------------------------------------------------------------------//
        public BoardGame(int i_NumberOfRows, int i_NumberOfColumns, int i_NumberOfGamePiecesForEachPlayer, GamePiece[] i_FirstPlayerGamePieces, GamePiece[] i_SecondPlayerGamePieces)
        {
            r_NumberOfRows = i_NumberOfRows;
            r_NumberOfColumns = i_NumberOfColumns;
            m_CellsMatrix = new BoardCell[r_NumberOfRows, r_NumberOfColumns];

            for(int i = 0; i < r_NumberOfRows; ++i)
            {
                for(int j = 0; j < r_NumberOfColumns; ++j)
                {
                    m_CellsMatrix[i, j] = new BoardCell();
                }
            }

            initializeTheBoardGameWithGamePiecesOfAPlayer(i_FirstPlayerGamePieces, i_NumberOfGamePiecesForEachPlayer);
            initializeTheBoardGameWithGamePiecesOfAPlayer(i_SecondPlayerGamePieces, i_NumberOfGamePiecesForEachPlayer);
        }

        private void initializeTheBoardGameWithGamePiecesOfAPlayer(GamePiece[] i_PlayerGamePieces, int i_NumberOfGamePiecesForEachPlayer)
        {
            Position gamePiecePosition;

            for (int i = 0; i < i_NumberOfGamePiecesForEachPlayer; ++i)
            {
                gamePiecePosition = i_PlayerGamePieces[i].Position;

                m_CellsMatrix[gamePiecePosition.Row, gamePiecePosition.Column].GamePiece = i_PlayerGamePieces[i];
            }
        }

        //-------------------------------------------------------------------------------Getters-------------------------------------------------------------------------------//
        public GamePiece GetTheGamePieceOnRequestedPosition(Position i_RequestedPosition)
        {
            return m_CellsMatrix[i_RequestedPosition.Row, i_RequestedPosition.Column].GamePiece;
        }

        //-------------------------------------------------------------------------------Methods-------------------------------------------------------------------------------//
        public void MoveAGamePieceToANewPosition(Position i_CurrentPosition, Position i_NewPosition)
        {
            BoardCell temp = m_CellsMatrix[i_CurrentPosition.Row, i_CurrentPosition.Column];
            m_CellsMatrix[i_CurrentPosition.Row, i_CurrentPosition.Column] = m_CellsMatrix[i_NewPosition.Row, i_NewPosition.Column];
            m_CellsMatrix[i_NewPosition.Row, i_NewPosition.Column] = temp;
        }

        public bool IsThePositionInTheBoard(Position i_PositionToCheck)
        {
            bool inRowsLines = i_PositionToCheck.Row >= 0 && i_PositionToCheck.Row <= r_NumberOfRows - 1;
            bool inColumnsLines = i_PositionToCheck.Column >= 0 && i_PositionToCheck.Column <= r_NumberOfColumns - 1;

            return inRowsLines && inColumnsLines;
        }

        public bool CheckIfTheCellHasAGamePieceOnIt(Position i_PositionToCheck)
        {
            return m_CellsMatrix[i_PositionToCheck.Row, i_PositionToCheck.Column].IsTheCellTaken();
        }

        public bool CheckIfTheGamePiecesBelongToTheSamePlayer(Position i_FirstPosition, Position i_SecondPosition)
        {
            GamePiece firstGamePiece = GetTheGamePieceOnRequestedPosition(i_FirstPosition);
            GamePiece secondGamePiece = GetTheGamePieceOnRequestedPosition(i_SecondPosition);
            bool belongsToTheSamePlayer = false;

            if(firstGamePiece.Symbol == Constants.sr_FirstPlayerPawnSymbol || firstGamePiece.Symbol == Constants.sr_FirstPlayerKingSymbol)
            {
                if(secondGamePiece.Symbol == Constants.sr_FirstPlayerPawnSymbol || secondGamePiece.Symbol == Constants.sr_FirstPlayerKingSymbol)
                {
                    belongsToTheSamePlayer = true;
                }
            }
            else
            {
                if (secondGamePiece.Symbol == Constants.sr_SecondPlayerPawnSymbol || secondGamePiece.Symbol == Constants.sr_SecondPlayerKingSymbol)
                {
                    belongsToTheSamePlayer = true;
                }
            }

            return belongsToTheSamePlayer;
        }

        public void DeleteTheGamePieceOnRequestedPosition(Position i_RequestedPosition)
        {
            m_CellsMatrix[i_RequestedPosition.Row, i_RequestedPosition.Column] = new BoardCell();
        }
    }
}