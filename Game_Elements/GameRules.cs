using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Elements
{
    public class GameRules
    {
        public GameRules()
        {
            
        }   


        private bool check_win(string row)
        {
            return (row.Contains(human_win) || row.Contains(computer_win));
        }

        private bool check_Horizontal_win(GameBoard board)
        {
            for (int y = 0; y < board.rows; y++)
            {
                if (check_win(board.getRow(y)))
                    return true;
            }

            return false;
        }

        private bool check_Vertical_win(GameBoard board)
        {
            for (int x = 0; x < board.columns; x++)
            {
                if (check_win(board.getColumn(x)))
                    return true;
            }
            return false;
        }

        private bool check_diagnal(GameBoard board, int x, int y, Func<int, int> Xdel, Func<int, int> Ydel)
        {
            string current_diag = board.getDiagnal(x, y, Xdel, Ydel);
            if (check_win(current_diag))
                return true;

            return false;
        }

        private bool check_Diagnal_win(GameBoard board)
        {
            for (int y = 0; y < board.rows; y++)
            {
                for (int x = 0; x < board.columns; x++)
                {
                    if (x < 4 && y < 3)
                    {//South east / north west possible
                        if (check_diagnal(board, x, y, (Coord) => { return ++Coord; }, (Coord) => { return ++Coord; }))
                            return true;
                    }

                    if (x > 2 && y < 3)
                    {//South west / north east possible
                        if (check_diagnal(board, x, y, (Coord) => { return --Coord; }, (Coord) => { return ++Coord; }))
                            return true;
                    }
                }
            }
            return false;
        }

        
        public bool check_for_win(GameBoard board)
        {
            if (check_Horizontal_win(board) || check_Vertical_win(board) || check_Diagnal_win(board))
                return true;
            
            return false;
        }

        private const string computer_win = "cccc";
        private const string human_win = "hhhh";
    }
}
