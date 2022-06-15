namespace CheckersEngine
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

        //------------------------------------------------------------------------------Properties-----------------------------------------------------------------------------//
        public int Row { get; set; }

        public int Column { get; set; }

        public Position(int i_Row, int i_Column)
        {
            Row = i_Row;
            Column = i_Column;
        }

        public Position GetThePositionLocatedInTheDirectionRelativeToThisPosition(eDirection i_RequestedDirection)
        {
            Position requestedPosition = null;

            switch(i_RequestedDirection)
            {
                case eDirection.DownLeft:
                    requestedPosition = new Position(Row + 1, Column - 1);
                    break;
                case eDirection.DownRight:
                    requestedPosition = new Position(Row + 1, Column + 1);
                    break;
                case eDirection.UpLeft:
                    requestedPosition = new Position(Row - 1, Column - 1);
                    break;
                case eDirection.UpRight:
                    requestedPosition = new Position(Row - 1, Column + 1);
                    break;
            }

            return requestedPosition;
        }

        public override bool Equals(object i_Object)
        {
            bool equals;

            if (i_Object == null || GetType() == i_Object.GetType() == false)
            {
                equals = false;
            }
            else
            {
                Position position = (Position)i_Object;
                equals = (Row == position.Row) && (Column == position.Column);
            }

            return equals;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Row * 397) ^ Column;
            }
        }

        public override string ToString()
        {
            return $"({Row},{Column})";
        }
    }
}