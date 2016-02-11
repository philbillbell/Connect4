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
                displayboard.show_board(gameboard);
                Console.Write("Please enter the column you would like to drop a dobber in: ");
                answer = Console.ReadLine();
                if (!Int32.TryParse(answer, out pos))
                    displayboard.message = "Error with what you enterd: 1-7 please";
                else
                    flag = true;

                if (!gameboard.dropDobber(pos - 1, "h"))
                {
                    displayboard.message = "Error with column, please select a new column";
                    flag = false;
                }

            } while (!flag);

            return true;
        }

        private void computer_go()
        {
            bool find_position = true;
            Random r = new Random(DateTime.Now.Millisecond);
            int computer_position = 0;

            while (find_position)
            {
                computer_position = r.Next(7);
                if (gameboard.dropDobber(computer_position, "c"))
                    find_position = false;
            }
        }



        public bool game_play()
        {
            bool continue_game = true;
            gameboard.init();

            while (continue_game)
            {
                human_go();
                if (rules.check_for_win(gameboard))
                {
                    displayboard.message = "Winner Winner Chicken Dinner";
                    displayboard.show_board(gameboard);
                    return true;
                }
                else
                {
                    computer_go();
                    if (rules.check_for_win(gameboard))
                    {
                        displayboard.message = "Winner Winner Chicken Dinner... but not for you!";
                        displayboard.show_board(gameboard);
                        return false;
                    }
                }

                if(gameboard.isBoardFull())
                {
                    Console.WriteLine("Draw");
                    return false;
                }

            }
            return false;
        }

        public void main_game_play()
        {
            bool play_again = true;
            string answer = "";

            while (play_again)
            {
                game_play();
                Console.Write("Would you like to play again? (Y/N): ");
                answer = Console.ReadLine();
                play_again = (answer.ToUpper() == "Y") ? true : false;
            }
        }

        GameRules rules = null;
        GameBoard gameboard = null;
        DisplayBoard displayboard = null;
    }
}
