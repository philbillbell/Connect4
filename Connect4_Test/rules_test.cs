using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game_Rules;

namespace Connect4_Test
{
    [TestClass]
    public class rules_test
    {

        private String[,] board;
        private int rows;
        private int cols;

        [TestMethod]
        public void check_for_horizontal_win()
        {
            rows = 6;
            cols = 7;

            board = new String[rows, cols];

            GameRules rules = new GameRules();
            Assert.AreEqual(rules.check_for_win(board), true);


        }
    }
}
