
using System;
using System.IO;

namespace CheckersOnConsole
{
    class Player
    {
        //-------------------------------------------------------------------------------Members-------------------------------------------------------------------------------//
        private GamePiece[] m_GamePiecesArray;
        private string m_PlayerName;
        private bool m_IsPlayersTurn;
        private bool m_IsPlayerWon;
        private int m_CurrentNumberOfStones;

        //------------------------------------------------------------------------------Properties-----------------------------------------------------------------------------//
        public int NumberOfGamePiecesLeft
        {
            get
            {
                return m_CurrentNumberOfStones;
            }
        }

        public string Name
        {
            get
            {
                return m_PlayerName;
            }
        }

        public GamePiece[] GamePieces
        {
            get { return m_GamePiecesArray; }
        }

        //-----------------------------------------------------------------------------Constructors----------------------------------------------------------------------------//
        public Player(string i_PlayerName, int i_NumberOfGamePieces, bool i_IsThePlayerPlayingFirst, int i_NumberOfRowsOnTheBoardGame)
        {
            m_PlayerName = i_PlayerName;
            m_GamePiecesArray = new GamePiece[i_NumberOfGamePieces];
            m_CurrentNumberOfStones = i_NumberOfGamePieces;
            m_IsPlayerWon = false;
            m_IsPlayersTurn = i_IsThePlayerPlayingFirst;

            initializeGamePiecesPositions(i_NumberOfRowsOnTheBoardGame);
        }

        //----------------------------------------------------------------------------initialization---------------------------------------------------------------------------//
        private void initializeGamePiecesPositions(int i_NumberOfRowsOnTheBoardGame)
        {
            int numberOfGamePiecesInARow = i_NumberOfRowsOnTheBoardGame / 2;
            Position gamePiecePosition = calculateTheStartingPositionOfTheGamePieces(i_NumberOfRowsOnTheBoardGame);
            int currentRow = gamePiecePosition.Row, currentColumn = gamePiecePosition.Column;
            char pawnSymbol = m_IsPlayersTurn ? Constants.sr_FirstPlayerPawnSymbol : Constants.sr_SecondPlayerPawnSymbol;
            Constants.ePlayerProperty playerProperty = m_IsPlayersTurn ? Constants.ePlayerProperty.Player1 : Constants.ePlayerProperty.Player2;

            for (int gamePiecesCounter = 0; gamePiecesCounter < m_CurrentNumberOfStones; ++gamePiecesCounter)
            {
                m_GamePiecesArray[gamePiecesCounter] = new GamePiece(pawnSymbol, gamePiecePosition, gamePiecesCounter, playerProperty);

                calculateTheStartingPositionOfTheNextGamePiece(gamePiecesCounter, ref currentRow, ref currentColumn, out gamePiecePosition, numberOfGamePiecesInARow);
            }
        }

        private Position calculateTheStartingPositionOfTheGamePieces(int i_NumberOfRowsOnTheBoardGame)
        {
            int startingRow, startingColumn;

            if (m_IsPlayersTurn == true)
            {
                startingRow = 0;
                startingColumn = 1;
            }
            else
            {
                startingColumn = 0;

                switch (i_NumberOfRowsOnTheBoardGame)
                {
                    case 6:
                        startingRow = 4;
                        break;
                    case 10:
                        startingRow = 6;
                        break;
                    default:
                        startingRow = 5;
                        break;
                }
            }

            return new Position(startingRow, startingColumn);
        }

        private void calculateTheStartingPositionOfTheNextGamePiece(int i_GamePiecesCounter, ref int o_CurrentRow, ref int o_CurrentColumn, out Position o_GamePiecePosition, int i_NumberOfGamePiecesInARow)
        {
            if (++i_GamePiecesCounter % i_NumberOfGamePiecesInARow == 0)
            {
                ++o_CurrentRow;
                o_CurrentColumn = o_CurrentRow % 2 == 0 ? 1 : 0;
            }
            else
            {
                o_CurrentColumn += 2;
            }

            o_CurrentColumn %= 8;
            o_GamePiecePosition = new Position(o_CurrentRow, o_CurrentColumn);
        }

        //-------------------------------------------------------------------------------Methods-------------------------------------------------------------------------------//
        public void PlayersTurnToPlay()
        {
            m_IsPlayersTurn = true;
        }

        public void PlayerHasWonTheGame()
        {
            m_IsPlayerWon = true;
        }

        public bool DidThePlayerWinTheGame()
        {
            return m_IsPlayerWon;
        }

        public void PlayersTurnEnded()
        {
            m_IsPlayersTurn = false;

            for(int i = 0; i < m_CurrentNumberOfStones; ++i)
            {
                m_GamePiecesArray[i].DeleteGamePiecePossibleMoves();
            }
        }

        public bool IsThePlayerHasAnyPossibleMoves()
        {
            bool hasPossibleMoves = false;

            for(int i = 0; i < m_CurrentNumberOfStones; ++i)
            {
                if(m_GamePiecesArray[i].IsTheGamePieceHasAnyPossibleMoves())
                {
                    hasPossibleMoves = true;
                    break;
                }
            }

            return hasPossibleMoves;
        }

        public void DeleteAGamePieceByIndex(int i_GamePieceIndexInPlayerGamePiecesArray)
        {
            --m_CurrentNumberOfStones;

            m_GamePiecesArray[i_GamePieceIndexInPlayerGamePiecesArray] = m_GamePiecesArray[m_CurrentNumberOfStones];
            m_GamePiecesArray[i_GamePieceIndexInPlayerGamePiecesArray].GamePieceIndex = i_GamePieceIndexInPlayerGamePiecesArray;
        }
    }
}