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
        public int score;
        int jumps;
        public Player(string name, int pieceColor, int score, int jumps)
        {
            this.name = name;
            this.pieceColor = pieceColor;
            this.score = score;
            this.jumps = jumps;
        }
        public void increaseScore()
        {
            score++;
        }
        public void increaseJumps()
        {
            jumps++;
        }
    }
}
