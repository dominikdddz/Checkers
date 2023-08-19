using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkers
{
    internal class Board
    {
        public int[,] gameboard;
        public Board()
        {
            gameboard = new int[8, 8] {
                { 0,1,0,1,0,1,0,1 },
                { 1,0,1,0,1,0,1,0 },
                { 0,1,0,1,0,1,0,1 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 2,0,2,0,2,0,2,0 },
                { 0,2,0,2,0,2,0,2 },
                { 2,0,2,0,2,0,2,0 }
            };
        }
        public void movePiece(Point actualPosition, Point newPosition)
        {
            int tmpPiece = gameboard[actualPosition.X, actualPosition.Y];
            gameboard[actualPosition.X, actualPosition.Y] = 0;
            gameboard[newPosition.X, newPosition.Y] = tmpPiece;
        }
        public Point[] checkPieceMoves(int x, int y)
        {
            Point[] moves = new Point[2];
            if (x >= 0 && y > 0 && x <= 7 && y < 7)
            {
                if (gameboard[x, y] == 2)
                {
                    if (gameboard[x - 1, y + 1] == 0)
                    {
                        moves[0].X = x - 1;
                        moves[0].Y = y + 1;
                    }
                    if (gameboard[x - 1, y - 1] == 0)
                    {
                        moves[1].X = x - 1;
                        moves[1].Y = y - 1;
                    }
                }
                else
                {
                    if (gameboard[x + 1, y - 1] == 0)
                    {
                        moves[0].X = x + 1;
                        moves[0].Y = y - 1;
                    }
                    if (gameboard[x + 1, y + 1] == 0)
                    {
                        moves[1].X = x + 1;
                        moves[1].Y = y + 1;
                    }
                }

            }
            else if (x > 0 && y == 0)
            {
                if (gameboard[x, y] == 2)
                {
                    if (gameboard[x - 1, y + 1] == 0)
                    {
                        moves[0].X = x - 1;
                        moves[0].Y = y + 1;
                    }

                }
                else
                {
                    if (gameboard[x + 1, y + 1] == 0)
                    {
                        moves[0].X = x + 1;
                        moves[0].Y = y + 1;
                    }
                }
            }
            else if (x>=0 && y == 7)
            {
                if (gameboard[x, y] == 2)
                {
                    if (gameboard[x - 1, y - 1] == 0)
                    {
                        moves[0].X = x - 1;
                        moves[0].Y = y - 1;
                    }

                }
                else
                {
                    if (gameboard[x + 1, y - 1] == 0)
                    {
                        moves[0].X = x + 1;
                        moves[0].Y = y - 1;
                    }
                }
            }

            return moves;
        }

    }
}
