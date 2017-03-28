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
            if (IncorrectInput(notField))
            {
                field = null;
                fieldMatrix = null;
            }
            else
            {
                fieldMatrix = GetField(notField);
                field = notField;
            }
        }

        public static bool IncorrectInput(int[] mass)
        {
            return Math.Pow((int)Math.Sqrt(mass.Length), 2) != mass.Length ||                          // количество
                mass.Intersect(Enumerable.Range(0, mass.Length - 1)).Count() != mass.Length;           // эелементы в порядке возрастания
        }


        // Получение двумерного массива
        protected int[,] GetField(int[] mass)
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
        public int this[int x, int y]
        {
            get
            {
                return fieldMatrix[x, y];
            }
            set { }
        }

        // Метод позволяет определить, в какой ячейке находится переданное значение.
        protected int[] GetLocation(int value)
        {
            for (int i = 0; i < fieldMatrix.Length; i++)
            {
                for (int j = 0; j < fieldMatrix.Length; j++)
                {
                    if (fieldMatrix[i, j] == value)
                        return new[] { i, j };

                }
            }
            return null;
        }

        // Метод должен изменять состояние игры, передвигая фишку value на одно из соседних мест, где должен лежать 0. 
        // В случае, если 0 не находится на соседнем месте, должно возникать исключение.
        protected void Shift(int value)
        {
            int[] zero = GetLocation(0);
            int[] nowValue = GetLocation(value);

            if(Math.Abs(nowValue[0] - zero[0]) + Math.Abs(nowValue[1] - zero[1]) == 1)
            {
                fieldMatrix[zero[0], zero[1]] = value;
                fieldMatrix[nowValue[0], nowValue[1]] = 0;
            }
            else throw new ArgumentException();
        }


    }
}
