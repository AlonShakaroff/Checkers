
namespace CheckersOnConsole
{
    public static class Constants
    {
        //--------------------------------------------------------------------------Game Pieces Symbols------------------------------------------------------------------------//
        public static readonly char sr_FirstPlayerPawnSymbol = 'O';
        public static readonly char sr_SecondPlayerPawnSymbol = 'X';
        public static readonly char sr_FirstPlayerKingSymbol = 'U';
        public static readonly char sr_SecondPlayerKingSymbol = 'K';

        //-------------------------------------------------------------------------Amount Of Game Pieces-----------------------------------------------------------------------//
        public static readonly int sr_AmountOfGamePiecesIn6X6Board = 6;
        public static readonly int sr_AmountOfGamePiecesIn8X8Board = 12;
        public static readonly int sr_AmountOfGamePiecesIn10X10Board = 20;

        //---------------------------------------------------------------------------Player Name Length------------------------------------------------------------------------//
        public static readonly int sr_MaxLengthForPlayerName = 20;

        //------------------------------------------------------------------------------Game Status----------------------------------------------------------------------------//
        public enum eGameStatus
        {
            OnGoing, HasAWinner, Draw
        }

        //---------------------------------------------------------------------------------Player------------------------------------------------------------------------------//
        public enum ePlayerProperty
        {
            Player1, Player2
        }
    }
}
