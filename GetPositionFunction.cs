using System;
namespace Minesweeper_ZPRLE
{
    public class GetPositionFunction
    { 

        public static int GetIndex(int size)
        {
            Random randomNumber = new Random();
            int randomPosition = randomNumber.Next(0,size);

            return randomPosition;
        }
    }
}
