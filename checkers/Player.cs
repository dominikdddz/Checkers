using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkers
{
    public class Player
    {
        public string Name { get; private set; }
        public int Score { get; private set; }
        public int PawnsLeft { get; private set; }
        public int KingsLeft { get; private set; }
        public int[] PlayerColors { get; private set; }
        public Player(string name, int[] playerColors)
        {
            this.Name = name;
            PlayerColors = playerColors;
            Score = 0;
            PawnsLeft = 12;
            KingsLeft = 0;
        }
        public Player(string name, int[] playerColors, int pawnsLeft, int kingsLeft)
        {
            this.Name = name;
            PlayerColors = playerColors;
            Score = 0;
            PawnsLeft = 12;
            KingsLeft = 0;
        }
        public void CapturePawns()
        {
            PawnsLeft -= 1;
        }
        public void AddKing()
        {
            PawnsLeft -= 1;
            KingsLeft += 1;
        }
        public void CaptureKing()
        {
            KingsLeft -= 1;
        }
        public void IncreaseScore()
        {
            Score += 1;
        }
    }
}
