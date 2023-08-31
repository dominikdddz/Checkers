using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkers
{
    public class Player
    {
        public string name;
        int pieceColor;
        private int _score;
        public int Score
        {
            get => _score;
            set => _score = value;
        }

        public Player(string name, int pieceColor)
        {
            this.name = name;
            this.pieceColor = pieceColor;
            _score = 0;
        }
    }
}
