using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace checkers
{
    public class Board
    {
        private int[,] _gameboard;
        public int[,] Gameboard
        {
            get => _gameboard;
            set => _gameboard = value;
        } 
        public bool isWhiteTurn { get; set; }
        public bool isJump { get; set; }
        public bool isNextJump { get; set; }
        public bool isWin{get; private set; }
        public List<Point[]> listMoves = new List<Point[]>();
        public Player playerWhite;
        public Player playerBlack;
        private static int _boardSize = 8;
        enum Pieces
        {
            Black = 1,
            White = 2,
            BlackKing = 3,
            WhiteKing = 4
        }

        public Board(string playerWhiteName, string playerBlackName, bool isWhiteTurn)
        {
            Gameboard = new int[8, 8] { 
                { 0,1,0,1,0,1,0,1 },
                { 1,0,1,0,1,0,1,0 },
                { 0,1,0,1,0,1,0,1 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 2,0,2,0,2,0,2,0 },
                { 0,2,0,2,0,2,0,2 },
                { 2,0,2,0,2,0,2,0 }
            };  // 2 - white | 1 - black | 4 - white king | 3 - blak king
            
            this.isWhiteTurn = isWhiteTurn;
            playerWhite = new Player(playerWhiteName, (int)Pieces.White);
            playerBlack = new Player(playerBlackName, (int)Pieces.Black);
            isJump = false;
        }
        public Board(int[,] gameboard)
        {
            Gameboard = gameboard;
            playerWhite = new Player("Player 1", (int)Pieces.White);
            playerBlack = new Player("Player 2", (int)Pieces.Black);
            isWhiteTurn = true;
            isJump = false;
        }
        public void changePlayerTurn()
        {
            isWhiteTurn ^= true;
            isJump = false;
            isNextJump = false;
        }

        public bool isPLayerWin(Player player)
        {
            if (player.Score == 12)
                return true;
            else
                return false;
        }

        public void checkAllMovesForPlayer(int color)
        {
            int[] playerColors = getPlayerColors(color);
            listMoves.Clear();
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (playerColors.Contains(Gameboard[x, y]))
                    {
                        Point[] availableMoves = checkAvailableMoves(new Point(x, y));
                        if (availableMoves[0].X + availableMoves[0].Y > 0)
                        {
                            Point[] piece = new Point[availableMoves.Length + 1];
                            piece[0] = new Point(x, y);
                            int i = 1;
                            foreach (Point p in availableMoves)
                            {
                                piece[i] = p;
                                i++;
                            }
                            listMoves.Add(piece);
                        }
                    }
                }
            }
        }

        public void checkMovesAfterJump(Point jumpPoint)
        {
            isNextJump = false;

            Point[] moves = checkAvailableMoves(jumpPoint);
            Point[] tmpMoves = new Point[moves.Length + 1];

            tmpMoves[0] = new Point(jumpPoint.X, jumpPoint.Y);
            int i = 1;
            foreach (Point move in moves)
            {
                tmpMoves[i] = move;
                i++;
                if (move.X + move.Y > 0)
                {
                    isNextJump=true;
                }
            }
            if(isNextJump==true) {
                listMoves.Clear();
                listMoves.Add(tmpMoves);
            }
        }

        public void movePiece(Point selectedPiece, Point newPosition)
        {
            if (Math.Pow(newPosition.X - selectedPiece.X, 2) > 2) // jump
            {
                isJump = true;
                Gameboard[newPosition.X, newPosition.Y] = Gameboard[selectedPiece.X, selectedPiece.Y];
                Gameboard[selectedPiece.X, selectedPiece.Y] = 0;
                Gameboard[(newPosition.X + selectedPiece.X) / 2, (newPosition.Y + selectedPiece.Y) / 2] = 0;
                addScorePlayer(selectedPiece);
                //checkMovesAfterJump(newPosition);
            }
            else // move
            {
                Gameboard[newPosition.X, newPosition.Y] = Gameboard[selectedPiece.X, selectedPiece.Y];
                Gameboard[selectedPiece.X, selectedPiece.Y] = 0;
            }
            isChangeToKing(new Point(newPosition.X, newPosition.Y));
        }

        /*
        private bool checkIsCaptureMove(Point[] moves) // check is available jump for player
        {
            foreach (var move in moves)
            {
                if (move.IsEmpty) continue;
                if (Math.Pow(move.X - moves[0].X, 2) > 2)
                {
                    jumpMoves = moves;
                    return true;
                }
            }
            return false;
        }
        */

        private void isChangeToKing(Point actualPosition) // check is piece change to king
        {
            int color = Gameboard[actualPosition.X, actualPosition.Y];
            if(color == 2 && actualPosition.X == 0)
            {
                Gameboard[actualPosition.X, actualPosition.Y] = (int)Pieces.WhiteKing;
            }
            else if(color == 1 && actualPosition.X == _boardSize - 1)
            {
                Gameboard[actualPosition.X, actualPosition.Y] = (int)Pieces.BlackKing;
            }
        }

        private void addScorePlayer(Point actualPosition)
        {
            if (isWhiteTurn == true)
                playerWhite.Score++;
            else
                playerBlack.Score++;
            if (playerWhite.Score == 12 || playerBlack.Score == 12)
                isWin = true;
        }

        private bool checkIsMoveOutOfBounds(int X, int Y)
        {
            bool result = false;
            if (X < 0 || X > _boardSize - 1) // check is out of bounds on up || down side
                result = true;
            if (Y < 0 || Y > _boardSize - 1) // check is out of bounds on left || right side
                result = true;
            return result;
        }

        private bool isKing(Point SelectedPiece)
        {
            if (Gameboard[SelectedPiece.X, SelectedPiece.Y] == (int)Pieces.BlackKing || Gameboard[SelectedPiece.X, SelectedPiece.Y] == (int)Pieces.WhiteKing)
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
