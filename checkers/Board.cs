using System;
using System.Collections.Generic;
using System.Drawing;
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
            };  // 2 - white | 1 - black | 4 - white king | 3 - blak king

            int white = 2;
            int black = 1;
            PlayerWhite = new Player(PlayerWhiteName, white);
            PlayerBlack = new Player(PlayerBlackName, black);
            isPlayerWhiteTurn = true;
            isCaptureMove = false;
            checkAllMovesForPlayer(white);
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

        public List<Point[]> checkAllMovesForPlayer(int color)
        {
            int[] colors = getPlayerColors(color);
            List<Point[]> list = new List<Point[]>();
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (colors.Contains(Gameboard[x, y]))
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

        public bool movePiece(Point selectedPiece, Point newPosition)
        {
            if (Math.Pow(newPosition.X - selectedPiece.X, 2) > 2) // is capture move
            {
                int tmpPiece = Gameboard[selectedPiece.X, selectedPiece.Y];
                Gameboard[selectedPiece.X, selectedPiece.Y] = 0;
                Gameboard[newPosition.X, newPosition.Y] = tmpPiece;

                CaptureMove(selectedPiece);
                Gameboard[(newPosition.X + selectedPiece.X) / 2, (newPosition.Y + selectedPiece.Y) / 2] = 0;
                checkIsPieceChnageToKing(new Point(newPosition.X, newPosition.Y));
                return true;
            }
            else // normal move
            {
                int tmpPiece = Gameboard[selectedPiece.X, selectedPiece.Y];
                Gameboard[selectedPiece.X, selectedPiece.Y] = 0;
                Gameboard[newPosition.X, newPosition.Y] = tmpPiece;
                checkIsPieceChnageToKing(new Point(newPosition.X, newPosition.Y));
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

        private void checkIsPieceChnageToKing(Point actualPosition) // check is piece change to king
        {
            int color = Gameboard[actualPosition.X, actualPosition.Y];
            if(color == 2 && actualPosition.X == 0)
            {
                Gameboard[actualPosition.X, actualPosition.Y] = 4;
            }
            else if(color == 1 && actualPosition.X == size - 1)
            {
                Gameboard[actualPosition.X, actualPosition.Y] = 3;
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
        private int[] getOpponentColors(int color)      // get opponent color id
        {
            int[] colors = new int[2];
            if (color == 2 || color == 4)
            {
                colors[0] = 1;
                colors[1] = 3;
            }
            else
            {
                colors[0] = 2;
                colors[1] = 4;
            }
            return colors;
        }

        private int[] getPlayerColors(int color)      // get player color id
        {
            int[] colors = new int[2];
            if (color == 2 || color == 4)
            {
                colors[0] = 2;
                colors[1] = 4;
            }
            else
            {
                colors[0] = 1;
                colors[1] = 3;
            }
            return colors;
        }

        private Point[] checkAvailableMoves(Point SelectedPlace)
        {
            bool king = isKing(SelectedPlace);
            int color = Gameboard[SelectedPlace.X, SelectedPlace.Y];        // get piece color id;

            int[] opponent = getOpponentColors(color);

            
            Point[] moves = (king == true) ? new Point[4] : new Point[2]; // if king == 4 then moves = 4 else moves = 2

            if (color == 2 || king == true)     // check move place for white piece or king piece
            {
                if (checkIsMoveOutOfBounds(SelectedPlace.X-1, SelectedPlace.Y - 1) == false)      // check is left-up place is out of bounds board
                {
                    if (Gameboard[SelectedPlace.X - 1, SelectedPlace.Y - 1] == 0)       // check left-up place is free
                        moves = addMove(moves, new Point(SelectedPlace.X - 1, SelectedPlace.Y - 1));
                    else if (opponent.Contains(Gameboard[SelectedPlace.X - 1, SelectedPlace.Y - 1]))       // check is left-up place is opponent
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
                    else if (opponent.Contains(Gameboard[SelectedPlace.X - 1, SelectedPlace.Y + 1]))       // check is right-up place is opponent
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
                    else if (opponent.Contains(Gameboard[SelectedPlace.X + 1, SelectedPlace.Y - 1]))       // check is left-down place is opponent
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
                    else if (opponent.Contains(Gameboard[SelectedPlace.X + 1, SelectedPlace.Y + 1]))      // check is right-down place is opponent
                    {
                        if (checkIsMoveOutOfBounds(SelectedPlace.X + 2, SelectedPlace.Y + 2) == false)      // check is right-down jump is out of bounds board
                        {
                            if(Gameboard[SelectedPlace.X + 2, SelectedPlace.Y + 2] == 0)        // check is right-down place behind opponent is free
                                moves = addMove(moves, new Point(SelectedPlace.X + 2, SelectedPlace.Y + 2));
                        }
                    }
                }
            } 
            return moves;
        }


    }
}
