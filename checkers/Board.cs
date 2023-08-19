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
        private int[,] _gameboard;
        public int[,] Gameboard
        {
            get=> _gameboard; 
            set => _gameboard = value;
        }
        
        public Board()
        {
            _gameboard = new int[8, 8] {
                { 0,1,0,1,0,1,0,1 },
                { 1,0,1,0,1,0,1,0 },
                { 0,1,0,1,0,1,0,1 },
                { 0,0,0,0,2,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 2,0,2,0,2,0,2,0 },
                { 0,2,0,2,0,2,0,2 },
                { 2,0,2,0,2,0,2,0 }
            };
        }

        public bool movePiece(Point selectedPiece, Point newPosition)
        {
            if(Math.Pow(newPosition.X - selectedPiece.X, 2) > 2) // is capture move
            {
                int tmpPiece = _gameboard[selectedPiece.X, selectedPiece.Y];
                _gameboard[selectedPiece.X, selectedPiece.Y] = 0;
                _gameboard[newPosition.X, newPosition.Y] = tmpPiece;

                CaptureMove(selectedPiece);
                _gameboard[(newPosition.X +selectedPiece.X)/2, (newPosition.Y + selectedPiece.Y)/2] = 0;
                return true;
            }
            else // normal move
            {
                int tmpPiece = _gameboard[selectedPiece.X, selectedPiece.Y];
                _gameboard[selectedPiece.X, selectedPiece.Y] = 0;
                _gameboard[newPosition.X, newPosition.Y] = tmpPiece;
                return false;
            }

        }

        private void CaptureMove(Point actualPosition)
        {
            if (_gameboard[actualPosition.X,actualPosition.Y] == 2)
            {
               // _playerOneScore++;
               // _playerTwoPiece--;
            }
            else
            { 
               // _playerTwoScore++;
               // _playerOnePiece--;
            }
        }

        public Point[] checkPieceMoves(int x, int y)
        {
            Point[] moves = new Point[2];
            if (x >= 0 && y > 0 && x <= 7 && y < 7) // check 2 move on board
            {
                if (_gameboard[x, y] == 2) // check move place for white piece
                {
                    if (x-1 >= 0 && y-1 >= 0)
                    {
                        if (_gameboard[x - 1, y - 1] == 0) // check left place is free
                        {
                            moves[0].X = x - 1;
                            moves[0].Y = y - 1;
                        }

                        else if (_gameboard[x - 1, y - 1] == 1) // check is left place is opponent
                        {
                            if(x - 2 >= 0 && y - 2 >= 0) {
                                if (_gameboard[x - 2, y - 2] == 0 )
                                {
                                    moves[0].X = x - 2;
                                    moves[0].Y = y - 2;
                                }
                            }
                        }

                        if (_gameboard[x - 1, y + 1] == 0) // check is right place is free
                        {
                            moves[1].X = x - 1;
                            moves[1].Y = y + 1;
                        }
                        else if (_gameboard[x - 1, y + 1] == 1) // check is right place is opponent
                        {
                            if(x-2>=0 && y+2<=7)
                            {
                                if (_gameboard[x - 2, y + 2] == 0)
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
                        if (_gameboard[x + 1, y - 1] == 0) // check left place is free
                        {
                            moves[0].X = x + 1;
                            moves[0].Y = y - 1;
                        }
                        else if (_gameboard[x + 1, y - 1] == 2) // check is left place is opponent
                        {
                            if (x+2 <= 7 && y-2 >= 0)
                            {
                                if (_gameboard[x + 2, y - 2] == 0)
                                {
                                    moves[0].X = x + 2;
                                    moves[0].Y = y - 2;
                                }
                            }
                        }
                    
                        if (_gameboard[x + 1, y + 1] == 0) // check right place is free
                        {
                            moves[1].X = x + 1;
                            moves[1].Y = y + 1;
                        }
                        else if (_gameboard[x + 1, y + 1] == 2) // check is left place is opponent
                        {
                            if(x+2 <= 7 && y+2 <= 7)
                            {
                                if (_gameboard[x + 2, y + 2] == 0)
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
                if (_gameboard[x, y] == 2) // check place for white piece
                {
                    if (x-1 >= 0 && y+1 <= 7)
                    {
                        if (_gameboard[x - 1, y + 1] == 0) // check right place is free
                        {
                            moves[0].X = x - 1;
                            moves[0].Y = y + 1;
                        }
                        else if (_gameboard[x - 1, y + 1] == 1) // check is right place is opponent
                        {
                            if (_gameboard[x - 2, y + 2] == 0)
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
                        if (_gameboard[x + 1, y + 1] == 0) // check right place is free
                        {
                            moves[0].X = x + 1;
                            moves[0].Y = y + 1;
                        }
                        else if (_gameboard[x + 1, y + 1] == 2) // check is right place is opponent
                        {
                            if (_gameboard[x + 2, y + 2] == 0)
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
                if (_gameboard[x, y] == 2) // check place for white piece
                {
                    if(x-1 <=0 &&  y-1 <= 0)
                    {
                        if (_gameboard[x - 1, y - 1] == 0) // check left place is free
                        {
                            moves[0].X = x - 1;
                            moves[0].Y = y - 1;
                        }
                        else if (_gameboard[x - 1, y - 1] == 1) // check is left place is opponent
                        {
                            if (_gameboard[x - 2, y - 2] == 0)
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
                        if (_gameboard[x + 1, y - 1] == 0) // check left place is free
                        {
                            moves[0].X = x + 1;
                            moves[0].Y = y - 1;
                        }
                        else if (_gameboard[x + 1, y - 1] == 2) // check is left place is opponent
                        {
                            if (x + 2 <= 7 && y + 2 <= 7)
                            {
                                if (_gameboard[x + 2, y + 2] == 0)
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
