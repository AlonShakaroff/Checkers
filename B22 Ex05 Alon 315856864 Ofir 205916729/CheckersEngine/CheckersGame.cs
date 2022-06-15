using System;
using System.Collections.Generic;

namespace CheckersEngine
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

        private readonly bool r_IsPVP;
        private Player m_PlayerThatItIsItsTurn;
        private Player m_PlayerThatItIsNotItsTurn;
        private string m_WinnerOfTheGame;
        private bool m_EatingIsPossibleThisTurn;
        private bool m_APieceWasEaten;

        public event Action TurnChanged;

        public event Action<BoardCell, BoardCell> MoveMade;

        public event Action<BoardCell> GamePieceWasEaten;

        public event Action ComputersNeedsToPlay;

        //-----------------------------------------------------------------------------Constructors----------------------------------------------------------------------------//
        public CheckersGame(
            string i_FirstPlayerName,
            string i_SecondPlayerName,
            int i_NumberOfRowsOnTheBoard,
            int i_NumberOfColumnsOnTheBoard,
            int i_NumberOfGamePiecesPerPlayer,
            bool i_IsPVP)
        {
            Player1 = new Player(i_FirstPlayerName, i_NumberOfGamePiecesPerPlayer, true, i_NumberOfRowsOnTheBoard);
            Player2 = new Player(i_SecondPlayerName, i_NumberOfGamePiecesPerPlayer, false, i_NumberOfRowsOnTheBoard);
            GameBoard = new GameBoard(i_NumberOfRowsOnTheBoard, i_NumberOfColumnsOnTheBoard, Player1.GamePieces, Player2.GamePieces);
            m_WinnerOfTheGame = null;
            r_IsPVP = i_IsPVP;
            m_APieceWasEaten = false;
            m_EatingIsPossibleThisTurn = false;
            GameStatus = eGameStatus.OnGoing;
            m_PlayerThatItIsNotItsTurn = Player2;
            m_PlayerThatItIsItsTurn = Player1;
            generateNewPossibleMovesForAPlayer(Player1);
        }

        //-------------------------------------------------------------------------------Properties----------------------------------------------------------------------------//
        public eGameStatus GameStatus { get; private set; }

        public string Winner
        {
            get
            {
                string winnerOfTheGame;

                winnerOfTheGame = m_WinnerOfTheGame ?? "No one";

                return winnerOfTheGame;
            }
        }

        public Player Player1 { get; }

        public Player Player2 { get; }

        public GameBoard GameBoard { get; }

        //-------------------------------------------------------------------------------Getters-------------------------------------------------------------------------------//
        public int GetTheNumberOfRowsInTheGameBoard()
        {
            return GameBoard.NumberOfRows;
        }

        //-------------------------------------------------------------------------------Setters-------------------------------------------------------------------------------//
        private void setTheWinnerOfTheGameAndAddWinningPoints()
        {
            int calculatedGamePiecesPointsOfPlayer1 = Player1.CalculateGamePiecesPoints();
            int calculatedGamePiecesPointsOfPlayer2 = Player2.CalculateGamePiecesPoints();
            int winningPoints = Math.Abs(calculatedGamePiecesPointsOfPlayer1 - calculatedGamePiecesPointsOfPlayer2);

            m_PlayerThatItIsItsTurn.WinningPoints += winningPoints;
            m_WinnerOfTheGame = m_PlayerThatItIsItsTurn.Name;
        }

        //-------------------------------------------------------------------------------Checks--------------------------------------------------------------------------------//
        public bool CheckIfTheGameIsStillGoing()
        {
            return GameStatus != eGameStatus.OnGoing;
        }

        public bool CheckIfThePlayerWhoCurrentlyPlayingIsAComputer()
        {
            return r_IsPVP == false && m_PlayerThatItIsItsTurn == Player2;
        }

        private void checkIfTheGameIsOver()
        {
            if (Player1.CheckIfThePlayerHasAnyPossibleMoves() == false && Player2.CheckIfThePlayerHasAnyPossibleMoves() == false)
            {
                GameStatus = eGameStatus.Draw;
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
                if (i_NewPosition.Row == 0 || i_NewPosition.Row == (GameBoard.NumberOfRows - 1))
                {
                    i_GamePiecePlayed.MakeThePawnAKing();
                }
            }
        }

        //-------------------------------------------------------------------------------Methods-------------------------------------------------------------------------------//
        public void MakeAMove(Position i_CurrentPosition, Position i_NewPosition)
        {
            GamePiece gamePiecePlayed = GameBoard.GetTheGamePieceOnRequestedPosition(i_CurrentPosition);

            m_APieceWasEaten = false;
            eatARivalGamePieceIfNecessary(i_CurrentPosition, i_NewPosition);
            GameBoard.MoveAGamePieceToANewPosition(i_CurrentPosition, i_NewPosition);
            checkIfTheGamePieceNeedsToBecomeAKingAndMakeItAKingIfNecessary(gamePiecePlayed, i_NewPosition);
            GenerateNewPossibleMovesForBothPlayers();
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

            if(CheckIfThePlayerWhoCurrentlyPlayingIsAComputer() && GameStatus == eGameStatus.OnGoing)
            {
                ComputersNeedsToPlay?.Invoke();
            }

            m_PlayerThatItIsNotItsTurn.ClearPlayersPossibleMoves();
            MoveMade?.Invoke(GameBoard.Board[i_CurrentPosition.Row, i_CurrentPosition.Column], GameBoard.Board[i_NewPosition.Row, i_NewPosition.Column]);
        }

        private bool checkIfChainEatingIsPossibleAndPrepareNextTurnAccordingly(Position i_NewPosition)
        {
            List<Position> potentialNewPossibleMoves = new List<Position>(3);
            bool isChainEatingPossible = false;

            foreach(Position currentPossibleMove in GameBoard.GetTheGamePieceOnRequestedPosition(i_NewPosition).PossibleMoves)
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
                    GameBoard.GetTheGamePieceOnRequestedPosition(i_NewPosition).PossibleMoves.Add(currentNewPossibleMove);
                }
            }

            return isChainEatingPossible;
        }

        public void SwitchPlayersTurns()
        {
            Player temp = m_PlayerThatItIsItsTurn;

            m_PlayerThatItIsItsTurn = m_PlayerThatItIsNotItsTurn;
            m_PlayerThatItIsNotItsTurn = temp;
            TurnChanged?.Invoke();
        }

        public void GenerateNewPossibleMovesForBothPlayers()
        {
            generateNewPossibleMovesForAPlayer(Player1);
            generateNewPossibleMovesForAPlayer(Player2);
        }

        private void generateNewPossibleMovesForAPlayer(Player i_Player)
        {
            List<Position.eDirection> currentDirectionsList;

            m_EatingIsPossibleThisTurn = false;
            i_Player.ClearPlayersPossibleMoves();
            foreach (GamePiece currentGamePiece in i_Player.GamePieces)
            {
                if (currentGamePiece.IsKing)
                {
                    currentDirectionsList = sr_FullDirectionsList;
                }
                else if (i_Player.CheckIfThePlayerIsPlayingFirst())
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

        private void addPossibleMovesInRequestedDirections(GamePiece i_GamePiece, List<Position.eDirection> i_RequestedDirectionsList, Player i_Player)
        {
            Position currentPossiblePositionInRelativeDirection;
            Position currentPossibleEatingPositionInRelativeDirection;
            
            foreach(Position.eDirection currentCheckedDirection in i_RequestedDirectionsList)
            {
                currentPossiblePositionInRelativeDirection =
                    i_GamePiece.Position.GetThePositionLocatedInTheDirectionRelativeToThisPosition(currentCheckedDirection);
                if (GameBoard.CheckIfThePositionIsInTheBoardBoundaries(currentPossiblePositionInRelativeDirection))
                {
                    if (GameBoard.CheckIfTheCellHasAGamePieceOnIt(currentPossiblePositionInRelativeDirection))
                    {
                        currentPossibleEatingPositionInRelativeDirection =
                            currentPossiblePositionInRelativeDirection.GetThePositionLocatedInTheDirectionRelativeToThisPosition(currentCheckedDirection);
                        if (CheckIfThePieceOnThePositionIsEdible(i_GamePiece, currentPossiblePositionInRelativeDirection, currentPossibleEatingPositionInRelativeDirection))
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
                        i_GamePiece.AddPossibleMove(currentPossiblePositionInRelativeDirection);
                    }
                }
            }
        }

        private bool CheckIfThePieceOnThePositionIsEdible(GamePiece i_PlayingGamePiece, Position i_EatingPosition, Position i_AfterEatingPosition)
        {
            bool thePositionAfterEatingIsInTheBoardBoundaries = GameBoard.CheckIfThePositionIsInTheBoardBoundaries(i_AfterEatingPosition);
            bool theOtherGamePieceBelongsToTheSamePlayer, thePositionAfterTheEatingHasAGamePieceOnIt;
            bool edible = false;

            if (thePositionAfterEatingIsInTheBoardBoundaries)
            {
                theOtherGamePieceBelongsToTheSamePlayer = GameBoard.GetTheGamePieceOnRequestedPosition(i_EatingPosition).PlayerProperty.Equals(i_PlayingGamePiece.PlayerProperty);
                thePositionAfterTheEatingHasAGamePieceOnIt = GameBoard.CheckIfTheCellHasAGamePieceOnIt(i_AfterEatingPosition);
                edible = theOtherGamePieceBelongsToTheSamePlayer == false && thePositionAfterTheEatingHasAGamePieceOnIt == false;
            }

            return edible;
        }

        private void eatARivalGamePiece(Position i_CurrentPosition, Position i_NewPosition)
        {
            int rowPosition = i_NewPosition.Row - i_CurrentPosition.Row < 0 ? i_NewPosition.Row + 1 : i_NewPosition.Row - 1;
            int columnPosition = i_NewPosition.Column - i_CurrentPosition.Column < 0 ? i_NewPosition.Column + 1 : i_NewPosition.Column - 1;
            Position eatenGamePiecePosition = new Position(rowPosition, columnPosition);
            GamePiece eatenGamePiece = GameBoard.GetTheGamePieceOnRequestedPosition(eatenGamePiecePosition);

            m_PlayerThatItIsNotItsTurn.DeleteAGamePieceFromGamePiecesList(eatenGamePiece);
            GameBoard.DeleteTheGamePieceOnRequestedPosition(eatenGamePiecePosition);
            GamePieceWasEaten?.Invoke(GameBoard.Board[eatenGamePiecePosition.Row, eatenGamePiecePosition.Column]);
        }

        public void GetAMoveFromTheComputer(out Position o_CurrentPosition, out Position o_NewPosition)
        {
            List<GamePiece> gamePiecesWithPossibleMoves = new List<GamePiece>();
            Random generateRandomNumber = new Random();
            GamePiece selectedGamePieceToMakeAMoveWith;
            int gamePieceRandomIndex, randomMoveIndex;

            foreach (GamePiece currentGamePiece in m_PlayerThatItIsItsTurn.GamePieces)
            {
                if(currentGamePiece.CheckIfTheGamePieceHasAnyPossibleMoves())
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
            GameStatus = eGameStatus.OnGoing;
            m_WinnerOfTheGame = null;
            m_PlayerThatItIsNotItsTurn = Player2;
            m_PlayerThatItIsItsTurn = Player1;
            Player1.InitializeGamePiecesPositions(GetTheNumberOfRowsInTheGameBoard());
            Player2.InitializeGamePiecesPositions(GetTheNumberOfRowsInTheGameBoard());
            GameBoard.PrepareTheBoardForANewGame(Player1.GamePieces, Player2.GamePieces);
            generateNewPossibleMovesForAPlayer(Player1);
        }

        public void FinishTheGame()
        {
            GameStatus = eGameStatus.HasAWinner;
            setTheWinnerOfTheGameAndAddWinningPoints();
        }
    }
}