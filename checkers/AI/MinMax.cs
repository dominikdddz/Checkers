using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using checkers.Classes;

namespace checkers.AI
{
    public class MinMax
    {
        private Board _board;
        private int _depth;
        public Point[] BestMove;
        public MinMax(Board board, int depth)
        {
            _board = board;
            _depth = depth;
        }
        public void Calculate()
        {
            var result = MinMaxAlgorithm(_board, _depth, true);
            BestMove = result.Item2;
        }
        private (int, Point[]) MinMaxAlgorithm(Board board, int depth, bool maxPlayer)
        {
            if (depth == 0 || board.IsWin == true)
            {
                Point[] points = new Point[2];
                return (EvaluateMove(board), points);
            }
            if (maxPlayer == true) // simulation computer turn
            {
                int maxValue = int.MinValue;
                Point[] Best = new Point[2];
                board.checkAllMoves(1);
                foreach (var move in board.ListMoves)
                {
                    Board child = (Board)board.Clone();
                    child.MakeMove(move[0], move[1]);
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
                board.checkAllMoves(2);
                foreach (var move in board.ListMoves)
                {
                    Board child = (Board)board.Clone();
                    child.MakeMove(move[0], move[1]);
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
        /*
        Evaluation function for MinMax algorithm
        Pawn value = 1
        King value = 2
        Board position value = [1-4]
        Player pawns == 0 => Win
        Computer pawns == 0 => Lose
        */
        public int EvaluateMove(Board board)
        {
            int win = int.MaxValue / 2;
            int lose = int.MinValue / 2;
            int[] opponent = new int[2] { 1, 3 };
            int[,] boardValue = new int[8, 8] {
                { 0,4,0,4,0,4,0,4 },
                { 4,0,3,0,3,0,3,0 },
                { 0,3,0,2,0,2,0,4 },
                { 4,0,2,0,1,0,3,0 },
                { 0,3,0,1,0,2,0,4 },
                { 4,0,2,0,2,0,3,0 },
                { 0,3,0,3,0,3,0,4 },
                { 4,0,4,0,4,0,4,0 }
            };
            int scorePlayer = 0, scoreComputer = 0;
            for(int i = 0; i < 8; i++)
            {
                for (int j = 0;j<8; j++)
                {
                    if (board.Gameboard[i, j] != 0)
                    {
                        if (opponent.Contains(board.Gameboard[i, j]))
                            scoreComputer += boardValue[i, j];
                        else
                            scorePlayer += boardValue[i, j];
                    }
                }
            }
            if (board.PlayerBlack.PawnsLeft == 0)
                return lose;
            if (board.PlayerWhite.PawnsLeft == 0)
                return win;
            int pawns = board.PlayerBlack.PawnsLeft - board.PlayerWhite.PawnsLeft;
            int kings = board.PlayerBlack.KingsLeft * 2 - board.PlayerWhite.KingsLeft * 2;
            int score = scoreComputer - scorePlayer;
            return pawns + kings + score;
        }
    }
}

