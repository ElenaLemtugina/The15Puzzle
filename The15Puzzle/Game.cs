using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace The15Puzzle
{
    class Game
    {
        public readonly int[,] fieldMatrix;
        public readonly int[] field;

        public Game(params int[] notField)
        {
            if (Math.Pow((int)Math.Sqrt(notField.Length), 2) != notField.Length || Different(notField))
                throw new InvalidDataException("A field is set incorrectly");

            fieldMatrix = GetField(notField);
            field = notField;
        }

        private bool Different(int[] mass)
        {
            for (int i = 0; i < mass.Length; i++)
            {
                for (int j = 0; j < mass.Length; j++)
                {
                    if (mass[i] == mass[j] && i!=j) return true;
                }
            }
            return false;
        }

        private int[,] GetField(int[] mass)
        {
            int n = (int)Math.Sqrt(mass.Length);
            int[,] field = new int[n, n];
            for (int i = 0; i < mass.Length; i++)
            {
                field[i / n, i % n] = mass[i];
            }
            return field;
        }

        // Индексатор позволяет определить, какое значение находится в игре по координате [x,y].
        public int Indexer(int x, int y)
        { }

        // Метод позволяет определить, в какой ячейке находится переданное значение.
        public GetLocation(int value)
        { }

        // Метод должен изменять состояние игры, передвигая фишку value на одно из соседних мест, где должен лежать 0. 
        // В случае, если 0 не находится на соседнем месте, должно возникать исключение.
        public void Shift(int value)
        { }

        public void Step(int value)
        {

        }

        private bool AreYouWin()
        {
            for (int i = 0; i < field.Length - 1; i++)
            {
                if (field[i] >= field[i + 1]) return false;
            }
            return true;
        }
    }
}
