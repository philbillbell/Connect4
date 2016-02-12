using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Elements
{
    public class GameBoard
    {
        public GameBoard()
        {
            Setup_board(7, 6);
        }

        public GameBoard(int columns, int rows)
        {
            Setup_board(columns, rows);
        }

        private void Setup_board(int columns, int rows)
        {
            _columns = columns;
            _rows = rows;
            size = (_columns) * (_rows);
        }

        public void init()
        {
            board = new String[_columns, _rows];
            current_count = 0;

            for (int y = 0; y < _rows; ++y)
            {
                for (int x = 0; x < _columns; ++x)
                {
                    board[x, y] = " ";
                }
            }
        }

        public int columns
        {
            get { return _columns; }
            //set { _columns = value; }
        }

        public int rows
        {
            get { return _rows; }
            //set { _rows = value; }
        }

        public string get_row(int y)
        {
            StringBuilder fullRow = new StringBuilder();
            for (int x = 0; x < _columns; ++x)
            {
                fullRow.Append(board[x, y]);
            }
            return fullRow.ToString();
        }

        public string get_cell(int x, int y)
        {
            return board[x, y].ToString();
        }

        public string get_column(int x)
        {
            StringBuilder fullRow = new StringBuilder();
            for (int y = 0; y < _rows; ++y)
            {
                fullRow.Append(board[x, y]);
            }
            return fullRow.ToString();
        }

        public string get_diagnal(int x, int y, Func<int, int> Xdel, Func<int, int> Ydel)
        {
            StringBuilder fullRow = new StringBuilder();
            for(int i = 0; i < 4; ++i)
            {
                fullRow.Append(board[x, y]);
                x = Xdel(x);
                y = Ydel(y);
            }
            return fullRow.ToString();
        }

        public bool insert(int x, int y, string dobber)
        {
            board[x, y] = dobber;
            return true;
        }

        public bool validate_input(int x)
        {
            return (x < _columns) ? true : false;
        }

        private bool place_dobber_in_column(int x, string player)
        {
            for (int y = _rows - 1; y >= 0; --y)
            {
                if (board[x, y].Equals(" "))
                {
                    insert(x, y, player);
                    current_count++;
                    return true;
                }
            }
            return false;
        }

        public bool drop_dobber(int x, string player)
        {
            try
            {
                if (!validate_input(x))
                    return false;

                return place_dobber_in_column(x, player);
            }
            catch
            {
                
            }

            return false;
        }

        public bool is_board_full()
        {
            return (size == current_count);
        }

        private int _columns;
        private int _rows;
        private String[,] board;
        private int size;
        private int current_count;
    }
}
