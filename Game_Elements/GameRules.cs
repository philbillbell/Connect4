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

        private bool check_win(string row, string dobber_win)
        {
            return (row.Contains(dobber_win));
        }

        private bool check_Horizontal_win(GameBoard board, string dobber_win)
        {
            for (int y = 0; y < board.rows; y++)
            {
                if (check_win(board.get_row(y), dobber_win))
                    return true;
            }

            return false;
        }

        private bool check_vertical_win(GameBoard board, string dobber_win)
        {
            for (int x = 0; x < board.columns; x++)
            {
                if (check_win(board.get_column(x), dobber_win))
                    return true;
            }
            return false;
        }

        private bool check_diagnal(GameBoard board, int x, int y, string dobber_win, Func<int, int> Xdel, Func<int, int> Ydel)
        {
            string current_diag = board.get_diagnal(x, y, Xdel, Ydel);
            if (check_win(current_diag, dobber_win))
                return true;

            return false;
        }

        private bool check_diagnal_win(GameBoard board, string dobber_win)
        {
            for (int y = 0; y < board.rows; y++)
            {
                for (int x = 0; x < board.columns; x++)
                {
                    if (x < 4 && y < 3)
                    {//South east / north west possible
                        if (check_diagnal(board, x, y, dobber_win, (Coord) => { return ++Coord; }, (Coord) => { return ++Coord; }))
                            return true; 
                    }

                    if (x > 2 && y < 3)
                    {//South west / north east possible
                        if (check_diagnal(board, x, y, dobber_win, (Coord) => { return --Coord; }, (Coord) => { return ++Coord; }))
                            return true;
                    }
                }
            }
            return false;
        }

        
        public bool check_for_win(GameBoard board, string dobber_win)
        {
            if (check_Horizontal_win(board, dobber_win) || check_vertical_win(board, dobber_win) || check_diagnal_win(board, dobber_win))
                return true;
            
            return false;
        }
    }
}
