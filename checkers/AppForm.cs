using Microsoft.VisualBasic.Devices;
using System.Net.NetworkInformation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace checkers
{
    public partial class AppForm : Form
    {
        Board board;
        private PictureBox[,] _places = new PictureBox[8, 8];
        private Point _selectedPieceLocation;
        private List<Point[]> _allMoves;
        Point[] _selectedMoves = new Point[10];
        bool showMoves;
        public AppForm(bool isWhiteTurn, String Player1Name, String Player2Name, bool showMoves)
        {
            InitializeComponent();
            InitializeGameBoard(isWhiteTurn, Player1Name, Player2Name);
            this.showMoves = showMoves;
        }

        private void InitializeGameBoard(bool isWhiteTurn, String Player1Name, String Player2Name) // create and display board with piece
        {
            board = new Board(Player1Name, Player2Name,isWhiteTurn);

            int xLoc = 0, yLoc = 0;
            Color[] colors = new Color[] { Color.White, Color.Gray };
            int white = 0;

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    _places[x, y] = new PictureBox();
                    _places[x, y].Location = new Point(xLoc, yLoc);
                    _places[x, y].BackColor = colors[white % 2];
                    _places[x, y].AccessibleDescription = "" + x.ToString() + "," + y.ToString();
                    _places[x, y].Size = new Size(75, 75);
                    mainBoard.Controls.Add(_places[x, y]);
                    xLoc += 75;
                    white++;
                    setPiece(new Point(x, y));
                }
                white++;
                xLoc = 0;
                yLoc += 75;
            }
            UpdatePlayerUI();
        }

        private void UpdateBoardUI() // update gameboard
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    setPiece(new Point(x, y));
                }
            }
        }

        private void UpdatePlayerUI() // update player text
        {
            int color;
            if (board.isWhiteTurn == true)
            {
                PlayerWhiteTurn.Visible = true;
                Player2Turn.Visible = false;
                color = 2;
            }
            else
            {
                PlayerWhiteTurn.Visible = false;
                Player2Turn.Visible = true;
                color = 1;
            }
            PlayerBlackScoreLabel.Text = board.playerBlack.Score.ToString();
            PlayerWhiteScoreLabel.Text = board.playerWhite.Score.ToString();
            if (board.isWin == true)
            {
                PlayerWin();
            }
            board.checkAllMovesForPlayer(color);
            _allMoves = board.listMoves;
        }

        private void PlayerWin() // show win message 
        {
            mainBoard.Enabled = false;
            string name;
            if (board.playerBlack.Score == 12)
                name = board.playerBlack.name;
            else
                name = board.playerWhite.name;
            PLayerWinText.Text = name + " is win!";
            PLayerWinText.Visible = true;
        }

        private void displayAvailableMovesForSelectedPiece(PictureBox piece, Point[] moves) // display on board available moves for selected piece
        {
            if (_places[moves[0].X, moves[0].Y].BackColor == Color.Gray)
            {
                _places[moves[0].X, moves[0].Y].BackColor = Color.DarkBlue;
                foreach (var move in moves)
                {
                    if (move.IsEmpty) continue;
                    if (move != moves[0])
                    {
                        if (board.isJump == true)
                        {
                            if (Math.Pow(move.X - moves[0].X, 2) > 2)
                            {
                                _places[move.X, move.Y].BackColor = Color.Green;
                            }
                        }
                        else
                        {
                            _places[move.X, move.Y].BackColor = Color.Green;
                        }
                    }
                }
            }
            else
            {
                _places[moves[0].X, moves[0].Y].BackColor = Color.Gray;
                foreach (var move in moves)
                {
                    if (move.IsEmpty) continue;
                    if (move != moves[0])
                        _places[move.X, move.Y].BackColor = Color.Gray;
                }
            }
        }

        private void MouseClickPlace(PictureBox selectedPlace) // function to check which piece was clicked
        {
            selectedPlace.MouseClick += (sender2, e2) => // check first click on board
            {
                PictureBox piece = sender2 as PictureBox;
                int[] placeLocation = piece.AccessibleDescription.Split(',').Select(int.Parse).ToArray();
                if (piece.Image != null)
                {
                    if (board.isJump == false)
                    {
                        RemoveGreenPlaceFromBoard(_selectedMoves);
                        _selectedPieceLocation = new Point(placeLocation[0], placeLocation[1]);
                        foreach (var moves in _allMoves)
                        {
                            if (moves[0] == _selectedPieceLocation)
                            {
                                _selectedMoves = moves;
                                displayAvailableMovesForSelectedPiece(piece, moves);
                            }
                        }
                    }
                    else
                    {
                        displayAvailableMovesForSelectedPiece(piece, board.listMoves[0]);
                    }

                }
            };

            selectedPlace.MouseClick += (sender3, e3) => // check second click on board
            {
                PictureBox piece = sender3 as PictureBox;
                int[] placeLocation = piece.AccessibleDescription.Split(',').Select(int.Parse).ToArray();
                if (selectedPlace.BackColor == Color.Green)
                {
                    Point GreenMove = new Point(placeLocation[0], placeLocation[1]);
                    moveSelectedPiece(_selectedPieceLocation, GreenMove);
                    if (board.isNextJump == false)
                    {
                        board.changePlayerTurn();
                        UpdatePlayerUI();
                    }
                }
            };
        }

        private void setPiece(Point piece) // set piece on board
        {
            if (board.Gameboard[piece.X, piece.Y] == 1) // set black piece
            {
                _places[piece.X, piece.Y].Image = Properties.Resources.blackPiece;
                _places[piece.X, piece.Y].Image.Tag = "black";
            }
            else if (board.Gameboard[piece.X, piece.Y] == 2) // set white piece
            {
                _places[piece.X, piece.Y].Image = Properties.Resources.whitePiece;
                _places[piece.X, piece.Y].Image.Tag = "white";
            }
            else if (board.Gameboard[piece.X, piece.Y] == 3) // set black king piece
            {
                _places[piece.X, piece.Y].Image = Properties.Resources.blackPieceKing;
                _places[piece.X, piece.Y].Image.Tag = "white";
            }
            else if (board.Gameboard[piece.X, piece.Y] == 4) // set white king piece
            {
                _places[piece.X, piece.Y].Image = Properties.Resources.whitePieceKing;
                _places[piece.X, piece.Y].Image.Tag = "white";
            }
            else
            {
                _places[piece.X, piece.Y].Image = null; // clean place (remove piece)
            }
            UpdatePlayerUI();
            _places[piece.X, piece.Y].SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void moveSelectedPiece(Point selectedPiece, Point move) // move selected piece on selected move place
        {
            board.movePiece(selectedPiece, move);
            _places[move.X, move.Y].BackColor = Color.Gray;
            _places[selectedPiece.X, selectedPiece.Y].BackColor = Color.Gray;
            UpdateBoardUI();
            RemoveGreenPlaceFromBoard(_selectedMoves);
        }

        private void RemoveGreenPlaceFromBoard(Point[] moves) // remove available moves from board
        {
            foreach (Point move in moves)
            {
                if (move.IsEmpty) continue;
                _places[move.X, move.Y].BackColor = Color.Gray;
            }
        }

        private void UpdateGameBoard(object sender, EventArgs e) // scanning board to check if was click on place
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (mainBoard.Enabled == true)
                        MouseClickPlace(_places[x, y]);
                    else
                        break;
                }
            }
        }
    }
}