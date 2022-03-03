/*
 * by default the structure of the board is a 9x9 Matrix
*/

using static Minesweeper_ZPRLE.GetPositionFunction;
using static Minesweeper_ZPRLE.TotalMinesDecider;
using static Minesweeper_ZPRLE.MinesAroundFunction;

namespace Minesweeper_ZPRLE
{
    public class Board 
    {
        private int size;
        private Cell cells;
        public Cell[,] boards;
        //getters and setters
        public int Size
        {
            get { return size; }
            set { size = value; }
        }
        public Cell GetCell
        {
            get { return cells;   }
            set { cells = value;  }
        }

        //default consturctor
        public Board()
        {
            size = 9;
            boards = new Cell[size, size];

            //Board[,] boards = new Board[9, 9];
            loopToInitialiseEachCell(9);
        }

        //parameterised constructor
        public Board (int size)
        {
            this.size = size;
            boards = new Cell[size, size];
            loopToInitialiseEachCell(size);
        }

        //loop to initialise each cell
        public void loopToInitialiseEachCell(int size)
        {
            //boards = new Board[5,5];
            //initialising the board
            
            
            for (int rowIndex=0; rowIndex < size; rowIndex++)
            {
                for(int colIndex = 0; colIndex < size; colIndex++)
                {
                    boards[(rowIndex), (colIndex)] = new Cell();
                    boards[rowIndex, colIndex].XPosition = rowIndex;
                    boards[rowIndex, colIndex].YPosition = colIndex;
                }
            }
        }

        //to initialise before game starts
        public void Initialise (int size)
        {

            int totalMines = GetTotalMines(size);                   //get total mines for the board

            for (int index = 0; index < totalMines; index++)        //set the mines to the board
            {
                int row = GetIndex(size);
                int col = GetIndex(size);
                boards[row,col].HasMine = true;
            }
            
            SetMinesAround(size, boards);                            //calculate mines around each cell

        }

        public void display()
        {
            DisplayFunction.display(boards, size);
        }

    }
}
