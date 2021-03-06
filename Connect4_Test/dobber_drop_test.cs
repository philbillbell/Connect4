﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game_Elements;

namespace Connect4_Test
{
    [TestClass]
    public class dobber_drop_test
    {
        GameRules rules = null;
        GameBoard board = null;

        [TestInitialize]
        public void testInit()
        {
            rules = new GameRules();
            board = new GameBoard();
            board.init();
        }

        [TestMethod]
        public void play_drops_dobber_into_the_first_row()
        {
            GameBoard board = new GameBoard();
            board.init();

            Assert.AreEqual(board.drop_dobber(0, "h"), true);
        }

        [TestMethod]
        public void play_drops_8_dobbers_into_the_first_row()
        {
            Assert.AreEqual(board.drop_dobber(0, "h"), true);
            Assert.AreEqual(board.drop_dobber(0, "h"), true);
            Assert.AreEqual(board.drop_dobber(0, "h"), true);
            Assert.AreEqual(board.drop_dobber(0, "h"), true);
            Assert.AreEqual(board.drop_dobber(0, "h"), true);
            Assert.AreEqual(board.drop_dobber(0, "h"), true);
            Assert.AreEqual(board.drop_dobber(0, "h"), false);
        }

        [TestMethod]
        public void play_drops_4_dobbers_into_the_first_row_and_check_win()
        {
            Assert.AreEqual(board.drop_dobber(0, "h"), true);
            Assert.AreEqual(rules.check_for_win(board, "hhhh"), false);
            Assert.AreEqual(board.drop_dobber(0, "h"), true);
            Assert.AreEqual(rules.check_for_win(board, "hhhh"), false);
            Assert.AreEqual(board.drop_dobber(0, "h"), true);
            Assert.AreEqual(rules.check_for_win(board, "hhhh"), false);
            Assert.AreEqual(board.drop_dobber(0, "h"), true);
            Assert.AreEqual(rules.check_for_win(board, "hhhh"), true);
        }

        [TestMethod]
        public void play_drops_a_dobber_in_pos_outside_maxtrix()
        {
            Assert.AreEqual(board.drop_dobber(22, "h"), false);
        }

        [TestMethod]
        public void check_for_full_board()
        {
            int i = 0;

            for (i = 0; i < 6; i++)
                board.drop_dobber(0, "h");

            Assert.AreEqual(board.is_board_full(), false);

            for (i = 0; i < 6; i++)
                board.drop_dobber(1, "h");

            Assert.AreEqual(board.is_board_full(), false);

            for (i = 0; i < 6; i++)
                board.drop_dobber(2, "h");

            Assert.AreEqual(board.is_board_full(), false);

            for (i = 0; i < 6; i++)
                board.drop_dobber(3, "h");

            Assert.AreEqual(board.is_board_full(), false);

            for (i = 0; i < 6; i++)
                board.drop_dobber(4, "h");

            Assert.AreEqual(board.is_board_full(), false);

            for (i = 0; i < 6; i++)
                board.drop_dobber(5, "h");

            Assert.AreEqual(board.is_board_full(), false);

            for (i = 0; i < 6; i++)
                board.drop_dobber(6, "h");

            Assert.AreEqual(board.is_board_full(), true);
        }
    }
}
