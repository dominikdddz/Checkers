namespace checkers
{
    public partial class AppForm : Form
    {
        Board board;
        private PictureBox[,] _places = new PictureBox[8, 8];
        private Point[] _moves = new Point[2];
        private Point _selectedPiece = new Point();
        bool isStart = false;
        public AppForm()
        {
            InitializeComponent();
            InitializeGameBoard();
            isStart=true;
        }

        private void InitializeGameBoard()
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
                    _places[x, y].AccessibleDescription=""+x.ToString()+","+y.ToString();
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

        private void MouseClickPlace(PictureBox place)
        {
            place.MouseClick += (sender2, e2) =>
            {
                PictureBox placeSelect = sender2 as PictureBox;
                int[] placeCordination = placeSelect.AccessibleDescription.Split(',').Select(int.Parse).ToArray();
                if (placeSelect.Image != null)
                {
                    RemoveDisplayOldMoves();
                    _selectedPiece.X = placeCordination[0];
                    _selectedPiece.Y = placeCordination[1];

                    _moves = board.checkPieceMoves(_selectedPiece.X, _selectedPiece.Y);

                    if (placeSelect.BackColor == Color.Gray)
                    {
                        placeSelect.BackColor = Color.DarkOrange;

                        foreach (var move in _moves)
                        {
                            if (move.IsEmpty) continue;
                            _places[move.X, move.Y].BackColor = Color.Green;
                        }
                    }
                    else
                    {
                        placeSelect.BackColor = Color.Gray;

                        foreach (var move in _moves)
                        {
                            if (move.IsEmpty) continue;
                            _places[move.X, move.Y].BackColor = Color.Gray;
                        }
                    }

                }
            };

            place.MouseClick += (sender3, e3) =>
            {
                PictureBox placeGreenMove = sender3 as PictureBox;
                int[] placeGreenCordination = placeGreenMove.AccessibleDescription.Split(',').Select(int.Parse).ToArray();
                if (place.BackColor == Color.Green)
                {
                    Point GreenMove = new Point(placeGreenCordination[0], placeGreenCordination[1]);
                    moveSelectedPiece(_selectedPiece, GreenMove);
                }
            };

        }

        private void setPiece(Point piece)
        {
            if (board.Gameboard[piece.X, piece.Y] == 1)
            {
                _places[piece.X, piece.Y].Image = Properties.Resources.black;
            }
            else if (board.Gameboard[piece.X, piece.Y] == 2)
            {
                _places[piece.X, piece.Y].Image = Properties.Resources.white;
            }
            _places[piece.X, piece.Y].SizeMode = PictureBoxSizeMode.CenterImage;
            if(isStart==true)
                RemoveDisplayOldMoves();
        }
        private void removePiece(Point piece)
        {
            _places[piece.X, piece.Y].Image = null;
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
            if (_selectedPiece.X + _selectedPiece.Y > 0)
                _places[_selectedPiece.X, _selectedPiece.Y].BackColor = Color.Gray;


        }

        private void UpdateGameBoard(object sender, EventArgs e)
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    MouseClickPlace(_places[x, y]);
                }
            }
        }
    }
}