namespace checkers
{
    public partial class Form1 : Form
    {
        Board board;
        private PictureBox[,] _places = new PictureBox[8, 8];
        private Point[] _moves = new Point[2];
        private Point _selectedPiece = new Point();
        public Form1()
        {
            InitializeComponent();
            InitializeGameBoard();

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
                    _places[x, y].Size = new Size(75, 75);
                    mainBoard.Controls.Add(_places[x, y]);
                    xLoc += 75;
                    white++;
                    setPiece(x, y);
                }
                white++;
                xLoc = 0;
                yLoc += 75;
            }
        }

        private void MouseClickPlace(PictureBox place, int x, int y)
        {
            place.MouseClick += (sender2, e2) =>
            {
                PictureBox place = sender2 as PictureBox;
                if (place.Image != null)
                {
                    RemoveDisplayOldMoves();
                    _selectedPiece.X = x;
                    _selectedPiece.Y = y;
                    _moves = board.checkPieceMoves(x, y);

                    if (place.BackColor == Color.Gray)
                    {
                        place.BackColor = Color.DarkOrange;

                        foreach (var move in _moves)
                        {
                            if (move.IsEmpty) continue;
                            _places[move.X, move.Y].BackColor = Color.Green;
                        }
                    }
                    else
                    {
                        place.BackColor = Color.Gray;

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
                PictureBox place = sender3 as PictureBox;
                if (place.BackColor == Color.Green)
                {
                    moveSelectedPiece(_selectedPiece, _moves[0]);
                }
            };
            
        }

        private void setPiece(int x, int y)
        {
            if (board.gameboard[x, y] == 1)
            {
                _places[x, y].Image = Properties.Resources.black;
            }
            else if (board.gameboard[x, y] == 2)
            {
                _places[x, y].Image = Properties.Resources.white;
            }
            _places[x, y].SizeMode = PictureBoxSizeMode.CenterImage;
            RemoveDisplayOldMoves();
        }
        private void removePiece(int x, int y)
        {
            _places[x, y].Image = null;
        }

        private void moveSelectedPiece(Point selectedPiece, Point move)
        {
            board.movePiece(selectedPiece, move);
            _places[move.X, move.Y].BackColor = Color.Gray;
            _places[selectedPiece.X, selectedPiece.Y].BackColor = Color.Gray;
            setPiece(move.X, move.Y);
            removePiece(selectedPiece.X, selectedPiece.Y);

        }

        private void RemoveDisplayOldMoves()
        {
            for (int i=0; i< _moves.Length; i++)
            {
                if (_moves[i].IsEmpty) continue;
                _places[_moves[i].X, _moves[i].Y].BackColor = Color.Gray;
                _moves[0].X = 0;
                _moves[0].Y = 0;
            }
            if (_selectedPiece.X + _selectedPiece.Y>0)
                _places[_selectedPiece.X,_selectedPiece.Y].BackColor = Color.Gray;


        }

        private void UpdateGameBoard(object sender, EventArgs e)
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    MouseClickPlace(_places[x, y],x,y);
                }
            }
        }
    }
}