using System;
using System.Collections.Generic;

namespace CheckersEngine
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

        //------------------------------------------------------------------------------Properties-----------------------------------------------------------------------------//
        public char Symbol { get; private set; }

        public bool IsKing { get; private set; }

        public ePlayerProperty PlayerProperty { get; }

        public Position Position { get; set; }

        public List<Position> PossibleMoves { get; }

        //-----------------------------------------------------------------------------Constructors----------------------------------------------------------------------------//
        public GamePiece(char i_Symbol, Position i_Position, ePlayerProperty i_PlayerProperty)
        {
            IsKing = false;
            Symbol = i_Symbol;
            Position = i_Position;
            PossibleMoves = new List<Position>();
            PlayerProperty = i_PlayerProperty;
        }

        //-------------------------------------------------------------------------------Methods-------------------------------------------------------------------------------//
        public void MakeThePawnAKing()
        {
            IsKing = true;

            Symbol = Symbol == k_FirstPlayerPawnSymbol ? k_FirstPlayerKingSymbol : k_SecondPlayerKingSymbol;
        }

        public void AddPossibleMove(Position i_NewPossibleMovePosition)
        {
            PossibleMoves.Add(i_NewPossibleMovePosition);
        }

        public bool CheckIfTheGamePieceHasAnyPossibleMoves()
        {
            return PossibleMoves.Count != 0;
        }

        public void ClearGamePiecePossibleMoves()
        {
            PossibleMoves.Clear();
        }

        public bool CheckIfThePositionIsAPossibleMove(Position i_Position)
        {
            bool validMove = false;

            foreach(Position currentPossibleMove in PossibleMoves)
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

            foreach(Position position in PossibleMoves)
            {
                if(Math.Abs(Position.Row - position.Row) == 2)
                {
                    newPositionAfterEating = position;
                    break;
                }
            }

            return newPositionAfterEating;
        }
    }
}