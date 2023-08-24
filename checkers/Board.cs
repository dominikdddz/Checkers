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
            get => _gameboard;
            set => _gameboard = value;
        }
        int size = 8;
        public bool isPlayerWhiteTurn;
        public bool isCaptureMove;
        public Point[] captureMove;
        public Player PlayerWhite;
        public Player PlayerBlack;

        public Board(string boardSize, string PlayerWhiteName, string PlayerBlackName)
        {
            _gameboard = new int[8, 8] {
                { 0,1,0,1,0,1,0,1 },
                { 1,0,1,0,1,0,1,0 },
                { 0,1,0,1,0,1,0,1 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 2,0,2,0,2,0,2,0 },
                { 0,2,0,2,0,2,0,2 },
                { 2,0,2,0,2,0,2,0 }
            };

            int white = 2;
            int black = 1;
            PlayerWhite = new Player(PlayerWhiteName, white);
            PlayerBlack = new Player(PlayerBlackName, black);
            isPlayerWhiteTurn = true;
            isCaptureMove = false;
            checkAllMoves(white);
        }
        public void changePlayerTurn()
        {
            isPlayerWhiteTurn ^= true;
            isCaptureMove = false;
        }

        public bool isPLayerWin(Player player)
        {
            if (player.Score == 12)
            {
                return true;
            }
            else
                return false;
        }

        private bool checkIsCaptureMove(Point[] moves) // check is available capture move for player
        {
            foreach (var move in moves)
            {
                if (move.IsEmpty) continue;
                if (Math.Pow(move.X - moves[0].X, 2) > 2)
                {
                    captureMove = moves;
                    return true;
                }
            }
            return false;
        }

        public bool movePiece(Point selectedPiece, Point newPosition)
        {
            if (Math.Pow(newPosition.X - selectedPiece.X, 2) > 2) // is capture move
            {
                int tmpPiece = _gameboard[selectedPiece.X, selectedPiece.Y];
                _gameboard[selectedPiece.X, selectedPiece.Y] = 0;
                _gameboard[newPosition.X, newPosition.Y] = tmpPiece;

                CaptureMove(selectedPiece);
                _gameboard[(newPosition.X + selectedPiece.X) / 2, (newPosition.Y + selectedPiece.Y) / 2] = 0;
                return true;
            }
            else // normal move
            {
                int tmpPiece = _gameboard[selectedPiece.X, selectedPiece.Y];
                _gameboard[selectedPiece.X, selectedPiece.Y] = 0;
                _gameboard[newPosition.X, newPosition.Y] = tmpPiece;
                if (isPlayerWhiteTurn == true)
                {
                    PlayerWhite.Jumps++;
                }
                else
                {
                    PlayerBlack.Jumps++;
                }
                return false;
            }
        }

        private void CaptureMove(Point actualPosition)
        {
            if (isPlayerWhiteTurn == true)
            {
                PlayerWhite.Score++;
                PlayerWhite.Jumps++;
            }
            else
            {
                PlayerBlack.Score++;
                PlayerBlack.Jumps++;
            }
        }

        public List<Point[]> checkAllMoves(int color)
        {
            List<Point[]> list = new List<Point[]>();
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (Gameboard[x, y] == color)
                    {
                        Point[] moves = checkAvailableMoves(new Point(x, y));
                        if (moves[0].X + moves[0].Y > 0)
                        {
                            Point[] piece = new Point[moves.Length + 1];
                            piece[0] = new Point(x, y);
                            int i = 1;
                            foreach (Point p in moves)
                            {
                                piece[i] = p;
                                i++;
                            }
                            list.Add(piece);
                        }
                    }
                }
            }
            foreach (var moves in list)
            {
                isCaptureMove = checkIsCaptureMove(moves);
                if (isCaptureMove == true)
                    break;
            }
            return list;
        }
        private bool checkIsMoveOutOfBounds(int X, int Y)
        {
            bool result = false;
            if (X < 0 || X > size - 1) // check is out of bounds on up || down side
                result = true;
            if (Y < 0 || Y > size - 1) // check is out of bounds on left || right side
                result = true;
            return result;
        }

        private bool isKing(Point SelectedPiece)
        {
            if (Gameboard[SelectedPiece.X, SelectedPiece.Y] == 3 || Gameboard[SelectedPiece.X, SelectedPiece.Y] == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private Point[] addMove(Point[] moves, Point move)
        {
            Point[] tmp = moves;
            for(int i = 0; i < moves.Length; i++)
            {
                if (moves[i].X + moves[i].Y == 0)
                {
                    moves[i] = move;
                    break;
                }
            }
            return moves;
        }

        public Point[] checkAvailableMoves(Point SelectedPlace)
        {
            int color = Gameboard[SelectedPlace.X, SelectedPlace.Y]; // get piece color id;
            int opponent;
            if(color == 2)
            {
                opponent = 1;
            }
            else
            {
                opponent = 2;
            }
            bool king = isKing(SelectedPlace);
            Point[] moves;
            if (king == true) // king has 4 available moves | normnal pice only 2 moves at once
            {
                moves = new Point[4];
            }
            else
            {
                moves = new Point[2];
            }

            if (color == 2 || king == true)     // check move place for white piece or king piece
            {
                if (checkIsMoveOutOfBounds(SelectedPlace.X, SelectedPlace.Y - 1) == false)      // check is left-up place is out of bounds board
                {
                    if (Gameboard[SelectedPlace.X - 1, SelectedPlace.Y - 1] == 0)       // check left-up place is free
                        moves = addMove(moves, new Point(SelectedPlace.X - 1, SelectedPlace.Y - 1));
                    else if (Gameboard[SelectedPlace.X - 1, SelectedPlace.Y - 1] == opponent)       // check is left-up place is opponent
                    {
                        if (checkIsMoveOutOfBounds(SelectedPlace.X - 2, SelectedPlace.Y - 2) == false)      // check is left-up jump is out of bounds board
                        {
                            if (Gameboard[SelectedPlace.X - 2, SelectedPlace.Y - 2] == 0)       //check is left-up place behind opponent is free
                                moves = addMove(moves, new Point(SelectedPlace.X - 2, SelectedPlace.Y - 2));
                        }
                    }
                }
                if (checkIsMoveOutOfBounds(SelectedPlace.X-1, SelectedPlace.Y + 1) == false)        // check is right-up place is out of bounds board
                {
                    if (Gameboard[SelectedPlace.X - 1, SelectedPlace.Y + 1] == 0)       // check is right-up place is free
                        moves = addMove(moves, new Point(SelectedPlace.X - 1, SelectedPlace.Y + 1));
                    else if (Gameboard[SelectedPlace.X - 1, SelectedPlace.Y + 1] == opponent)       // check is right-up place is opponent
                    {
                        if (checkIsMoveOutOfBounds(SelectedPlace.X - 2, SelectedPlace.Y + 2) == false)      // check is right-up jump is out of bounds board
                        {
                            if (Gameboard[SelectedPlace.X - 2, SelectedPlace.Y + 2] == 0)       // check is right-up place behind opponent is free
                                moves = addMove(moves, new Point(SelectedPlace.X - 2, SelectedPlace.Y + 2));
                        }
                    }
                }
            }
            if (color == 1 || king == true)     // check place for black piece or king
            {
                if (checkIsMoveOutOfBounds(SelectedPlace.X + 1, SelectedPlace.Y - 1) == false)      // check is left-down place is out of bounds board
                {
                    if (Gameboard[SelectedPlace.X + 1, SelectedPlace.Y - 1] == 0)       // check left-down place is free
                        moves = addMove(moves, new Point(SelectedPlace.X + 1, SelectedPlace.Y - 1));
                    else if (Gameboard[SelectedPlace.X + 1, SelectedPlace.Y - 1] == opponent)       // check is left-down place is opponent
                    {
                        if (checkIsMoveOutOfBounds(SelectedPlace.X + 2, SelectedPlace.Y - 2) == false)      // check is left-down jump is out of bounds board
                        {
                            if (Gameboard[SelectedPlace.X + 2, SelectedPlace.Y - 2] == 0)       // check is left-down place behind opponent is free
                                moves = addMove(moves, new Point(SelectedPlace.X + 2, SelectedPlace.Y - 2));
                        }
                    }
                }
                if(checkIsMoveOutOfBounds(SelectedPlace.X + 1, SelectedPlace.Y + 1) == false)       // check is right-down place is out of bounds board
                {
                    if (Gameboard[SelectedPlace.X + 1, SelectedPlace.Y + 1] == 0)       // check right-down place is free
                        moves = addMove(moves, new Point(SelectedPlace.X + 1, SelectedPlace.Y + 1));
                    else if (Gameboard[SelectedPlace.X + 1, SelectedPlace.Y + 1] == 2)      // check is right-down place is opponent
                    {
                        if (checkIsMoveOutOfBounds(SelectedPlace.X + 2, SelectedPlace.Y + 2) == false)      // check is right-down jump is out of bounds board
                        {
                            if(Gameboard[SelectedPlace.X + 2, SelectedPlace.Y + 2] == 0)        // check is right-down place behind opponent is free
                                moves = addMove(moves, new Point(SelectedPlace.X + 2, SelectedPlace.Y + 2));
                        }
                    }
                }
            }
            /*
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
                    if (SelectedPlace.X + 1 <= 7 && SelectedPlace.Y + 1 <= 7)
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
                    if (SelectedPlace.X - 1 >= 0 && SelectedPlace.Y - 1 >= 0)
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
                    if (SelectedPlace.X + 1 <= 7 && SelectedPlace.Y - 1 >= 0)
                    {
                        if (_gameboard[SelectedPlace.X + 1, SelectedPlace.Y - 1] == 0) // check left place is free
                        {
                            moves[0].X = SelectedPlace.X + 1;
                            moves[0].Y = SelectedPlace.Y - 1;
                        }
                        else if (_gameboard[SelectedPlace.X + 1, SelectedPlace.Y - 1] == 2) // check is left place is opponent
                        {
                            if (SelectedPlace.X + 2 <= 7 && SelectedPlace.Y - 2 >= 0)
                            {
                                if (_gameboard[SelectedPlace.X + 2, SelectedPlace.Y - 2] == 0)
                                {
                                    moves[0].X = SelectedPlace.X + 2;
                                    moves[0].Y = SelectedPlace.Y - 2;
                                }
                            }

                        }
                    }
                }
            }
            */
            return moves;
        }


    }
}
