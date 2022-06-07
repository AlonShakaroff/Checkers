using System;
using System.Collections.Generic;

namespace CheckersLogicEngine
{
    public class GamePiece
    {
        public enum ePlayerProperty
        {
            Player1,
            Player2,
        }

        //-------------------------------------------------------------------------------Members-------------------------------------------------------------------------------//
        public const char k_FirstPlayerPawnSymbol = 'X';
        public const char k_SecondPlayerPawnSymbol = 'O';
        public const char k_FirstPlayerKingSymbol = 'K';
        public const char k_SecondPlayerKingSymbol = 'U';
        public const int k_PointsForAKing = 4;
        public const int k_PointsForAPawn = 1;
        private bool m_IsKing;
        private char m_Symbol;
        private Position m_Position;
        private readonly List<Position> r_PossibleMoves;
        private readonly ePlayerProperty r_PlayerProperty;

        //------------------------------------------------------------------------------Properties-----------------------------------------------------------------------------//
        public char Symbol
        {
            get 
            {
                return m_Symbol; 
            }
        }

        public bool IsKing
        {
            get 
            { 
                return m_IsKing; 
            }
        }

        public ePlayerProperty PlayerProperty
        {
            get 
            {
                return r_PlayerProperty; 
            }
        }

        public Position Position
        {
            get 
            { 
                return m_Position; 
            }

            set 
            {
                m_Position = value;
            }
        }

        public List<Position> PossibleMoves
        {
            get 
            { 
                return r_PossibleMoves;
            }
        }

        //-----------------------------------------------------------------------------Constructors----------------------------------------------------------------------------//
        public GamePiece(char i_Symbol, Position i_Position, ePlayerProperty i_PlayerProperty)
        {
            m_IsKing = false;
            m_Symbol = i_Symbol;
            m_Position = i_Position;
            r_PossibleMoves = new List<Position>();
            r_PlayerProperty = i_PlayerProperty;
        }

        //-------------------------------------------------------------------------------Methods-------------------------------------------------------------------------------//
        public void MakeThePawnAKing()
        {
            m_IsKing = true;

            m_Symbol = m_Symbol == k_FirstPlayerPawnSymbol ? k_FirstPlayerKingSymbol : k_SecondPlayerKingSymbol;
        }

        public void AddPossibleMove(Position i_NewPossibleMovePosition)
        {
            r_PossibleMoves.Add(i_NewPossibleMovePosition);
        }

        public bool CheckIfTheGamePieceHasAnyPossibleMoves()
        {
            return r_PossibleMoves.Count != 0;
        }

        public void ClearGamePiecePossibleMoves()
        {
            r_PossibleMoves.Clear();
        }

        public bool CheckIfThePositionIsAPossibleMove(Position i_Position)
        {
            bool validMove = false;

            foreach(Position currentPossibleMove in r_PossibleMoves)
            {
                if(currentPossibleMove.Equals(i_Position))
                {
                    validMove = true;
                    break;
                }
            }

            return validMove;
        }

        public Position GetThePositionAfterAnEatingMoveOfTheGamePiece()
        {
            Position newPositionAfterEating = null;

            foreach(Position position in r_PossibleMoves)
            {
                if(Math.Abs(m_Position.Row - position.Row) == 2)
                {
                    newPositionAfterEating = position;
                    break;
                }
            }

            return newPositionAfterEating;
        }
    }
}