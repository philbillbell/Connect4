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
            players = new List<GamePlayer>();
        }

        public bool game_play()
        {
            bool continue_game_flag = true;
            gameboard.init();

            while (continue_game_flag)
            {
                foreach(GamePlayer player in players)
                {
                    displayboard.show_board(gameboard);
                    player.go(ref gameboard);

                    if (rules.check_for_win(gameboard, player.get_dobber_win()))
                    {
                        displayboard.message = "Player: " + player.dobber() + " Winner Winner Chicken Dinner";
                        displayboard.show_board(gameboard);
                        return true;
                    }
                }
                
                if (gameboard.is_board_full())
                {
                    Console.WriteLine("Draw");
                    return false;
                }
            }
            return false;
        }

        private void create_players()
        {
            GamePlayer player;

            for (int i = 1; i < 3; ++i)
            {
                player = new GamePlayer(i);
                player.pick_player();
                players.Add(player);
            }
        }

        public void main_game_play()
        {
            bool play_again = true;
            string answer = "";

            create_players();

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
        List<GamePlayer> players = null;
    }
}
