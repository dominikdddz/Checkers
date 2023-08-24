using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkers
{
    internal class Player
    {
        public string name;
        int pieceColor;
        private int _score;
        public int Score
        {
            get => _score;
            set => _score = value;
        }
        int _jumps;
        public int Jumps
        {
            get => _jumps;
            set => _jumps = value;
        }

        public Player(string name, int pieceColor)
        {
            this.name = name;
            this.pieceColor = pieceColor;
            _score = 0;
            _jumps = 0;
        }
    }
}
