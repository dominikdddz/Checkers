using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkers.AI
{
    internal class Node
    {
        public Board board;
        public Point From { get; set; }
        public Point To { get; set; }
        public Node(Board board, Point from, Point to)
        {
            this.board = board;
            From = from;
            To = to;
        }
        public Node(Board board) 
        {
            this.board = board;
        }
    }
}
