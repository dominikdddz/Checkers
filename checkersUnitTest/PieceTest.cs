using checkers;
using System.Drawing;

namespace checkersUnitTest
{
    public class PieceTest
    {
        [Fact]
        public void White_Piece_Moves_Center() // In center, piece has 2 moves
        {
            int[,] tmpGameboard = new int[8, 8] {
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,2,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 }
            };
            Point[] centerPiece = { new Point(5, 4), new Point(4, 3), new Point(4, 5) }; // Center Piece move

            List<Point[]> ListMoves = new List<Point[]>();
            ListMoves.Add(centerPiece);

            var board = new Board(tmpGameboard);
            var moves = board.checkAllMovesForPlayer(2);

            Assert.Equal(ListMoves, moves);
        }
        [Fact]
        public void White_Piece_Moves_Left() // In left, piece has 1 move
        {
            int[,] tmpGameboard = new int[8, 8] {
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 2,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 }
            };
            Point[] LeftPiece = { new Point(5, 0), new Point(4, 1), new Point(0, 0) }; // Left Piece move

            List<Point[]> ListMoves = new List<Point[]>();
            ListMoves.Add(LeftPiece);

            var board = new Board(tmpGameboard);
            var moves = board.checkAllMovesForPlayer(2);

            Assert.Equal(ListMoves, moves);
        }
        [Fact]
        public void White_Piece_Moves_Right() // In right, piece has 1 move
        {
            int[,] tmpGameboard = new int[8, 8] {
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,2 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 }
            };
            Point[] rightPiece = { new Point(4, 7), new Point(3, 6), new Point(0, 0) }; // Right Piece move

            List<Point[]> ListMoves = new List<Point[]>();
            ListMoves.Add(rightPiece);

            var board = new Board(tmpGameboard);
            var moves = board.checkAllMovesForPlayer(2);

            Assert.Equal(ListMoves, moves);
        }
        [Fact]
        public void White_Piece_Convert_To_King() // check is piece convert to king after move to up board line
        {
            int[,] tmpGameboard = new int[8, 8] {
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,2,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 }
            };

            var board = new Board(tmpGameboard);
            var moves = board.movePiece(new Point(1, 6), new Point(0, 5));

            Assert.Equal(4, board.Gameboard[0, 5]);
        }
        [Fact]
        public void Piece_Jump() // White piece has 2 jump
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
            Point[] centerPiece = { new Point(5, 4), new Point(3, 2), new Point(3, 6) };

            List<Point[]> ListMoves = new List<Point[]>();
            ListMoves.Add(centerPiece);

            var board = new Board(tmpGameboard);
            var moves = board.checkAllMovesForPlayer(2);

            Assert.Equal(ListMoves, moves);
        }
        [Fact]
        public void Piece_Capture() // White piece capture jump
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

            Assert.Equal(0, board.Gameboard[4,3]);
        }
    }
}