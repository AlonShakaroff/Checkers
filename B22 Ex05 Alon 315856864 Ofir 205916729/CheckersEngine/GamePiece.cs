using System.Collections.Generic;

namespace CheckersOnConsole
{
    public class GamePiece
    {
        //-------------------------------------------------------------------------------Members-------------------------------------------------------------------------------//
        private bool m_IsKing;
        private char m_Symbol;
        private int m_GamePieceIndexOnGamePiecesArray;
        private Position m_Position;
        private List<Position> m_PossibleMoves;
        private List<Position> m_Threads;
        private Constants.ePlayerProperty m_PlayerProperty;

        //------------------------------------------------------------------------------Properties-----------------------------------------------------------------------------//
        public char Symbol
        {
            get { return m_Symbol; }
        }

        public bool IsKing
        {
            get { return m_IsKing; }
        }

        public Constants.ePlayerProperty PlayerProperty
        {
            get { return m_PlayerProperty; }
        }

        public int GamePieceIndex
        {
            get { return m_GamePieceIndexOnGamePiecesArray; }
            set { m_GamePieceIndexOnGamePiecesArray = value; }
        }

        public Position Position
        {
            get { return m_Position; }
            set { m_Position = value; }
        }

        //-----------------------------------------------------------------------------Constructors----------------------------------------------------------------------------//
        public GamePiece(char i_Symbol, Position i_Position, int i_PawnIndex, Constants.ePlayerProperty i_PlayerProperty)
        {
            m_IsKing = false;
            m_Symbol = i_Symbol;
            m_Position = i_Position;
            m_GamePieceIndexOnGamePiecesArray = i_PawnIndex;
            m_PossibleMoves = new List<Position>();
            m_Threads = new List<Position>();
            m_PlayerProperty = i_PlayerProperty;
        }

        //-------------------------------------------------------------------------------Methods-------------------------------------------------------------------------------//
        public void MakeThePawnAKing()
        {
            m_IsKing = true;

            m_Symbol = m_Symbol == Constants.sr_FirstPlayerPawnSymbol ? Constants.sr_FirstPlayerKingSymbol : Constants.sr_SecondPlayerKingSymbol;
        }

        public void NewPossibleMoveAvailable(Position i_NewPossibleMovePosition)
        {
            m_PossibleMoves.Add(i_NewPossibleMovePosition);
        }

        public bool IsTheGamePieceHasAnyPossibleMoves()
        {
            return m_PossibleMoves.Count != 0;
        }

        public void DeleteGamePiecePossibleMoves()
        {
            m_PossibleMoves.Clear();
        }

        public bool IsThePositionAPossibleMove(Position i_Position)
        {
            bool validMove = false;

            foreach(Position possibleMove in m_PossibleMoves)
            {
                if(possibleMove.Equals(i_Position))
                {
                    validMove = true;
                    break;
                }
            }

            return validMove;
        }

        public void AddANewThread(Position i_NewThread)
        {
            m_Threads.Add(i_NewThread);
        }

        public void RemoveAllThreads()
        {
            m_Threads.Clear();
        }
    }
}
