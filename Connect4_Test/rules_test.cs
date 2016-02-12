using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game_Elements;

namespace Connect4_Test
{
    [TestClass]
    public class rules_test
    {
        GameRules rules = null;
        GameBoard board = null;

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

        void create_diagnal_win(ref GameBoard board, int size, int startX, int startY, Func<int, int> Xdel, Func<int, int> Ydel)
        {
            for (int x = 0; x < size; ++x)
            {
                board.insert(startX, startY, "h");
                startX = Xdel(startX);
                startY = Ydel(startY);
            }
        }

        [TestInitialize]
        public void testInit()
        {
            rules = new GameRules();
            board = new GameBoard();
            board.init();
        }

        [TestMethod]
        public void check_for_all_horizontal_win()
        {
            for (int y = 0; y < board.rows; ++y)
            {
                for (int x = 0; x < 4; ++x)
                {
                    create_hotizontal_win(ref board, x, y);
                    Assert.AreEqual(rules.check_for_win(board, "hhhh"), true);
                    board.init();
                }
            }
        }

        [TestMethod]
        public void check_for_all_vertical_win()
        {
            for (int x = 0; x < board.columns; ++x)
            {
                for (int y = 0; y < 3; ++y)
                {
                    create_vertical_win(ref board, x, y);
                    Assert.AreEqual(rules.check_for_win(board, "hhhh"), true);
                    board.init();
                }
            }
        }

        [TestMethod]
        public void check_for_all_diagnal_win_south_east()
        { 
            create_diagnal_win(ref board, 4, 0, 0, (Coord) => { return ++Coord; }, (Coord) => { return ++Coord; });
            //create_diagnal_win(ref board, 0, 5);
            Assert.AreEqual(rules.check_for_win(board, "hhhh"), true);
        }

        [TestMethod]
        public void check_for_all_diagnal_win_north_east()
        {
            create_diagnal_win(ref board, 4, 0, 5, (Coord) => { return ++Coord; }, (Coord) => { return --Coord; });
            Assert.AreEqual(rules.check_for_win(board, "hhhh"), true);
        }

        [TestMethod]
        public void check_for_all_diagnal_win_south_west()
        {
            create_diagnal_win(ref board, 4, 6, 0, (Coord) => { return --Coord; }, (Coord) => { return ++Coord; });
            Assert.AreEqual(rules.check_for_win(board, "hhhh"), true);
        }

        [TestMethod]
        public void check_for_all_diagnal_win_north_west()
        {
            create_diagnal_win(ref board, 4, 6, 5, (Coord) => { return --Coord; }, (Coord) => { return --Coord; });
            Assert.AreEqual(rules.check_for_win(board, "hhhh"), true);
        }

        [TestMethod]
        public void check_for_all_diagnal_win_north_east_but_with_5()
        {
            create_diagnal_win(ref board, 5, 0, 5, (Coord) => { return ++Coord; }, (Coord) => { return --Coord; });
            Assert.AreEqual(rules.check_for_win(board, "hhhhh"), true);
        }
    }
}
