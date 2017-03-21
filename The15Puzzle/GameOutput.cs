using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The15Puzzle
{
    class GameOutput
    {
        public static void Print(Game game)
        {
            var fieldMatrix = game.fieldMatrix;
            for (int i = 0; i < (int)Math.Sqrt(fieldMatrix.Length); i++)
            {
                for (int j = 0; j < (int)Math.Sqrt(fieldMatrix.Length); j++)
                    Console.Write(fieldMatrix[i, j] + "\t ");
                Console.WriteLine();
            }
        }
    }
}
