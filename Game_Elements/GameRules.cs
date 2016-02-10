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

        private bool check_Vertical_win(GameBoard board)
        {
            string current_colum = "";
            for (int y = 0; y < board.columns; y++)
            {
                current_colum = board.getColumn(y);
                if (current_colum.Contains("hhhh"))
                    return true;

            }

            return false;
        }

        private bool check_Diagnal_win(GameBoard board)
        {
            string current_colum = "";
            for (int y = 0; y < board.columns; y++)
            {
                for (int x = 0; x < board.rows; x++)
                {
                    if (x < 4 && y < 3)
                    {//South east possible
                        current_colum = board.getDiagnal(x, y, (Coord) => { return ++Coord; }, (Coord) => { return ++Coord; });
                        if (current_colum.Contains("hhhh"))
                            return true;
                    }

                    if (x < 4 && y > 2)
                    {//North East possible
                        current_colum = board.getDiagnal(x, y, (Coord) => { return ++Coord; }, (Coord) => { return --Coord; });
                        if (current_colum.Contains("hhhh"))
                            return true;
                    }

                    if (x > 2 && y < 3)
                    {//South west possible
                        current_colum = board.getDiagnal(x, y, (Coord) => { return --Coord; }, (Coord) => { return ++Coord; });
                        if (current_colum.Contains("hhhh"))
                            return true;
                    }

                    if (x > 2 && y > 2)
                    {//North west possible
                        current_colum = board.getDiagnal(x, y, (Coord) => { return --Coord; }, (Coord) => { return --Coord; });
                        if (current_colum.Contains("hhhh"))
                            return true;
                    }
                }
            }


            return false;
        }

        
        public bool check_for_win(GameBoard board)
        {
            if (check_Horizontal_win(board))
                return true;

            if (check_Vertical_win(board))
                return true;

            if (check_Diagnal_win(board))
                return true;

            return false;
        }

        private int total_connect;


    }
}
