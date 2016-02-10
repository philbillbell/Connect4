using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game_Rules;

namespace Connect4_Test
{
    [TestClass]
    public class rules_test
    {
        void create_hotizontal_win(ref String[,] board, int startX, int startY)
        {
            for (int x = startX; x < 4; ++x)
            {
                board[startY,x] = "h";
            }
        }

        [TestMethod]
        public void check_for_horizontal_win()
        {
            int rows= 6;
            int cols = 7;
            String[,] board = new String[rows, cols];
            create_hotizontal_win(ref board, 0, 0);
            GameRules rules = new GameRules();
            Assert.AreEqual(rules.check_for_win(board), true);


        }
    }
}
