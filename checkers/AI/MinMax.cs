using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace checkers.AI
{
    public class MinMax
    {
        private Board Board;
        private int Depth;
        public Point[] BestMove;
        public MinMax(Board board, int depth)
        {
            Board = board;
            Depth = depth;
        }
        public void Calculate()
        {
            var result = MinMaxAlgorithm(Board, Depth, true);
            BestMove = result.Item2;
        }
        private (int, Point[]) MinMaxAlgorithm(Board board, int depth, bool maxPlayer)
        {
            if (depth == 0 || board.isWin == true)
            {
                Point[] points = new Point[2];
                return (EvaluateMove(board), points);
            }
            if (maxPlayer == true) // simulation computer turn
            {
                int maxValue = int.MinValue;
                Point[] Best = new Point[2];
                board.checkAllMovesForComputer(1);
                foreach (var move in board.listMoves)
                {
                    Board child = (Board)board.Clone();
                    child.makeMove(move[0], move[1]);
                    var result = MinMaxAlgorithm(child, depth - 1, false);
                    maxValue = Math.Max(maxValue, result.Item1);
                    if (result.Item1 <= maxValue)
                    {
                        Best[0] = move[0];
                        Best[1] = move[1];
                    }
                }
                return (maxValue, Best);
            }
            else // simulation player turn
            {
                int minValue = int.MaxValue;
                Point[] Best = new Point[2];
                board.checkAllMovesForComputer(2);
                foreach (var move in board.listMoves)
                {
                    Board child = (Board)board.Clone();
                    child.makeMove(move[0], move[1]);
                    var result = MinMaxAlgorithm(child, depth - 1, true);
                    minValue = Math.Min(minValue, result.Item1);
                    if (result.Item1 >= minValue)
                    {
                        Best[0] = move[0];
                        Best[1] = move[1];
                    }
                }
                return (minValue, Best);
            }
        }
        public int EvaluateMove(Board board)
        {
            return board.evaluate();
        }
        static void display(Board board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(board.Gameboard[1, j].ToString());
                    Console.Write("|");
                }
                Console.WriteLine();
            }
        }
    }
}

