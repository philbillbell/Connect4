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

        public void show_board()
        {
            for (int y = 0; y < rows; y++)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("| " + board[y,0] + " | " + board[y, 1] + " | " + board[y, 2] + " | " + board[y, 3] + " | " + board[y, 4] + " | " + board[y, 5] + " | " + board[y, 6] + " | ");
                
            }
            Console.WriteLine("----------------------");
        }

        private int rows;
        private int cols;
        private String[,] board;

    }
}
