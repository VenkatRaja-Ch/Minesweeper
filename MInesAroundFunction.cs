namespace Minesweeper_ZPRLE
{
    public class MinesAroundFunction
    {
        public static void SetMinesAround(int size, Cell[,] board)
        {

            int mines = 0;

            //traversing around the board
            for (int row=0; row<size; row++)
            {
                for (int col=0; col<size; col++)
                {

                    Cell currentCell = board[row, col];


                    //LEFT DIAGONAL [UP]
                    bool _itsUpLeftDiagonal = (currentCell.XPosition > 0) && (currentCell.YPosition > 0);
                    if (_itsUpLeftDiagonal)
                    {
                        Cell upLeftDiagonalCell = board[row - 1, col - 1];

                        bool _upLeftDiagonalCellHasMine = upLeftDiagonalCell.HasMine;
                        if (_upLeftDiagonalCellHasMine)
                            mines++;
                    }


                    //UP
                    bool _itsUpperCell = (currentCell.XPosition > 0);
                    if (_itsUpperCell)
                    {
                        Cell upperCell = board[row - 1, col];

                        bool _upperCellHasMine = upperCell.HasMine;
                        if (_upperCellHasMine)
                            mines++;
                    }


                    //RIGHT DIAGONAL [UP]
                    bool _itsRightDiagonal = (currentCell.XPosition > 0) && (currentCell.YPosition < (size-1));
                    if (_itsRightDiagonal)
                    {
                        Cell righttDiagonalCell = board[row - 1, col + 1];

                        bool _rightDiagonalCellHasMine = righttDiagonalCell.HasMine;
                        if (_rightDiagonalCellHasMine)
                            mines++;
                    }


                    //LEFT
                    bool _itsLeftCell = (currentCell.YPosition > 0);
                    if (_itsLeftCell)
                    {
                        Cell leftCell = board[row, col-1];

                        bool _leftCellHasMine = leftCell.HasMine;
                        if (_leftCellHasMine)
                            mines++;
                    }

                    //RIGHT
                    bool _itsRightCell = (currentCell.YPosition < (size-1));
                    if (_itsRightCell)
                    {
                        Cell rightCell = board[row, col + 1];

                        bool _rightCellHasMine = rightCell.HasMine;
                        if (_rightCellHasMine)
                            mines++;
                    }


                    //LEFT DIAGONAL [DOWN]
                    bool _itsDownLeftDiagonal = (currentCell.XPosition < (size-1)) && (currentCell.YPosition > 0);
                    if (_itsDownLeftDiagonal)
                    {
                        Cell downLeftDiagonalCell = board[row + 1, col - 1];

                        bool _downLeftDiagonalCellHasMine = downLeftDiagonalCell.HasMine;
                        if (_downLeftDiagonalCellHasMine)
                            mines++;
                    }


                    //DOWN
                    bool _itsLowerCell = (currentCell.XPosition < (size-1));
                    if (_itsLowerCell)
                    {
                        Cell lowerCell = board[row + 1, col];

                        bool _lowerCellHasMine = lowerCell.HasMine;
                        if (_lowerCellHasMine)
                            mines++;
                    }


                    //RIGHT DIAGONAL [DOWN]
                    bool _itsLowerRightDiagonal = (currentCell.XPosition > 0 && currentCell.XPosition < (size-1)) && (currentCell.YPosition < (size - 1));
                    if (_itsLowerRightDiagonal)
                    {
                        Cell lowerRightDiagonalCell = board[row-1, col + 1];

                        bool _lowerRightDiagonalCellHasMine = lowerRightDiagonalCell.HasMine;
                        if (_lowerRightDiagonalCellHasMine)
                            mines++;
                    }



                    //setting the mines to the current cell
                    currentCell.MinesAround = mines;
                    mines = 0;      //reset mine for another cell
 
                }
            }
 
        }
    }
}
