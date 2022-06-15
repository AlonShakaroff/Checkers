namespace CheckersEngine
{
    public class BoardCell
    {
        //-------------------------------------------------------------------------------Members-------------------------------------------------------------------------------//
        private bool m_IsTaken;
        private GamePiece m_GamePiece;

        //------------------------------------------------------------------------------Properties-----------------------------------------------------------------------------//
        public GamePiece GamePiece
        {
            get
            {
                return m_GamePiece;
            }

            set
            {
                m_GamePiece = value;
                m_IsTaken = value != null;
            }
        }

        public Position Position { get; }

        //-----------------------------------------------------------------------------Constructors----------------------------------------------------------------------------//
        public BoardCell(Position i_Position)
        {
            Position = i_Position;
            m_IsTaken = false;
            m_GamePiece = null;
        }

        //-------------------------------------------------------------------------------Methods-------------------------------------------------------------------------------//
        public bool IsTheCellTaken()
        {
            return m_IsTaken;
        }
    }
}