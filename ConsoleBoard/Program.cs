using checkers;
using checkers.AI;
using Microsoft.VisualBasic.Devices;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

internal static class Program
{
  
    static void Main()
    {
        Board board = new Board("Player 1", "Player 2", true,false, false);
        int[,] tmpGameboard = new int[8, 8] {
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,1,0,0,0 },
                { 0,0,0,0,0,1,0,0 },
                { 0,0,0,0,2,0,2,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 }
            };
        //var board = new Board(tmpGameboard,2,2);
        display(0 + "" + 0, board);
        MinMax AI = new MinMax(board, 3);
        AI.Calculate();
        Console.WriteLine("["+ AI.BestMove[0].X + "," + AI.BestMove[0].Y + " => [" + AI.BestMove[1].X + "," + AI.BestMove[1].Y + "]");

    }
    static void display(string node, Board board)
    {
        Console.WriteLine("\nCheckers ("+node.ToString()+")");
        for (int i = 0; i < 8;i++)
        {
            for(int j = 0; j < 8; j++)
            {
                Console.Write(board.Gameboard[i, j].ToString());
                Console.Write("|");
            }
            Console.WriteLine();
        }
    }
    static void checkMoves(Board board)
    {
        int j = 0;
        foreach (Point[] move in board.ListMoves)
        {
            Point[] m = new Point[2];
            m[0] = move[0];
            for (int i = 1; i < move.Length; i++)
            {
                if (move[i].X + move[i].Y > 0)
                {
                    m[1] = move[i];
                    Board board1 = (Board)board.Clone();
                    board1.MakeMove(m[0], m[1]);
                    display(j + "" + i, board1);
                }
            }
            j++;
        }
    }
}