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
            _columns = 7;
            _rows = 6;
            board = new String[_rows, _columns];
        }

        public GameBoard(int columns, int rows)
        {
            _columns = columns;
            _rows = rows;
            board = new String[_rows, _columns];
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

        public string getRow(int y)
        {
            StringBuilder fullRow = new StringBuilder();
            for (int x = 0; x < _columns; ++x)
            {
                fullRow.Append(board[y, x]);
            }
            return fullRow.ToString();
        }

        public bool insert(int x, int y, string dobber)
        {
            board[y, x] = dobber;

            return true;

        }


        private int _columns;
        private int _rows;
        private String[,] board;
    }
}
