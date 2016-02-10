using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game_Elements;

namespace Connect4_Test
{
    [TestClass]
    public class rules_test
    {
        void create_hotizontal_win(ref GameBoard board, int startX, int startY)
        {
            for (int x = startX; x < 4; ++x)
            {
                //board[startY,x] = "h";
                board.insert(x, startY, "h");
            }
        }

        [TestMethod]
        public void check_for_horizontal_win()
        {
            GameRules rules = new GameRules();
            GameBoard board = new GameBoard();
            create_hotizontal_win(ref board, 0, 0);
            Assert.AreEqual(rules.check_for_win(board), true);


        }
    }
}
