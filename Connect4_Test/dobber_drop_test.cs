using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game_Elements;

namespace Connect4_Test
{
    [TestClass]
    public class dobber_drop_test
    {
        [TestMethod]
        public void play_drops_dobber_into_the_first_row()
        {
            GameBoard board = new GameBoard();
            board.init();

            Assert.AreEqual(board.dropDobber(0, "h"), true);
        }

        [TestMethod]
        public void play_drops_8_dobbers_into_the_first_row()
        {
            GameBoard board = new GameBoard();
            board.init();

            Assert.AreEqual(board.dropDobber(0, "h"), true);
            Assert.AreEqual(board.dropDobber(0, "h"), true);
            Assert.AreEqual(board.dropDobber(0, "h"), true);
            Assert.AreEqual(board.dropDobber(0, "h"), true);
            Assert.AreEqual(board.dropDobber(0, "h"), true);
            Assert.AreEqual(board.dropDobber(0, "h"), true);
            Assert.AreEqual(board.dropDobber(0, "h"), false);
        }

        [TestMethod]
        public void play_drops_4_dobbers_into_the_first_row_and_check_win()
        {
            GameRules rules = new GameRules();
            GameBoard board = new GameBoard();
            board.init();

            Assert.AreEqual(board.dropDobber(0, "h"), true);
            Assert.AreEqual(rules.check_for_win(board), false);
            Assert.AreEqual(board.dropDobber(0, "h"), true);
            Assert.AreEqual(rules.check_for_win(board), false);
            Assert.AreEqual(board.dropDobber(0, "h"), true);
            Assert.AreEqual(rules.check_for_win(board), false);
            Assert.AreEqual(board.dropDobber(0, "h"), true);
            Assert.AreEqual(rules.check_for_win(board), true);
        }
    }
}
