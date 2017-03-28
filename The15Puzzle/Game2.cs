using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The15Puzzle
{
    class Game2 : Game
    {
public void Mix()
        {
            Random rnd = new Random();

            int[] zero = GetLocation(0);  // координаты 0
            int[] nowValue;               // координаты проходящего значения
            int[] relatedSize;
            List<int> related = new List<int>();
            


            for (int x = 0; x < fieldMatrix.Length * fieldMatrix.Length; x++)
            {

                for (int i = 0; i < fieldMatrix.Length; i++)
                {
                    for (int j = 0; j < fieldMatrix.Length; j++)
                    {
                        nowValue = GetLocation(fieldMatrix[i, j]);

                        if (Math.Abs(nowValue[0] - zero[0]) + Math.Abs(nowValue[1] - zero[1]) == 1)
                        {
                            related.Add(fieldMatrix[nowValue[0], nowValue[1]]);
                        }
                    }
                }
                relatedSize = related.ToArray();
                Shift(related[rnd.Next(relatedSize.Length)]);
                related.Clear();
            }
        }


        public bool IsOver
        {
            get
            {
                for (int i = 0; i < field.Length - 1; i++)
                {
                    if (field[0] == 1)
                        if (field[i] >= field[i - 1]) return false;
                }
                return true;
            }
        }
    }
}
