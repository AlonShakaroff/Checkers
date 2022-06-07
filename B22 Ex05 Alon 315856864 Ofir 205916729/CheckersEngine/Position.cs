
namespace CheckersOnConsole
{
    public class Position
    {
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

        public override bool Equals(object i_Object)
        {
            bool equals = true;

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
    }
}
