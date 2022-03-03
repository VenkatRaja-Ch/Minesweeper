using System;
using System.IO;
using System.Timers;

namespace Minesweeper_ZPRLE
{
    class Program
    {

        static int seconds = 0;

        static void displayAll(Cell[,] cell, int size)
        {

            StreamWriter file = new StreamWriter("@GameOutput.txt");
            for(int rowIndex=0; rowIndex<size; rowIndex++)
            {
                for(int colIndex=0; colIndex<size; colIndex++)
                {
                    if (cell[rowIndex, colIndex].HasMineFlag)
                    {
                        Console.Write(">");
                        file.Write(">");
                    }
                        
                    else if (cell[rowIndex, colIndex].HasMine && cell[rowIndex, colIndex].HasMineFlag)
                    {
                        Console.Write("@");
                        file.Write("@");
                    }
                        
                    else if (cell[rowIndex, colIndex].MinesAround > 0)
                    {
                        Console.Write("{0}", cell[rowIndex, colIndex].MinesAround);
                        string mines = Convert.ToString(cell[rowIndex, colIndex].MinesAround);
                        file.Write(mines);
                    }
                        
                    else if (cell[rowIndex, colIndex].HasMine)
                    {
                        Console.Write("*");
                        file.Write("*");
                    }
                        
                    else
                    {
                        Console.Write("_");
                        file.Write("_");
                    }

                }
                Console.WriteLine();
                file.WriteLine();
            }

            Console.WriteLine("Time Elapsed During game: {0} seconds", seconds);
            file.WriteLine("Time Elapsed During game: {0} seconds",seconds);
            file.Close();
        }


        static bool allPositionRevealed (Cell[,] cell, int size)
        {

            for (int rowIndex = 0; rowIndex < size; rowIndex++)
            {
                for (int colIndex = 0; colIndex < size; colIndex++)
                {
                    bool cellIsRevealed = cell[rowIndex, colIndex].IsRevealed;
                    if (!cellIsRevealed)
                        return false;
                }
            }

            return true;
        }


        static void Main(string[] args)
        {

            Console.WriteLine("WELCOME TO THE NEW GAME!");
            Console.WriteLine("Please select your difficulty:");
            Console.WriteLine("1: Easy  2:Medium    3:Hard");
            string difficulty = Console.ReadLine();
            int difficultyLevel = Convert.ToInt32(difficulty);
            int size = 0;
            if (difficultyLevel == 1)
                size = 9;
            else if (difficultyLevel == 2)
                size = 16;
            else
                size = 32;

            Console.WriteLine("The size is: {0}. Please enter co-ordinates within the size.", size);

            Board game1 = new Board(size);
            game1.Size = size;
            game1.Initialise(size);
            game1.display();

            //variables
            bool isPlaying = true;
            string playersChoice, playerXPosition, playerYPosition;
            int pChoice, pXChoice, pYChoice;


            while (isPlaying)
            {

                System.Timers.Timer gameTime = new System.Timers.Timer();
                gameTime.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                gameTime.Interval = 1000;
                gameTime.Enabled = true;

                //ask the player about the co-ordinates
                Console.WriteLine("Enter the X-Coordinate and Y-Cordinate to unfold the block");
                playerXPosition = Console.ReadLine();
                pXChoice = Convert.ToInt32(playerXPosition);
                playerYPosition = Console.ReadLine();
                pYChoice = Convert.ToInt32(playerYPosition);

                //position's edge case
                bool xPositionIsValid = (pXChoice >= 0) && (pXChoice < size);
                bool yPositionIsValid = (pYChoice >= 0) && (pYChoice < size);
                bool breakLoop = false;
                bool isDisplayedInCase2 = false;

                if (xPositionIsValid && yPositionIsValid)
                {
                    //ask the player whether to reveal the cell or put a mine flag on the cell
                    Console.WriteLine("Enter 1: Reveal the Cell     2: Put a mine flag");
                    playersChoice = Console.ReadLine();
                    pChoice = Convert.ToInt32(playersChoice);


                    switch (pChoice)
                    {
                        //if REVEAL the cell:
                        case 1:

                            //reveal the cell
                            bool blockRevealed = game1.boards[pXChoice, pYChoice].IsRevealed = true;

                            //check if there is a mine or not
                            bool minePresent = game1.boards[pXChoice, pYChoice].HasMine;

                            //if MINE:
                            if (minePresent && blockRevealed)
                            {
                                isPlaying = false;      //set isPlaying to false
                                                        //end the game, with message Player Lost
                                Console.WriteLine("Player lost there is a mine at position {0}, {1} ", playerXPosition, playerYPosition);
                                //Show the mines around number OR the blank '_'
                                displayAll(game1.boards, size);
                                breakLoop = true;
                            }
                            break;

                        // if Put a mine Flag:
                        case 2:
                            //set a hasMineFlag to true
                            game1.boards[pXChoice, pYChoice].HasMineFlag = true;
                            game1.boards[pXChoice, pYChoice].IsRevealed = true;
                            game1.display();
                            isDisplayedInCase2 = true;
                            break;

                        default:
                            Console.WriteLine("Wrong Choice");
                            break;
                    }

                    if (breakLoop)
                        break;

                    //check all the non mine positions are revealed or not
                    bool allRevealed = allPositionRevealed(game1.boards, size);

                    //if revealed YES:
                    if (allRevealed)
                    {
                        isPlaying = false;      //set isPlaying to false;
                        Console.WriteLine("Player Won!!!");     // Display player won the game.
                        displayAll(game1.boards, size);
                    }
                    else if (!isDisplayedInCase2)
                    {
                        game1.display();
                    }
                }
                else
                {
                    Console.WriteLine("Choose a Valid Range for X & Y Coordinate");
                }

                
            }
            
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            seconds++;
        }
    }
}
