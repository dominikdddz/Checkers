using System.Drawing;
using System.Runtime.CompilerServices;
using checkers;
using Microsoft.VisualBasic.Devices;

namespace tests
{
    public class BoardTest
    {
        [Fact]
        public void Player_Win() // if player has 12 score then win
        {
            var board = new Board("Player 1", "Player 2",true);
            board.playerWhite.Score = 12;
            var player = board.playerWhite;
            var win = board.isPLayerWin(player);

            Assert.True(win);
        }
        [Fact]
        public void First_White_Turn() // defualt first move is white piece
        {
            var board = new Board("Player 1", "Player 2",true);

            var turn = board.isWhiteTurn;

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
            var board = new Board(tmpGameboard);
            board.makeMove(new Point(5, 4), new Point(3, 2));
            Assert.Equal(1, board.playerWhite.Score);
        }
    }
}
