using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace checkers
{
    internal class Board
    {
        public int[,] gameboard;
        private int _playerOnePiece;
        private int _playerTwoPiece;
        private int _playerOneScore;
        private int _playerTwoScore;
        public Board()
        {
            gameboard = new int[8, 8] {
                { 0,1,0,2,0,1,0,2 },
                { 1,0,1,0,2,0,1,0 },
                { 0,1,0,1,0,1,0,1 },
                { 2,0,2,0,2,0,0,0 },
                { 0,0,0,0,0,0,0,1 },
                { 2,0,2,0,2,0,2,0 },
                { 0,2,0,1,0,2,0,2 },
                { 1,0,2,0,1,0,2,0 }
            };
            _playerOnePiece = 8;
            _playerTwoPiece = 8;
            _playerOneScore = 0;
            _playerTwoScore = 0;
        }
        public void movePiece(Point actualPosition, Point newPosition)
        {
            //isCaptureMove(actualPosition, newPosition);
            int tmpPiece = gameboard[actualPosition.X, actualPosition.Y];
            gameboard[actualPosition.X, actualPosition.Y] = 0;
            gameboard[newPosition.X, newPosition.Y] = tmpPiece;
        }
        private bool isCaptureMove(Point actualPosition, Point newPosition)
        {
            Point place = subtractMove(actualPosition, newPosition);
            if (place.X > 0 && place.Y > 0)
                return true;
            else
                return false;
        }
        private Point subtractMove(Point actualPosition, Point newPosition)
        {
            Point place = new Point();
            place.X = actualPosition.X - newPosition.X;
            place.Y = actualPosition.Y - newPosition.Y;
            return place;
        }
        public Point[] checkPieceMoves(int x, int y)
        {
            Point[] moves = new Point[2];
            if (x >= 0 && y > 0 && x <= 7 && y < 7) // check 2 move on board
            {
                if (gameboard[x, y] == 2) // check move place for white piece
                {
                    if (x-1 >= 0 && y-1 >= 0)
                    {
                        if (gameboard[x - 1, y - 1] == 0) // check left place is free
                        {
                            moves[0].X = x - 1;
                            moves[0].Y = y - 1;
                        }

                        else if (gameboard[x - 1, y - 1] == 1) // check is left place is opponent
                        {
                            if(x - 2 >= 0 && y - 2 >= 0) {
                                if (gameboard[x - 2, y - 2] == 0 )
                                {
                                    moves[0].X = x - 2;
                                    moves[0].Y = y - 2;
                                }
                            }
                        }

                        if (gameboard[x - 1, y + 1] == 0) // check is right place is free
                        {
                            moves[1].X = x - 1;
                            moves[1].Y = y + 1;
                        }
                        else if (gameboard[x - 1, y + 1] == 1) // check is right place is opponent
                        {
                            if(x-2>=0 && y+2<=7)
                            {
                                if (gameboard[x - 2, y + 2] == 0)
                                {
                                    moves[1].X = x - 2;
                                    moves[1].Y = y + 2;
                                }
                            }
                        }
                    }

                }
                else // check place for black piece
                {
                    if (x+1<=7 && y - 1 >= 0)
                    {
                        if (gameboard[x + 1, y - 1] == 0) // check left place is free
                        {
                            moves[0].X = x + 1;
                            moves[0].Y = y - 1;
                        }
                        else if (gameboard[x + 1, y - 1] == 2) // check is left place is opponent
                        {
                            if (x+2 <= 7 && y-2 >= 7)
                            {
                                if (gameboard[x + 2, y - 2] == 0)
                                {
                                    moves[0].X = x + 2;
                                    moves[0].Y = y - 2;
                                }
                            }
                        }
                    
                        if (gameboard[x + 1, y + 1] == 0) // check right place is free
                        {
                            moves[1].X = x + 1;
                            moves[1].Y = y + 1;
                        }
                        else if (gameboard[x + 1, y + 1] == 2) // check is left place is opponent
                        {
                            if(x+2 <= 7 && y+2 <= 7)
                            {
                                if (gameboard[x + 2, y + 2] == 0)
                                {
                                    moves[1].X = x + 2;
                                    moves[1].Y = y + 2;
                                }
                            }
                        }
                    }
                }
            }

            else if (x > 0 && y == 0)  // check 1 move on left corner
            {
                if (gameboard[x, y] == 2) // check place for white piece
                {
                    if (x-1 >= 0 && y+1 <= 7)
                    {
                        if (gameboard[x - 1, y + 1] == 0) // check right place is free
                        {
                            moves[0].X = x - 1;
                            moves[0].Y = y + 1;
                        }
                        else if (gameboard[x - 1, y + 1] == 1) // check is right place is opponent
                        {
                            if (gameboard[x - 2, y + 2] == 0)
                            {
                                moves[0].X = x - 2;
                                moves[0].Y = y + 2;
                            }
                        }
                    }
                }
                else // check place for black piece
                {
                    if (x+1<=7 && y + 1 <= 7)
                    {
                        if (gameboard[x + 1, y + 1] == 0) // check right place is free
                        {
                            moves[0].X = x + 1;
                            moves[0].Y = y + 1;
                        }
                        else if (gameboard[x + 1, y + 1] == 2) // check is right place is opponent
                        {
                            if (gameboard[x + 2, y + 2] == 0)
                            {
                                moves[0].X = x + 2;
                                moves[0].Y = y + 2;
                            }
                        }
                    }
                }
            }

            else if (x >= 0 && y == 7) // check 1 move on right corner
            {
                if (gameboard[x, y] == 2) // check place for white piece
                {
                    if(x-1 <=0 &&  y-1 <= 0)
                    {
                        if (gameboard[x - 1, y - 1] == 0) // check left place is free
                        {
                            moves[0].X = x - 1;
                            moves[0].Y = y - 1;
                        }
                        else if (gameboard[x - 1, y - 1] == 1) // check is left place is opponent
                        {
                            if (gameboard[x - 2, y - 2] == 0)
                            {
                                moves[0].X = x - 2;
                                moves[0].Y = y - 2;
                            }
                        }
                    }

                }
                else // check place for black piece
                {
                    if (x+1 <=7 && y-1 >= 0)
                    {
                        if (gameboard[x + 1, y - 1] == 0) // check left place is free
                        {
                            moves[0].X = x + 1;
                            moves[0].Y = y - 1;
                        }
                        else if (gameboard[x + 1, y - 1] == 2) // check is left place is opponent
                        {
                            if (x + 2 <= 7 && y + 2 <= 7)
                            {
                                if (gameboard[x + 2, y + 2] == 0)
                                {
                                    moves[0].X = x + 2;
                                    moves[0].Y = y - 2;
                                }
                            }

                        }
                    }
                }
            }
            return moves;
        }
    }
}
