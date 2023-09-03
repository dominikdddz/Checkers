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
            Node node = new Node(Board);
            var result = MinMaxAlgorithm(node, Depth, true);
            BestMove = result.Item2;
        }
        private (int, Point[]) MinMaxAlgorithm(Node node, int depth, bool maxPlayer)
        {
            if (depth == 0 || node.board.isWin == true)
            {
                Point[] points = new Point[2];
                points[0] = node.From;
                points[1] = node.To;
                return (EvaluateMove(node.board), points);
            }
            if (maxPlayer == true) // simulation computer turn
            {
                int maxValue = int.MinValue;
                Point[] Best = new Point[2];
                node.board.checkAllMovesForComputer(1);
                foreach (var move in node.board.listMoves)
                {
                    Board boardCopy = (Board)node.board.Clone();
                    boardCopy.makeMove(move[0], move[1]);
                    Node child = new Node(boardCopy, move[0], move[1]);
                    var result = MinMaxAlgorithm(child, depth - 1, false);
                    maxValue = Math.Max(maxValue, result.Item1);
                    if (result.Item1 <= maxValue)
                    {
                        Best[0] = move[0];
                        Best[1] = move[1];
                    }
                    Console.WriteLine("Computer = Depth:" + depth + ", from: [" + move[0].X.ToString() + "," + move[0].Y.ToString() + " -> " + move[1].X.ToString() + "," + move[1].Y.ToString() + "] Value=" + maxValue.ToString());
                    display(boardCopy);
                }
                return (maxValue, Best);
            }
            else // simulation player turn
            {
                int minValue = int.MaxValue;
                Point[] Best = new Point[2];
                node.board.checkAllMovesForComputer(2);
                foreach (var move in node.board.listMoves)
                {
                    Board boardCopy = (Board)node.board.Clone();
                    boardCopy.makeMove(move[0], move[1]);
                    Node child = new Node(boardCopy, move[0], move[1]);
                    var result = MinMaxAlgorithm(child, depth - 1, true);
                    minValue = Math.Min(minValue, result.Item1);
                    if (result.Item1 >= minValue)
                    {
                        Best[0] = move[0];
                        Best[1] = move[1];
                    }
                    Console.WriteLine("Player = Depth:" + depth + ", from: [" + move[0].X.ToString() + "," + move[0].Y.ToString() + " -> " + move[1].X.ToString() + "," + move[1].Y.ToString() + "] Value=" + minValue.ToString());
                    display(boardCopy);
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
    /*
    private List<Point[]> GetAllMoves(Board board,int color)
    {
        List<Point[]> allMoves = new List<Point[]>();
        for(int i=0;i)

        return allMoves;
    }
    
    public (Move, int) MinMax(Board board, int depth, bool isMaximizing)
    {
        //Jeśli osiągnięto maksymalną głębokość lub gra się skończyła, zwróć aktualną ocenę i null jako ruch
        if (depth == 0 || board.IsGameOver())
        {
            return (null, Evaluate(board));
        }

        //Znajdź wszystkie możliwe ruchy dla bieżącego gracza
        List<Move> moves = board.GetAllMoves();

        //Zainicjuj najlepszy ruch i jego wartość
        Move bestMove = null;
        int bestValue = isMaximizing ? int.MinValue : int.MaxValue;

        //Dla każdego możliwego ruchu wykonaj go na kopii planszy i wywołaj rekurencyjnie funkcję minmax
        foreach (Move move in moves)
        {
            Board copy = board.Clone(); //Utwórz kopię planszy
            copy.MakeMove(move); //Wykonaj ruch na kopii
            copy.SwitchPlayer(); //Zmień gracza na kopii

            //Wywołaj rekurencyjnie funkcję minmax na zmniejszonej głębokości i przeciwnym trybie
            (Move, int) result = MinMax(copy, depth - 1, !isMaximizing);

            //Jeśli znaleziono lepszy ruch, zaktualizuj najlepszy ruch i jego wartość
            if (isMaximizing && result.Item2 > bestValue) //Gracz maksymalizujący szuka największej wartości
            {
                bestMove = move;
                bestValue = result.Item2;
            }
            else if (!isMaximizing && result.Item2 < bestValue) //Gracz minimalizujący szuka najmniejszej wartości
            {
                bestMove = move;
                bestValue = result.Item2;
            }
        }

        //Zwróć najlepszy ruch i jego wartość
        return (bestMove, bestValue);
    }
    */
}

