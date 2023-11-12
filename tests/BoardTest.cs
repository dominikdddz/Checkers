using System.Drawing;
using System.Runtime.CompilerServices;
using checkers;
using checkers.Classes;
using Microsoft.VisualBasic.Devices;

namespace tests
{
    public class BoardTest
    {
        [Fact]
        public void Player_Win() // if player has 12 score then win
        {
            Board board = new Board(true);
            for (int i = 0; i < 12; i++)
                board.PlayerWhite.IncreaseScore();
            var player = board.PlayerWhite;
            var win = board.isPLayerWin(player);

            Assert.True(win);
        }
        [Fact]
        public void First_White_Turn() // defualt first move is white piece
        {
            Board board = new Board(true);

            var turn = board.IsWhiteTurn;

            Assert.True(turn);
        }
        [Fact]
        public void Add_Score() // check score after capture jump
        {
            int[,] tmpGameboard = new int[8, 8] {
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,1,0,1,0,0 },
                { 0,0,0,0,2,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 }
            };
            Board board = new Board(tmpGameboard,1,2,0,0);
            board.MakeMove(new Point(5, 4), new Point(3, 2));
            Assert.Equal(1, board.PlayerWhite.Score);
        }
    }
}
