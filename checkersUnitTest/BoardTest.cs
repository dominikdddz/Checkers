using System.Drawing;
using System.Runtime.CompilerServices;
using checkers;
using Microsoft.VisualBasic.Devices;

namespace checkersUnitTest
{
    public class BoardTest
    {
        [Fact]
        public void Player_Win() // if player has 12 score then win
        {
            var board = new Board("8x8", "Player 1", "Player 2");
            board.PlayerWhite.Score = 12;
            var player = board.PlayerWhite;
            var win = board.isPLayerWin(player);

            Assert.True(win);
        }
        [Fact]
        public void First_White_Turn() // defualt first move is white piece
        {
            var board = new Board("8x8", "Player 1", "Player 2");

            var turn = board.isPlayerWhiteTurn;

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
            var moves = board.movePiece(new Point(5, 4), new Point(3, 2));
            Assert.Equal(1, board.PlayerWhite.Score);
        }
    }
}
