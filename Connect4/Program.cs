using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Elements;

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {

            GamePlay gameplay = new GamePlay();
            try {
                gameplay.main_game_play();
            }
            catch
            {
                Console.WriteLine("Game terminated unexpectantly... sorry about that!");
            }

        }
    }
}
