using System;
using System.Collections.Generic;

namespace CheckersLogicEngine
{
    public class CheckersGame
    {
        public enum eGameStatus
        {
            OnGoing,
            HasAWinner,
            Draw,
        }

        //-------------------------------------------------------------------------------Members-------------------------------------------------------------------------------//
        private static readonly List<Position.eDirection> sr_UpwardsDirectionsList = new List<Position.eDirection>()
            {
                Position.eDirection.UpLeft,
                Position.eDirection.UpRight
            };

        private static readonly List<Position.eDirection> sr_DownwardsDirectionsList = new List<Position.eDirection>()
            {
                Position.eDirection.DownLeft,
                Position.eDirection.DownRight
            };

        private static readonly List<Position.eDirection> sr_FullDirectionsList = new List<Position.eDirection>()
            {
                Position.eDirection.DownLeft,
                Position.eDirection.DownRight,
                Position.eDirection.UpLeft,
                Position.eDirection.UpRight
            };

        private readonly Player r_Player1;
        private readonly Player r_Player2;
        private Player m_PlayerThatItIsItsTurn;
        private Player m_PlayerThatItIsNotItsTurn;
        private readonly GameBoard r_GameBoard;
        private readonly bool r_IsPVP;
        private string m_WinnerOfTheGame;
        private eGameStatus m_GameStatus;
        private bool m_EatingIsPossibleThisTurn;
        private bool m_APieceWasEaten;

        //-----------------------------------------------------------------------------Constructors----------------------------------------------------------------------------//
        public CheckersGame(
            string i_FirstPlayerName,
            string i_SecondPlayerName,
            int i_NumberOfRowsOnTheBoard,
            int i_NumberOfColumnsOnTheBoard,
            int i_NumberOfGamePiecesPerPlayer,
            bool i_IsPVP
            )
        {
            r_Player1 = new Player(i_FirstPlayerName, i_NumberOfGamePiecesPerPlayer, true, i_NumberOfRowsOnTheBoard);
            r_Player2 = new Player(i_SecondPlayerName, i_NumberOfGamePiecesPerPlayer, false, i_NumberOfRowsOnTheBoard);
            r_GameBoard = new GameBoard(i_NumberOfRowsOnTheBoard, i_NumberOfColumnsOnTheBoard, r_Player1.GamePieces, r_Player2.GamePieces);
            m_WinnerOfTheGame = null;
            r_IsPVP = i_IsPVP;
            m_APieceWasEaten = false;
            m_EatingIsPossibleThisTurn = false;
            m_GameStatus = eGameStatus.OnGoing;
            m_PlayerThatItIsNotItsTurn = r_Player2;
            m_PlayerThatItIsItsTurn = r_Player1;
        }

        //-------------------------------------------------------------------------------Properties----------------------------------------------------------------------------//
        public eGameStatus GameStatus 
        {
            get 
            {
                return m_GameStatus; 
            }
        }

        public string Winner
        {
            get
            {
                string winnerOfTheGame;

                if (m_WinnerOfTheGame == null)
                {
                    winnerOfTheGame = "No one";
                }
                else
                {
                    winnerOfTheGame = m_WinnerOfTheGame;
                }

                return winnerOfTheGame;
            }
        }

        public Player Player1
        {
            get
            {
                return r_Player1;
            }
        }

        public Player Player2
        {
            get
            {
                return r_Player2;
            }
        }

        //-------------------------------------------------------------------------------Getters-------------------------------------------------------------------------------//
        public string GetTheNameOfThePlayerWhoCurrentlyPlaying()
        {
            return m_PlayerThatItIsItsTurn.Name;
        }

        public string GetTheNameOfThePlayerWhoCurrentlyNotPlaying()
        {
            return m_PlayerThatItIsNotItsTurn.Name;
        }

        public char GetTheSymbolOfTheGamePiecesThatBelongsToThePlayingPlayer()
        {
            return m_PlayerThatItIsItsTurn == r_Player1 ? GamePiece.k_FirstPlayerPawnSymbol : GamePiece.k_SecondPlayerPawnSymbol;
        }

        public int GetTheNumberOfRowsInTheGameBoard()
        {
            return r_GameBoard.NumberOfRows;
        }

        public int GetTheNumberOfColumnsInTheGameBoard()
        {
            return r_GameBoard.NumberOfColumns;
        }

        public GamePiece GetTheGamePieceOnRequestedPosition(Position i_Position)
        {
            return r_GameBoard.GetTheGamePieceOnRequestedPosition(i_Position);
        }

        //-------------------------------------------------------------------------------Setters-------------------------------------------------------------------------------//
        private void setTheWinnerOfTheGameAndAddWinningPoints()
        {
            int calculatedGamePiecesPointsOfPlayer1 = r_Player1.CalculateGamePiecesPoints();
            int calculatedGamePiecesPointsOfPlayer2 = r_Player2.CalculateGamePiecesPoints();
            int winningPoints = Math.Abs(calculatedGamePiecesPointsOfPlayer1 - calculatedGamePiecesPointsOfPlayer2);

            m_PlayerThatItIsItsTurn.WinningPoints += winningPoints;
            m_WinnerOfTheGame = m_PlayerThatItIsItsTurn.Name;
        }

        public char GetTheSymbolOfTheGamePieceOnRequestedPosition(Position i_Position)
        {
            return r_GameBoard.GetTheGamePieceOnRequestedPosition(i_Position).Symbol;
        }

        //-------------------------------------------------------------------------------Checks--------------------------------------------------------------------------------//
        public bool CheckIfTheGameIsStillGoing()
        {
            return m_GameStatus != eGameStatus.OnGoing;
        }

        public bool CheckIfThePlayerWhoCurrentlyPlayingIsPlayer1()
        {
            return m_PlayerThatItIsItsTurn == r_Player1;
        }

        public bool CheckIfThePlayerWhoCurrentlyPlayingIsAComputer()
        {
            return r_IsPVP == false && m_PlayerThatItIsItsTurn == r_Player2;
        }

        public bool CheckIfThePositionIsInTheGameBoardBoundaries(Position i_Position)
        {
            return r_GameBoard.CheckIfThePositionIsInTheBoardBoundaries(i_Position);
        }

        private void checkIfTheGameIsOver()
        {
            if (r_Player1.CheckIfThePlayerHasAnyPossibleMoves() == false && r_Player2.CheckIfThePlayerHasAnyPossibleMoves() == false)
            {
                m_GameStatus = eGameStatus.Draw;
            }
            else if (m_PlayerThatItIsNotItsTurn.NumberOfGamePiecesLeft == 0 || m_PlayerThatItIsNotItsTurn.CheckIfThePlayerHasAnyPossibleMoves() == false)
            {
                FinishTheGame();
            }
        }

        private void eatARivalGamePieceIfNecessary(Position i_CurrentPosition, Position i_NewPosition)
        {
            if (Math.Abs(i_CurrentPosition.Row - i_NewPosition.Row) == 2)
            {
                eatARivalGamePiece(i_CurrentPosition, i_NewPosition);
                m_APieceWasEaten = true;
            }
        }

        private void checkIfTheGamePieceNeedsToBecomeAKingAndMakeItAKingIfNecessary(GamePiece i_GamePiecePlayed, Position i_NewPosition)
        {
            if (i_GamePiecePlayed.IsKing == false)
            {
                if (i_NewPosition.Row == 0 || i_NewPosition.Row == (r_GameBoard.NumberOfRows - 1))
                {
                    i_GamePiecePlayed.MakeThePawnAKing();
                }
            }
        }

        public bool CheckIfThePositionHasAGamePieceOnIt(Position i_Position)
        {
            return r_GameBoard.CheckIfTheCellHasAGamePieceOnIt(i_Position);
        }

        public bool CheckIfTheGamePiecesBelongToTheSamePlayer(Position i_FirstPosition, Position i_SecondPosition)
        {
            return r_GameBoard.CheckIfTheGamePiecesBelongToTheSamePlayer(i_FirstPosition, i_SecondPosition);
        }

        //-------------------------------------------------------------------------------Methods-------------------------------------------------------------------------------//
        public void MakeAMove(Position i_CurrentPosition, Position i_NewPosition)
        {
            GamePiece gamePiecePlayed = r_GameBoard.GetTheGamePieceOnRequestedPosition(i_CurrentPosition);

            m_APieceWasEaten = false;
            eatARivalGamePieceIfNecessary(i_CurrentPosition, i_NewPosition);
            r_GameBoard.MoveAGamePieceToANewPosition(i_CurrentPosition, i_NewPosition);
            checkIfTheGamePieceNeedsToBecomeAKingAndMakeItAKingIfNecessary(gamePiecePlayed, i_NewPosition);
            generateNewPossibleMovesForBothPlayers();
            checkIfTheGameIsOver();
            if (m_APieceWasEaten)
            {
                if(checkIfChainEatingIsPossibleAndPrepareNextTurnAccordingly(i_NewPosition) == false)
                {
                    SwitchPlayersTurns();
                }
            }
            else
            {
                SwitchPlayersTurns();
            }
        }

        private bool checkIfChainEatingIsPossibleAndPrepareNextTurnAccordingly(Position i_NewPosition)
        {
            List<Position> potentialNewPossibleMoves = new List<Position>(3);
            bool isChainEatingPossible = false;

            foreach(Position currentPossibleMove in r_GameBoard.GetTheGamePieceOnRequestedPosition(i_NewPosition).PossibleMoves)
            {
                if(Math.Abs(currentPossibleMove.Row - i_NewPosition.Row) == 2)
                {
                    potentialNewPossibleMoves.Add(currentPossibleMove);
                }
            }

            if(potentialNewPossibleMoves.Count > 0)
            {
                m_PlayerThatItIsItsTurn.ClearPlayersPossibleMoves();
                isChainEatingPossible = true;
                foreach (Position currentNewPossibleMove in potentialNewPossibleMoves)
                {
                    r_GameBoard.GetTheGamePieceOnRequestedPosition(i_NewPosition).PossibleMoves.Add(currentNewPossibleMove);
                }
            }

            return isChainEatingPossible;
        }

        public void SwitchPlayersTurns()
        {
            Player temp = m_PlayerThatItIsItsTurn;
            m_PlayerThatItIsItsTurn = m_PlayerThatItIsNotItsTurn;
            m_PlayerThatItIsNotItsTurn = temp;
        }

        // $G$ CSS-999 (-5) Public methods should start with an uppercase letter
        public void generateNewPossibleMovesForBothPlayers()
        {
            generateNewPossibleMovesForAPlayer(r_Player1);
            generateNewPossibleMovesForAPlayer(r_Player2);
        }

        private void generateNewPossibleMovesForAPlayer(Player i_Player)
        {
            List<Position.eDirection> currentDirectionsList;

            m_EatingIsPossibleThisTurn = false;
            i_Player.ClearPlayersPossibleMoves();
            foreach (GamePiece currentGamePiece in i_Player.GamePieces)
            {
                if (currentGamePiece.IsKing == true)
                {
                    currentDirectionsList = sr_FullDirectionsList;
                }
                else if (i_Player.CheckIfThePlayerIsPlayingFirst() == true)
                {
                    currentDirectionsList = sr_UpwardsDirectionsList;
                }
                else
                {
                    currentDirectionsList = sr_DownwardsDirectionsList;
                }

                addPossibleMovesInRequestedDirections(currentGamePiece, currentDirectionsList, i_Player);
            }
        }

        public char GetTheSymbolOfThePlayerWhoCurrentlyPlaying()
        {
            char playerSymbol;

            if(m_PlayerThatItIsItsTurn == r_Player1)
            {
                playerSymbol = GamePiece.k_FirstPlayerPawnSymbol;
            }
            else
            {
                playerSymbol = GamePiece.k_SecondPlayerPawnSymbol;
            }

            return playerSymbol;
        }

        private void addPossibleMovesInRequestedDirections(GamePiece i_GamePiece, List<Position.eDirection> i_RequestedDirectionsList, Player i_Player)
        {
            Position currentPossiblePossitionInRelativeDirection;
            Position currentPossibleEatingPositionInRelativeDirection;
            
            foreach(Position.eDirection currentCheckedDirection in i_RequestedDirectionsList)
            {
                currentPossiblePossitionInRelativeDirection =
                    i_GamePiece.Position.GetThePositionLocatedInTheDirectionRelativeToThisPosition(currentCheckedDirection);
                if (r_GameBoard.CheckIfThePositionIsInTheBoardBoundaries(currentPossiblePossitionInRelativeDirection) == true)
                {
                    if (r_GameBoard.CheckIfTheCellHasAGamePieceOnIt(currentPossiblePossitionInRelativeDirection) == true)
                    {
                        currentPossibleEatingPositionInRelativeDirection =
                            currentPossiblePossitionInRelativeDirection.GetThePositionLocatedInTheDirectionRelativeToThisPosition(currentCheckedDirection);
                        if (CheckIfThePieceOnThePositionIsEdible(i_GamePiece, currentPossiblePossitionInRelativeDirection,currentPossibleEatingPositionInRelativeDirection) == true)
                        {
                            if(m_EatingIsPossibleThisTurn == false)
                            {
                                m_EatingIsPossibleThisTurn = true;
                                i_Player.ClearPlayersPossibleMoves();
                            }

                            i_GamePiece.AddPossibleMove(currentPossibleEatingPositionInRelativeDirection);
                        }
                    }
                    else if(m_EatingIsPossibleThisTurn == false)
                    {
                        i_GamePiece.AddPossibleMove(currentPossiblePossitionInRelativeDirection);
                    }
                }
            }
        }

        private bool CheckIfThePieceOnThePositionIsEdible(GamePiece i_PlayingGamePiece, Position i_EatingPosition, Position i_AfterEatingPosition)
        {
            bool thePositionAfterEatingIsInTheBoardBoundaries = r_GameBoard.CheckIfThePositionIsInTheBoardBoundaries(i_AfterEatingPosition);
            bool theOtherGamePieceBelongsToTheSamePlayer, thePositionAfterTheEatingHasAGamePieceOnIt;
            bool ediable = false;

            if (thePositionAfterEatingIsInTheBoardBoundaries == true)
            {
                theOtherGamePieceBelongsToTheSamePlayer = r_GameBoard.GetTheGamePieceOnRequestedPosition(i_EatingPosition).PlayerProperty.Equals(i_PlayingGamePiece.PlayerProperty);
                thePositionAfterTheEatingHasAGamePieceOnIt = r_GameBoard.CheckIfTheCellHasAGamePieceOnIt(i_AfterEatingPosition);
                ediable = theOtherGamePieceBelongsToTheSamePlayer == false && thePositionAfterTheEatingHasAGamePieceOnIt == false;
            }

            return ediable;
        }

        private void eatARivalGamePiece(Position i_CurrentPosition, Position i_NewPosition)
        {
            int rowPosition = i_NewPosition.Row - i_CurrentPosition.Row < 0 ? i_NewPosition.Row + 1 : i_NewPosition.Row - 1;
            int columnPosition = i_NewPosition.Column - i_CurrentPosition.Column < 0 ? i_NewPosition.Column + 1 : i_NewPosition.Column - 1;
            Position eatenGamePiecePosition = new Position(rowPosition, columnPosition);
            GamePiece eatenGamePiece = r_GameBoard.GetTheGamePieceOnRequestedPosition(eatenGamePiecePosition);

            m_PlayerThatItIsNotItsTurn.DeleteAGamePieceFromGamePiecesList(eatenGamePiece);
            r_GameBoard.DeleteTheGamePieceOnRequestedPosition(eatenGamePiecePosition);
        }

        public void GetAMoveFromTheComputer(out Position o_CurrentPosition, out Position o_NewPosition)
        {
            List<GamePiece> gamePiecesWithPossibleMoves = new List<GamePiece>();
            Random generateRandomNumber = new Random();
            GamePiece selectedGamePieceToMakeAMoveWith;
            int gamePieceRandomIndex, randomMoveIndex;

            foreach (GamePiece currentGamePiece in m_PlayerThatItIsItsTurn.GamePieces)
            {
                if(currentGamePiece.CheckIfTheGamePieceHasAnyPossibleMoves() == true)
                {
                    gamePiecesWithPossibleMoves.Add(currentGamePiece);
                }
            }

            gamePieceRandomIndex = generateRandomNumber.Next(gamePiecesWithPossibleMoves.Count);
            selectedGamePieceToMakeAMoveWith = gamePiecesWithPossibleMoves[gamePieceRandomIndex];
            randomMoveIndex = generateRandomNumber.Next(selectedGamePieceToMakeAMoveWith.PossibleMoves.Count);
            o_CurrentPosition = selectedGamePieceToMakeAMoveWith.Position;
            o_NewPosition = selectedGamePieceToMakeAMoveWith.PossibleMoves[randomMoveIndex];
        }

        public void PrepareForANewGame()
        {
            m_GameStatus = eGameStatus.OnGoing;
            m_WinnerOfTheGame = null;
            m_PlayerThatItIsNotItsTurn = r_Player2;
            m_PlayerThatItIsItsTurn = r_Player1;
            r_Player1.InitializeGamePiecesPositions(GetTheNumberOfRowsInTheGameBoard());
            r_Player2.InitializeGamePiecesPositions(GetTheNumberOfRowsInTheGameBoard());
            r_GameBoard.PrepareTheBoardForANewGame(r_Player1.GamePieces, r_Player2.GamePieces);
            generateNewPossibleMovesForBothPlayers();
        }

        public void FinishTheGame()
        {
            m_GameStatus = eGameStatus.HasAWinner;
            setTheWinnerOfTheGameAndAddWinningPoints();
        }
    }
}