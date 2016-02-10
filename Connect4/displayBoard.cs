using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    class displayBoard
    {
        public displayBoard()
        {
            rows = 6;
            cols = 7;
            board = new String[rows, cols];
            
        }

        public void fill_board()
        {
            for (int y = 0; y < rows; ++y)
            {
                for (int x = 0; x < cols; ++x)
                {
                    board[y, x] = "h";
                }
            }
        }


        public void show_board()
        {
            for (int y = 0; y < rows; y++)
            {
                Console.WriteLine("-----------------------------");
                Console.Write("| ");
                for (int x = 0; x < cols; x++)
                {
                    Console.BackgroundColor = (board[y, x] == "h") ? ConsoleColor.Blue: ConsoleColor.Red;
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" | ");
                }
                Console.WriteLine("");                
            }
            Console.WriteLine("-----------------------------");            
        }

        private int rows;
        private int cols;
        private String[,] board;

    }
}
