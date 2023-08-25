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
        bool isStart = false;
        bool isEnd = false;
        bool isCaptureMove = false;
        bool showMoves;
        public AppForm(String boardSize, String firstStart, String Player1Name, String Player2Name, bool showMoves)
        {
            InitializeComponent();
            InitializeGameBoard(boardSize, firstStart, Player1Name, Player2Name);
            this.showMoves = showMoves;
            isStart = true;
        }

        private void InitializeGameBoard(String boardSize, String firstStart, String Player1Name, String Player2Name) // create and display board with piece
        {
            board = new Board(boardSize, Player1Name, Player2Name);

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
            InitializePlayerName(firstStart);
        }

        private void UpdateTurnPlayer() // function to change a player turn
        {
            int colorTurn;
            if (board.isPlayerWhiteTurn == true)
            {
                PlayerWhiteTurn.Visible = true;
                Player2Turn.Visible = false;
                colorTurn = 2;
            }
            else
            {
                PlayerWhiteTurn.Visible = false;
                Player2Turn.Visible = true;
                colorTurn = 1;
            }
            isCaptureMove = false;
            _allMoves = board.checkAllMovesForPlayer(colorTurn);
            if (board.isCaptureMove == true)
                _selectedMoves = board.captureMove;
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
                        if (isCaptureMove == true)
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

        private void InitializePlayerName(string first) // function to change player name from a previous form
        {
            if (first == "Player 1")
            {
                PlayerWhiteNameLabel.Text = board.PlayerWhite.name;
                PlayerBlackNameLabel.Text = board.PlayerBlack.name;
            }
            else
            {
                PlayerWhiteNameLabel.Text = board.PlayerBlack.name;
                PlayerBlackNameLabel.Text = board.PlayerWhite.name;
            }
            UpdateTurnPlayer();
        }


        private void MouseClickPlace(PictureBox selectedPlace) // function to check which piece was click
        {

            selectedPlace.MouseClick += (sender2, e2) => // check first click on board
            {
                PictureBox piece = sender2 as PictureBox;
                int[] placeLocation = piece.AccessibleDescription.Split(',').Select(int.Parse).ToArray();
                if (piece.Image != null)
                {
                    if (isCaptureMove == false)
                    {
                        RemoveDisplayOldMoves(_selectedMoves);
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
                        displayAvailableMovesForSelectedPiece(piece, _selectedMoves);
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
                    board.changePlayerTurn();
                    UpdateTurnPlayer();
                }
            };

        }

        private void setPiece(Point piece) // add piece on board
        {
            if (board.Gameboard[piece.X, piece.Y] == 1)
            {
                _places[piece.X, piece.Y].Image = Properties.Resources.blackPiece;
                _places[piece.X, piece.Y].Image.Tag = "black";
            }
            else if (board.Gameboard[piece.X, piece.Y] == 2)
            {
                _places[piece.X, piece.Y].Image = Properties.Resources.whitePiece;
                _places[piece.X, piece.Y].Image.Tag = "white";
            }
            else if (board.Gameboard[piece.X, piece.Y] == 3)
            {
                _places[piece.X, piece.Y].Image = Properties.Resources.blackPieceKing;
                _places[piece.X, piece.Y].Image.Tag = "white";
            }
            else if (board.Gameboard[piece.X, piece.Y] == 4)
            {
                _places[piece.X, piece.Y].Image = Properties.Resources.whitePieceKing;
                _places[piece.X, piece.Y].Image.Tag = "white";
            }
            _places[piece.X, piece.Y].SizeMode = PictureBoxSizeMode.CenterImage;
            if (isStart == true)
                RemoveDisplayOldMoves(_selectedMoves);
        }
        private void removePiece(Point piece) // remove piece from board
        {
            _places[piece.X, piece.Y].Image = null;
        }

        private void PlayerWin(string name) // show win message 
        {
            mainBoard.Enabled = false;
            isEnd = true;
            PLayerWinText.Text = name + " is win!";
            PLayerWinText.Visible = true;
        }

        private void moveSelectedPiece(Point selectedPiece, Point move) // move selected piece on selected move place
        {
            bool isCaptured = board.movePiece(selectedPiece, move);
            _places[move.X, move.Y].BackColor = Color.Gray;
            _places[selectedPiece.X, selectedPiece.Y].BackColor = Color.Gray;
            setPiece(move);
            if (isCaptured == true)
            {
                Point opponent = move;
                opponent.X = (selectedPiece.X + move.X) / 2;
                opponent.Y = (selectedPiece.Y + move.Y) / 2;
                removePiece(opponent);

                PlayerWhiteScoreLabel.Text = board.PlayerWhite.Score.ToString();
                PlayerBlackScoreLabel.Text = board.PlayerBlack.Score.ToString();
                if (board.PlayerWhite.Score == 12)
                {
                    PlayerWin(board.PlayerWhite.name);
                }
                else if (board.PlayerBlack.Score == 12)
                {
                    PlayerWin(board.PlayerBlack.name);
                }
            }
            removePiece(selectedPiece);
        }

        private void RemoveDisplayOldMoves(Point[] moves) // remove moves from board
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
                    if (isEnd == false)
                        MouseClickPlace(_places[x, y]);
                    else
                        break;
                }
            }
        }
    }
}