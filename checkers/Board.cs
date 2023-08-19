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
        public bool isWhiteTurn;
        public Player Player1; // White piece
        public Player Player2; // Black piece

        public Board()
        {
            _gameboard = new int[8, 8] {
                { 0,1,0,1,0,1,0,1 },
                { 1,0,1,0,1,0,1,0 },
                { 0,1,0,1,0,1,0,1 },
                { 0,0,2,0,0,0,0,0 },
                { 0,0,0,0,0,1,0,0 },
                { 2,0,2,0,2,0,2,0 },
                { 0,2,0,2,0,2,0,2 },
                { 2,0,2,0,2,0,2,0 }
            };
            Player1 = new Player("Player1", 2, 0, 0);
            Player2 = new Player("Player2", 1, 0, 0);
            isWhiteTurn = true;

        }
        public void changePlayerTurn()
        {
            isWhiteTurn ^= true;
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
            if (isWhiteTurn==true)
            {
                Player1.increaseScore();
            }
            else
            {
                Player2.increaseScore();
            }
        }

        public Point[] checkPieceMoves(Point SelectedPlace)
        {
            Point[] moves = new Point[2];
            if (SelectedPlace.X >= 0 && SelectedPlace.Y > 0 && SelectedPlace.X <= 7 && SelectedPlace.Y < 7) // check 2 move on board
            {
                if (_gameboard[SelectedPlace.X, SelectedPlace.Y] == 2) // check move place for white piece
                {
                    if (SelectedPlace.X -1 >= 0 && SelectedPlace.Y - 1 >= 0)
                    {
                        if (_gameboard[SelectedPlace.X - 1, SelectedPlace.Y - 1] == 0) // check left place is free
                        {
                            moves[0].X = SelectedPlace.X - 1;
                            moves[0].Y = SelectedPlace.Y - 1;
                        }

                        else if (_gameboard[SelectedPlace.X - 1, SelectedPlace.Y - 1] == 1) // check is left place is opponent
                        {
                            if(SelectedPlace.X - 2 >= 0 && SelectedPlace.Y - 2 >= 0) {
                                if (_gameboard[SelectedPlace.X - 2, SelectedPlace.Y - 2] == 0 )
                                {
                                    moves[0].X = SelectedPlace.X - 2;
                                    moves[0].Y = SelectedPlace.Y - 2;
                                }
                            }
                        }

                        if (_gameboard[SelectedPlace.X - 1, SelectedPlace.Y + 1] == 0) // check is right place is free
                        {
                            moves[1].X = SelectedPlace.X - 1;
                            moves[1].Y = SelectedPlace.Y + 1;
                        }
                        else if (_gameboard[SelectedPlace.X - 1, SelectedPlace.Y + 1] == 1) // check is right place is opponent
                        {
                            if(SelectedPlace.X -2>=0 && SelectedPlace.Y +2<=7)
                            {
                                if (_gameboard[SelectedPlace.X - 2, SelectedPlace.Y + 2] == 0)
                                {
                                    moves[1].X = SelectedPlace.X - 2;
                                    moves[1].Y = SelectedPlace.Y + 2;
                                }
                            }
                        }
                    }

                }
                else // check place for black piece
                {
                    if (SelectedPlace.X +1<=7 && SelectedPlace.Y - 1 >= 0)
                    {
                        if (_gameboard[SelectedPlace.X + 1, SelectedPlace.Y - 1] == 0) // check left place is free
                        {
                            moves[0].X = SelectedPlace.X + 1;
                            moves[0].Y = SelectedPlace.Y - 1;
                        }
                        else if (_gameboard[SelectedPlace.X + 1, SelectedPlace.Y - 1] == 2) // check is left place is opponent
                        {
                            if (SelectedPlace.X +2 <= 7 && SelectedPlace.Y -2 >= 0)
                            {
                                if (_gameboard[SelectedPlace.X + 2, SelectedPlace.Y - 2] == 0)
                                {
                                    moves[0].X = SelectedPlace.X + 2;
                                    moves[0].Y = SelectedPlace.Y - 2;
                                }
                            }
                        }
                    
                        if (_gameboard[SelectedPlace.X + 1, SelectedPlace.Y + 1] == 0) // check right place is free
                        {
                            moves[1].X = SelectedPlace.X + 1;
                            moves[1].Y = SelectedPlace.Y + 1;
                        }
                        else if (_gameboard[SelectedPlace.X + 1, SelectedPlace.Y + 1] == 2) // check is left place is opponent
                        {
                            if(SelectedPlace.X +2 <= 7 && SelectedPlace.Y +2 <= 7)
                            {
                                if (_gameboard[SelectedPlace.X + 2, SelectedPlace.Y + 2] == 0)
                                {
                                    moves[1].X = SelectedPlace.X + 2;
                                    moves[1].Y = SelectedPlace.Y + 2;
                                }
                            }
                        }
                    }
                }
            }

            else if (SelectedPlace.X > 0 && SelectedPlace.Y == 0)  // check 1 move on left corner
            {
                if (_gameboard[SelectedPlace.X, SelectedPlace.Y] == 2) // check place for white piece
                {
                    if (SelectedPlace.X - 1 >= 0 && SelectedPlace.Y + 1 <= 7)
                    {
                        if (_gameboard[SelectedPlace.X - 1, SelectedPlace.Y + 1] == 0) // check right place is free
                        {
                            moves[0].X = SelectedPlace.X - 1;
                            moves[0].Y = SelectedPlace.Y + 1;
                        }
                        else if (_gameboard[SelectedPlace.X - 1, SelectedPlace.Y + 1] == 1) // check is right place is opponent
                        {
                            if (_gameboard[SelectedPlace.X - 2, SelectedPlace.Y + 2] == 0)
                            {
                                moves[0].X = SelectedPlace.X - 2;
                                moves[0].Y = SelectedPlace.Y + 2;
                            }
                        }
                    }
                }
                else // check place for black piece
                {
                    if (SelectedPlace.X + 1<=7 && SelectedPlace.Y + 1 <= 7)
                    {
                        if (_gameboard[SelectedPlace.X + 1, SelectedPlace.Y + 1] == 0) // check right place is free
                        {
                            moves[0].X = SelectedPlace.X + 1;
                            moves[0].Y = SelectedPlace.Y + 1;
                        }
                        else if (_gameboard[SelectedPlace.X + 1, SelectedPlace.Y + 1] == 2) // check is right place is opponent
                        {
                            if (_gameboard[SelectedPlace.X + 2, SelectedPlace.Y + 2] == 0)
                            {
                                moves[0].X = SelectedPlace.X + 2;
                                moves[0].Y = SelectedPlace.Y + 2;
                            }
                        }
                    }
                }
            }

            else if (SelectedPlace.X >= 0 && SelectedPlace.Y == 7) // check 1 move on right corner
            {
                if (_gameboard[SelectedPlace.X, SelectedPlace.Y] == 2) // check place for white piece
                {
                    if(SelectedPlace.X - 1 >=0 &&  SelectedPlace.Y - 1 >= 0)
                    {
                        if (_gameboard[SelectedPlace.X - 1, SelectedPlace.Y - 1] == 0) // check left place is free
                        {
                            moves[0].X = SelectedPlace.X - 1;
                            moves[0].Y = SelectedPlace.Y - 1;
                        }
                        else if (_gameboard[SelectedPlace.X - 1, SelectedPlace.Y - 1] == 1) // check is left place is opponent
                        {
                            if (_gameboard[SelectedPlace.X - 2, SelectedPlace.Y - 2] == 0)
                            {
                                moves[0].X = SelectedPlace.X - 2;
                                moves[0].Y = SelectedPlace.Y - 2;
                            }
                        }
                    }

                }
                else // check place for black piece
                {
                    if (SelectedPlace.X +1 <=7 && SelectedPlace.Y - 1 >= 0)
                    {
                        if (_gameboard[SelectedPlace.X + 1, SelectedPlace.Y - 1] == 0) // check left place is free
                        {
                            moves[0].X = SelectedPlace.X + 1;
                            moves[0].Y = SelectedPlace.Y - 1;
                        }
                        else if (_gameboard[SelectedPlace.X + 1, SelectedPlace.Y - 1] == 2) // check is left place is opponent
                        {
                            if (SelectedPlace.X + 2 <= 7 && SelectedPlace.Y + 2 <= 7)
                            {
                                if (_gameboard[SelectedPlace.X + 2, SelectedPlace.Y + 2] == 0)
                                {
                                    moves[0].X = SelectedPlace.X + 2;
                                    moves[0].Y = SelectedPlace.Y - 2;
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
