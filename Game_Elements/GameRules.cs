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

        private bool check_Horizontal_win(GameBoard board)
        {
            string current_row = "";
            for (int y = 0; y < board.rows; y++)
            {
                current_row = board.getRow(y);
                if (current_row.Contains("hhhh"))
                    return true;

            }

            return false;
        }

        public bool check_for_win(GameBoard board)
        {
            if (check_Horizontal_win(board))
                return true;

            return false;
        }

        private int total_connect;
        

    }
}
