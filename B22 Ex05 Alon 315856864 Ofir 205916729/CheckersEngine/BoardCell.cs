﻿using System.Collections.Generic;

namespace CheckersOnConsole
{
    public class BoardCell
    {
        //-------------------------------------------------------------------------------Members-------------------------------------------------------------------------------//
        private bool m_IsTaken;
        private GamePiece m_GamePiece;

        //------------------------------------------------------------------------------Properties-----------------------------------------------------------------------------//
        public GamePiece GamePiece
        {
            get { return m_GamePiece; }
            set
            {
                m_GamePiece = value;
                m_IsTaken = value != null;
            }
        }

        //-----------------------------------------------------------------------------Constructors----------------------------------------------------------------------------//
        public BoardCell()
        {
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
