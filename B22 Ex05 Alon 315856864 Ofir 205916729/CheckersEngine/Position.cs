namespace CheckersLogicEngine
{
    public class Position
    {
        
        public enum eDirection
        {
            DownLeft,
            DownRight,
            UpLeft,
            UpRight,
        }

        //-------------------------------------------------------------------------------Members-------------------------------------------------------------------------------//
        private int m_Row;
        private int m_Column;

        //------------------------------------------------------------------------------Properties-----------------------------------------------------------------------------//
        public int Row
        {
            get 
            {
                return m_Row;
            }

            set
            {
                m_Row = value; 
            }
        }

        public int Column
        {
            get
            {
                return m_Column; 
            }

            set
            {
                m_Column = value; 
            }
        }

        public Position(int i_Row, int i_Column)
        {
            m_Row = i_Row;
            m_Column = i_Column;
        }

        public Position GetThePositionLocatedInTheDirectionRelativeToThisPosition(eDirection i_RequestedDirection)
        {
            Position requestedPosition = null;

            switch(i_RequestedDirection)
            {
                case eDirection.DownLeft:
                    requestedPosition = new Position(m_Row + 1, m_Column - 1);
                    break;
                case eDirection.DownRight:
                    requestedPosition = new Position(m_Row + 1, m_Column + 1);
                    break;
                case eDirection.UpLeft:
                    requestedPosition = new Position(m_Row - 1, m_Column - 1);
                    break;
                case eDirection.UpRight:
                    requestedPosition = new Position(m_Row - 1, m_Column + 1);
                    break;
            }

            return requestedPosition;
        }

        public override bool Equals(object i_Object)
        {
            bool equals;

            if (i_Object == null || this.GetType().Equals(i_Object.GetType()) == false)
            {
                equals = false;
            }
            else
            {
                Position position = (Position)i_Object;
                equals = (m_Row == position.Row) && (m_Column == position.Column);
            }

            return equals;
        }

        public override string ToString()
        {
            return $"({m_Row},{m_Column})";
        }
    }
}