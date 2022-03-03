using System;
namespace Minesweeper_ZPRLE
{
    public class TotalMinesDecider
    {
        public static int GetTotalMines(int size)
        {
            if (size <= 10)
                return 10;
            else if (size <= 16)
                return 40;
            else if (size <= 30)
                return 99;
            else
                return 100;
        }
    }
}
