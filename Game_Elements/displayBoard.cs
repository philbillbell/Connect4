using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Elements
{
    public class DisplayBoard
    {
        public DisplayBoard()
        {
            _message = "";
        }

        public string message
        {
            get { return _message; }
            set { _message = value; }
        }

        public void show_board(GameBoard board)
        {
            Console.Clear();
            string cell_contents = "";

            Console.WriteLine("  1   2   3   4   5   6   7");
            for (int y = 0; y < board.rows; y++)
            {
                Console.WriteLine("-----------------------------");
                Console.Write("| ");
                for (int x = 0; x < board.columns; x++)
                {
                    cell_contents = board.getCell(x, y);
                    if (!cell_contents.Equals(" "))
                        Console.BackgroundColor = (cell_contents.Equals("h")) ? ConsoleColor.Blue : ConsoleColor.Red;

                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" | ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine(_message);

            if (!string.IsNullOrEmpty(_message))
                _message = "";
        }

        private string _message;

    }
}
