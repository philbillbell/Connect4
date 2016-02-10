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
            for (int x = 0; x < 4; ++x)
            {
                board.insert(startX++, startY, "h");
            }
        }

        void create_vertical_win(ref GameBoard board, int startX, int startY)
        {
            for (int x = 0; x < 4; ++x)
            {
                board.insert(startX, startY++, "h");
            }
        }

        [TestMethod]
        public void check_for_all_horizontal_win()
        {
            GameRules rules = new GameRules();
            GameBoard board = new GameBoard();
            board.init();

            for (int y = 0; y < board.rows; ++y)
            {
                for (int x = 0; x < 4; ++x)
                {
                    create_hotizontal_win(ref board, x, y);
                    Assert.AreEqual(rules.check_for_win(board), true);
                    board.init();
                }
            }
        }

        [TestMethod]
        public void check_for_all_vertical_win()
        {
            GameRules rules = new GameRules();
            GameBoard board = new GameBoard();
            board.init();

            for (int x = 0; x < board.columns; ++x)
            {
                for (int y = 0; y < 3; ++y)
                {
                    create_vertical_win(ref board, x, y);
                    bool test = rules.check_for_win(board);
                    Assert.AreEqual(test, true);
                    board.init();
                }
            }
        }
    }
}
