namespace checkers
{
    public partial class AppForm : Form
    {
        Board board;
        private PictureBox[,] _places = new PictureBox[8, 8];
        private Point[] _moves = new Point[2];
        private Point _selectedPieceLocation;
        bool isStart = false;
        bool isEnd = false;
        public AppForm()
        {
            InitializeComponent();
            InitializeGameBoard();
            isStart = true;
            Player1Turn.Visible = true;
        }

        private void InitializeGameBoard() // create and display board with piece
        {
            int xLoc = 0, yLoc = 0;
            board = new Board();
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
        }

        private void displayAvailableMoves(PictureBox selectedPiece) // display on board available moves for selected piece
        {
            _moves = board.checkPieceMoves(_selectedPieceLocation);

            if (selectedPiece.BackColor == Color.Gray)
            {
                selectedPiece.BackColor = Color.DarkOrange;

                foreach (var move in _moves)
                {
                    if (move.IsEmpty) continue;
                    _places[move.X, move.Y].BackColor = Color.Green;
                }
            }
            else
            {
                selectedPiece.BackColor = Color.Gray;

                foreach (var move in _moves)
                {
                    if (move.IsEmpty) continue;
                    _places[move.X, move.Y].BackColor = Color.Gray;
                }
            }
        }

        private void UpdateTurnPlayer()
        {
            board.changePlayerTurn();
            if (board.isWhiteTurn == true)
            {
                Player1Turn.Visible = true;
                Player2Turn.Visible = false;
            }
            else
            {
                Player1Turn.Visible = false;
                Player2Turn.Visible = true;
            }
        }

        private void MouseClickPlace(PictureBox selectedPlace)
        {
            selectedPlace.MouseClick += (sender2, e2) =>
            {
                PictureBox piece = sender2 as PictureBox;
                int[] placeLocation = piece.AccessibleDescription.Split(',').Select(int.Parse).ToArray();
                if (piece.Image != null)
                {
                    RemoveDisplayOldMoves();
                    if (board.isWhiteTurn == true && piece.Image.Tag == "white")
                    {
                        _selectedPieceLocation = new Point(placeLocation[0], placeLocation[1]);
                        displayAvailableMoves(piece);
                    }
                    else if (board.isWhiteTurn == false && piece.Image.Tag == "black")
                    {
                        _selectedPieceLocation = new Point(placeLocation[0], placeLocation[1]);
                        displayAvailableMoves(piece);
                    }
                }
            };

            selectedPlace.MouseClick += (sender3, e3) =>
            {
                PictureBox piece = sender3 as PictureBox;
                int[] placeLocation = piece.AccessibleDescription.Split(',').Select(int.Parse).ToArray();
                if (selectedPlace.BackColor == Color.Green)
                {
                    Point GreenMove = new Point(placeLocation[0], placeLocation[1]);
                    moveSelectedPiece(_selectedPieceLocation, GreenMove);
                    UpdateTurnPlayer();
                }
            };
        }

        private void setPiece(Point piece) // add piece on board
        {
            if (board.Gameboard[piece.X, piece.Y] == 1)
            {
                _places[piece.X, piece.Y].Image = Properties.Resources.black;
                _places[piece.X, piece.Y].Image.Tag = "black";
            }
            else if (board.Gameboard[piece.X, piece.Y] == 2)
            {
                _places[piece.X, piece.Y].Image = Properties.Resources.white;
                _places[piece.X, piece.Y].Image.Tag = "white";
            }
            _places[piece.X, piece.Y].SizeMode = PictureBoxSizeMode.CenterImage;
            if (isStart == true)
                RemoveDisplayOldMoves();
        }
        private void removePiece(Point piece)
        {
            _places[piece.X, piece.Y].Image = null;
        }

        private void PlayerWin(string name)
        {
            mainBoard.Enabled = false;
            isEnd = true;
            PLayerWinText.Text = name + "is win!";
            PLayerWinText.Visible = true;

        }

        private void moveSelectedPiece(Point selectedPiece, Point move)
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

                Player1ScoreLabel.Text = board.Player1.score.ToString();
                Player2ScoreLabel.Text = board.Player2.score.ToString();
                if(board.Player1.score == 12)
                {
                    PlayerWin(board.Player1.name);
                }
                else if (board.Player2.score == 12)
                {
                    PlayerWin(board.Player2.name);
                }
            }
            removePiece(selectedPiece);
        }

        private void RemoveDisplayOldMoves()
        {
            for (int i = 0; i < _moves.Length; i++)
            {
                if (_moves[i].IsEmpty) continue;
                _places[_moves[i].X, _moves[i].Y].BackColor = Color.Gray;
                _moves[0].X = 0;
                _moves[0].Y = 0;
            }
            if (_selectedPieceLocation.X + _selectedPieceLocation.Y > 0)
                _places[_selectedPieceLocation.X, _selectedPieceLocation.Y].BackColor = Color.Gray;
        }

        private void UpdateGameBoard(object sender, EventArgs e)
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