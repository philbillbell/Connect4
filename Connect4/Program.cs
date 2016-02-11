using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Elements;

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            GameRules rules = new GameRules();
            GameBoard gameboard = new GameBoard();
            DisplayBoard displayboard = new DisplayBoard();

            gameboard.init();

            gameboard.dropDobber(0, "h");
            displayboard.show_board(gameboard);
            if (rules.check_for_win(gameboard))
                Console.WriteLine("Winner Winner Chicken Dinner");
            Console.ReadKey();

            gameboard.dropDobber(0, "c");
            displayboard.show_board(gameboard);
            if (rules.check_for_win(gameboard))
                Console.WriteLine("Winner Winner Chicken Dinner");
            Console.ReadKey();

            gameboard.dropDobber(0, "h");
            displayboard.show_board(gameboard);
            if (rules.check_for_win(gameboard))
                Console.WriteLine("Winner Winner Chicken Dinner");
            Console.ReadKey();

            gameboard.dropDobber(0, "h");
            displayboard.show_board(gameboard);
            if (rules.check_for_win(gameboard))
                Console.WriteLine("Winner Winner Chicken Dinner");

            Console.ReadKey();





        }
    }
}
