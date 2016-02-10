using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Rules
{
    public class GameRules
    {
        public GameRules()
        {
            cols = 7;
            rows = 6;
        }

        public GameRules(int cols, int rows, int total_connect = 4)
        {
            this.cols = cols;
            this.rows = rows;
            max_cols = cols - total_connect;
            max_rows = rows - total_connect;
        }

        private string getRow(String[,] board, int y)
        {
            StringBuilder fullRow = new StringBuilder();
            for (int x = 0; x < cols; ++x)
            {
                fullRow.Append(board[y, x]);
            }
            return fullRow.ToString();
        }

        private bool check_Horizontal_win(String[,] board)
        {
            string current_row = "";
            for (int y = 0; y < rows; y++)
            {
                current_row = getRow(board, y);
                if (current_row.Contains("hhhh"))
                    return true;

            }

            return false;
        }

        public bool check_for_win(String[,] board)
        {
            if (check_Horizontal_win(board))
                return true;

            return false;
        }

        private int total_connect;
        private int cols;
        private int rows;
        private int max_cols;
        private int max_rows;

    }
}
