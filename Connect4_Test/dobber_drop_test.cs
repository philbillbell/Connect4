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

            Assert.AreEqual(board.dropDobber(0), true);
        }
    }
}
