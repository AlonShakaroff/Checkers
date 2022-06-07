
using System;

namespace CheckersOnConsole
{
    class CheckersGame
    {
        //-------------------------------------------------------------------------------Members-------------------------------------------------------------------------------//
        private readonly Player r_Player1;
        private readonly Player r_Player2;
        private Player m_PlayersTurn;
        private readonly BoardGame r_BoardGame;
        private string m_WinnerOfTheGame;
        private Constants.eGameStatus m_GameStatus;

        //-----------------------------------------------------------------------------Constructors----------------------------------------------------------------------------//
        public CheckersGame(string i_FirstPlayerName, string i_SecondPlayerName, int i_NumberOfRowsOnTheBoard, int i_NumberOfColumnsOnTheBoard, int i_NumberOfGamePiecesPerPlayer)
        {
            r_Player1 = new Player(i_FirstPlayerName, i_NumberOfGamePiecesPerPlayer, true, i_NumberOfRowsOnTheBoard);
            r_Player2 = new Player(i_SecondPlayerName, i_NumberOfGamePiecesPerPlayer, false, i_NumberOfRowsOnTheBoard);
            r_BoardGame = new BoardGame(i_NumberOfRowsOnTheBoard, i_NumberOfColumnsOnTheBoard, i_NumberOfGamePiecesPerPlayer, r_Player1.GamePieces, r_Player2.GamePieces);
            m_WinnerOfTheGame = null;
            m_PlayersTurn = r_Player1;
            m_GameStatus = Constants.eGameStatus.OnGoing;
        }
        //-------------------------------------------------------------------------------Getters-------------------------------------------------------------------------------//
        public string CurrentPlayersTurn()
        {
            return m_PlayersTurn.Name;
        }

        public int GetTheNumberOfRowsInTheGameBoard()
        {
            return r_BoardGame.NumberOfRows;
        }

        public int GetTheNumberOfColumnsInTheGameBoard()
        {
            return r_BoardGame.NumberOfColumns;
        }

        //-------------------------------------------------------------------------------Setters-------------------------------------------------------------------------------//
        private void setTheWinnerOfTheGame()
        {
            m_WinnerOfTheGame = m_PlayersTurn == r_Player1 ? r_Player1.Name : r_Player2.Name;
        }

        public char GetTheSymbolOfTheGamePieceOnRequestedPosition(Position i_Position)
        {
            return r_BoardGame.GetTheGamePieceOnRequestedPosition(i_Position).Symbol;
        }

        //-------------------------------------------------------------------------------Checks--------------------------------------------------------------------------------//
        public bool CheckIfTheGameIsOver()
        {
            return m_GameStatus != Constants.eGameStatus.OnGoing;
        }

        public bool CheckIfTheNextMoveValid(Position i_CurrentPosition, Position i_NewPosition, out string i_OutputMessage)
        {
            bool validMove = false;
            GamePiece theGamePieceThatThePlayerWishToMove = r_BoardGame.GetTheGamePieceOnRequestedPosition(i_CurrentPosition);

            if(r_BoardGame.IsThePositionInTheBoard(i_CurrentPosition) == false)
            {
                i_OutputMessage = "The starting position you mentioned is not on the board!";
            }
            else if(r_BoardGame.IsThePositionInTheBoard(i_NewPosition) == false)
            {
                i_OutputMessage = "The position you requested to move to is not on the board!";
            }
            else if(r_BoardGame.CheckIfTheCellHasAGamePieceOnIt(i_CurrentPosition) == false)
            {
                i_OutputMessage = "You have to choose a starting position with a game piece on it!";
            }
            else if (checkIfThePlayerChoseHisOwnGamePieceToMove(i_CurrentPosition) == false)
            {
                i_OutputMessage = "Please choose your own game piece!";
            }
            else if (theGamePieceThatThePlayerWishToMove.IsTheGamePieceHasAnyPossibleMoves() == false)
            {
                i_OutputMessage = "The game piece you chose has no possible moves!";
            }
            else if(theGamePieceThatThePlayerWishToMove.IsThePositionAPossibleMove(i_NewPosition) == false)
            {
                i_OutputMessage = "This is not a possible move for the chosen game piece!\n";

                checkWhyTheNewPositionOfAGamePieceIsNotPossible(i_CurrentPosition, i_NewPosition, out string notPossibleMoveMessage);
                i_OutputMessage += notPossibleMoveMessage;
            }
            else
            {
                i_OutputMessage = null;
                validMove = true;
            }

            return validMove;
        }

        private void checkWhyTheNewPositionOfAGamePieceIsNotPossible(Position i_CurrentPosition, Position i_NewPosition, out string o_NotPossibleMoveMessage)
        {
            if (r_BoardGame.CheckIfTheCellHasAGamePieceOnIt(i_NewPosition) == true)
            {
                o_NotPossibleMoveMessage = "You have to choose a new position that has no game pieces on it.";
            }
            else if (checkIfTheMoveOfTheGamePieceIsDiagonal(i_CurrentPosition, i_NewPosition) == false)
            {
                o_NotPossibleMoveMessage = "You can only move a game piece in a diagonal path.";
            }
            else if (checkIfThePlayerIsMovingHisGamePieceInTheRightDirection(i_CurrentPosition, i_NewPosition) == false)
            {
                o_NotPossibleMoveMessage = "Please move your game pieces in the right direction.";
            }
            else if (checkIfThePlayerIsTryingToMoveAGamePieceOverTwoRows(i_CurrentPosition, i_NewPosition) == true && checkIfThePlayerIsTryingToValidlyEatARivalGamePiece(i_CurrentPosition, i_NewPosition, out string eatingOutputMessage) == false)
            {
                o_NotPossibleMoveMessage = eatingOutputMessage;
            }
            else
            {
                o_NotPossibleMoveMessage = null;
            }
        }

        private bool checkIfThePlayerIsMovingHisGamePieceInTheRightDirection(Position i_CurrentPosition, Position i_NewPosition)
        {
            GamePiece gamePiece = r_BoardGame.GetTheGamePieceOnRequestedPosition(i_CurrentPosition);
            bool validDirection = false;

            if(gamePiece.IsKing)
            {
                validDirection = true;
            }
            else if(gamePiece.PlayerProperty == Constants.ePlayerProperty.Player1)
            {
                validDirection = i_CurrentPosition.Row < i_NewPosition.Row;
            }
            else
            {
                validDirection = i_CurrentPosition.Row > i_NewPosition.Row;
            }

            return validDirection;
        }

        private bool checkIfThePlayerChoseHisOwnGamePieceToMove(Position i_CurrentPosition)
        {
            Constants.ePlayerProperty thePlayerThatGamePieceBelongsTo = r_BoardGame.GetTheGamePieceOnRequestedPosition(i_CurrentPosition).PlayerProperty;
            bool validChoice;

            if (m_PlayersTurn == r_Player1)
            {
                validChoice = thePlayerThatGamePieceBelongsTo == Constants.ePlayerProperty.Player1;
            }
            else
            {
                validChoice = thePlayerThatGamePieceBelongsTo == Constants.ePlayerProperty.Player2;
            }

            return validChoice;
        }

        private bool checkIfThePlayerIsTryingToValidlyEatARivalGamePiece(Position i_CurrentPosition, Position i_NewPosition, out string o_OutputMessage)
        {
            int potentialRivalGamePieceRow = i_NewPosition.Row - i_CurrentPosition.Row < 0 ? i_NewPosition.Row + 1 : i_NewPosition.Row - 1;
            int potentialRivalGamePieceColumn = i_NewPosition.Column - i_CurrentPosition.Column < 0 ? i_NewPosition.Column + 1 : i_NewPosition.Column - 1;
            Position potentialRivalGamePiecePosition = new Position(potentialRivalGamePieceRow, potentialRivalGamePieceColumn);
            bool validEat = false;

            if(r_BoardGame.CheckIfTheCellHasAGamePieceOnIt(potentialRivalGamePiecePosition) == false)
            {
                o_OutputMessage = "You can only move 1 step ahead at a time!";
            }
            else if (r_BoardGame.CheckIfTheGamePiecesBelongToTheSamePlayer(i_CurrentPosition, potentialRivalGamePiecePosition) == true)
            {
                o_OutputMessage = "You cannot jump over another game piece that belongs to you!";
            }
            else
            {
                o_OutputMessage = null;
                validEat = true;
            }

            return validEat;
        }

        private bool checkIfTheMoveOfTheGamePieceIsDiagonal(Position i_CurrentPosition, Position i_NewPosition)
        {
            int differenceInRows = Math.Abs(i_CurrentPosition.Row - i_NewPosition.Row);
            int differenceInColumns = Math.Abs(i_CurrentPosition.Column - i_NewPosition.Column);

            return differenceInRows == differenceInColumns;
        }

        private bool checkIfThePlayerIsTryingToMoveAGamePieceOverTwoRows(Position i_CurrentPosition, Position i_NewPosition)
        {
            return Math.Abs(i_CurrentPosition.Row - i_NewPosition.Row) != 1;
        }

        private void checkIfARivalGamePieceGotEatenOnCurrentTurn(Position i_CurrentPosition, Position i_NewPosition)
        {
            if (Math.Abs(i_CurrentPosition.Row - i_NewPosition.Row) == 2)
            {
                eatARivalGamePiece(i_CurrentPosition, i_NewPosition);
            }
        }

        private void checkIfTheGamePieceNeedsToBecomeAKing(GamePiece gamePiecePlayed, Position i_NewPosition)
        {
            if (gamePiecePlayed.IsKing == false)
            {
                if (i_NewPosition.Row == 0 || i_NewPosition.Row == (r_BoardGame.NumberOfRows - 1))
                {
                    gamePiecePlayed.MakeThePawnAKing();
                }
            }
        }

        private void checkIfTheGameIsOver()
        {
            if (r_Player1.IsThePlayerHasAnyPossibleMoves() == false && r_Player2.IsThePlayerHasAnyPossibleMoves() == false)
            {
                m_GameStatus = Constants.eGameStatus.Draw;
            }
            else if (m_PlayersTurn.NumberOfGamePiecesLeft == 0 || m_PlayersTurn.IsThePlayerHasAnyPossibleMoves() == false)
            {
                m_GameStatus = Constants.eGameStatus.HasAWinner;
                setTheWinnerOfTheGame();
            }
        }

        public bool CheckIfThePositionHasAGamePieceOnIt(Position i_Position)
        {
            return r_BoardGame.CheckIfTheCellHasAGamePieceOnIt(i_Position);
        }

        //-------------------------------------------------------------------------------Methods-------------------------------------------------------------------------------//
        public void MakeAMove(Position i_CurrentPosition, Position i_NewPosition)
        {
            GamePiece gamePiecePlayed = r_BoardGame.GetTheGamePieceOnRequestedPosition(i_CurrentPosition);

            checkIfARivalGamePieceGotEatenOnCurrentTurn(i_CurrentPosition, i_NewPosition);

            r_BoardGame.MoveAGamePieceToANewPosition(i_CurrentPosition, i_NewPosition);

            checkIfTheGamePieceNeedsToBecomeAKing(gamePiecePlayed, i_NewPosition);

            checkIfTheGameIsOver();
        }

        private void eatARivalGamePiece(Position i_CurrentPosition, Position i_NewPosition)
        {
            int rowPosition = i_NewPosition.Row - i_CurrentPosition.Row < 0 ? i_NewPosition.Row + 1 : i_NewPosition.Row - 1;
            int columnPosition = i_NewPosition.Column - i_CurrentPosition.Column < 0 ? i_NewPosition.Column + 1 : i_NewPosition.Column - 1;
            Position eatenStonePosition = new Position(rowPosition, columnPosition);
            int gamePieceIndexInPlayerGamePiecesArray = r_BoardGame.GetTheGamePieceOnRequestedPosition(eatenStonePosition).GamePieceIndex;

            m_PlayersTurn.DeleteAGamePieceByIndex(gamePieceIndexInPlayerGamePiecesArray);
            r_BoardGame.DeleteTheGamePieceOnRequestedPosition(eatenStonePosition);
        }
    }
}
