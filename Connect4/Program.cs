﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            displayBoard board = new displayBoard();
            board.fill_board();
            board.show_board();
        }
    }
}
