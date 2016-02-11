using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Elements
{
    public class GamePlay
    {
        public GamePlay()
        {
            rules = new GameRules();
            gameboard = new GameBoard();
            displayboard = new DisplayBoard();
        }

        private bool human_go()
        {
            string answer = "";
            int pos = -1;
            bool flag = false;

            do
            {
                Console.Write("Please enter the column you would like to drop a dobber in: ");
                answer = Console.ReadLine();
                if (Int32.TryParse(answer, out pos))
                    Console.WriteLine("Error with what you enterd: 1-7 please");
                else
                    flag = true;

                if (!gameboard.dropDobber(pos - 1, "h"))
                {
                    Console.WriteLine("Error with column, please select a new column");
                    flag = false;
                }

            } while (!flag);

            return true;
        }

        public void main_game_play()
        {
            bool continue_game = true;

            while (continue_game)
            {
                human_go();
                rules.check_for_win(gameboard);


                
            }

        }



        GameRules rules = null;
        GameBoard gameboard = null;
        DisplayBoard displayboard = null;
    }
}
