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

        public enum eSymbol
        {
            WhitePawn,
            WhiteKing,
            BlackPawn,
            BlackKing
        }

        //-------------------------------------------------------------------------------Members-------------------------------------------------------------------------------//
        public const int k_PointsForAKing = 4;
        public const int k_PointsForAPawn = 1;

        //------------------------------------------------------------------------------Properties-----------------------------------------------------------------------------//
        public eSymbol Symbol { get; private set; }

        public bool IsKing { get; private set; }

        public ePlayerProperty PlayerProperty { get; }

        public Position Position { get; set; }

        public List<Position> PossibleMoves { get; }

        //-----------------------------------------------------------------------------Constructors----------------------------------------------------------------------------//
        public GamePiece(eSymbol i_Symbol, Position i_Position, ePlayerProperty i_PlayerProperty)
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

            Symbol = Symbol == eSymbol.WhitePawn ? eSymbol.WhiteKing : eSymbol.BlackKing;
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
    }
}