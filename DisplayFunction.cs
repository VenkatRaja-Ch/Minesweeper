using System;

/*
> : MineFlag
number: Mines around the cell
* : Mines
o : Not opened block 
 */

namespace Minesweeper_ZPRLE
{
    public class DisplayFunction
    {

        public static void display(Cell[,] board, int size)
        {
            Cell currentCell;

            for (int row=0; row<size; row++)
            {
                for(int col=0; col<size; col++)
                {
                    currentCell = board[row, col];

                    if (currentCell.IsRevealed)
                    {

                        if (currentCell.HasMineFlag)
                            Console.Write(">");
                        else if (currentCell.MinesAround > 0)
                            Console.Write("{0}", currentCell.MinesAround);
                        else if (currentCell.HasMine)
                            Console.Write("*");
                        else if (currentCell.MinesAround == 0)
                            Console.WriteLine("_");
                    }
                    else
                    {
                        Console.Write("o");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
