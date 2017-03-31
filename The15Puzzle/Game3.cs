using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The15Puzzle
{
        class Game3 : Game2
        {
            private List<int> moves;
            private int lastMoveIndex;
            public Game3(params int[] blocks) : base(blocks)
            {
                moves = new List<int>();
                lastMoveIndex = -1;
            }

            public void Back()
            {
                if (lastMoveIndex != -1)
                {
                    base.Shift(moves[lastMoveIndex--]);
                }
            }

            public void Forward()
            {
                if (moves.Count() - 1 != lastMoveIndex && moves.Count() != 0)
                {
                    base.Shift(moves[++lastMoveIndex]);
                }
            }

            public override void Shift(int value)
            {
                base.Shift(value);
                lastMoveIndex++;
                if (moves.Count() - 1 != lastMoveIndex)
                    moves = moves.Take(lastMoveIndex).ToList();
                moves.Add(value);
            }

        }
    
}
