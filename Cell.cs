using System;
namespace Minesweeper_ZPRLE
{
    public class Cell
    {
        private int xPosition;
        private int yPosition;
        private int minesAround;
        private bool isRevealed;
        private bool hasMine;
        private bool hasMineFlag;

        public Cell()
        {
            xPosition = 0;
            yPosition = 0;
            minesAround = 0;
            isRevealed = false;
            hasMine = false;
            hasMineFlag = false;
        }

        public Cell(int xPosition, int yPosition, int minesAround, bool isRevealed, bool hasMine, bool hasMineFlag)
        {
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.minesAround = minesAround;
            this.isRevealed = isRevealed;
            this.hasMine = hasMine;
            this.hasMineFlag = hasMineFlag;
        }

        public int XPosition
        {
            get { return xPosition;  }
            set { xPosition = value; }
        }

        public int YPosition
        {
            get { return yPosition; }
            set { yPosition = value; }
        }

        public int MinesAround
        {
            get { return minesAround; }
            set { minesAround = value; }
        }

        public bool IsRevealed
        {
            get { return isRevealed;  }
            set { isRevealed = value; }
        }

        public bool HasMine
        {
            get { return hasMine; }
            set { hasMine = value; }
        }

        public bool HasMineFlag
        {
            get { return hasMineFlag; }
            set { hasMineFlag = value; }
        }
    }
}
