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
            if (Incorrect(notField))
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

        private static bool Incorrect(int[] mass)
        {
            return Math.Pow((int)Math.Sqrt(mass.Length), 2) != mass.Length || Different(mass);
        }
        // Проверка отсутствия одинаковые числа
        private static bool Different(int[] mass)
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

        public static Game ReadFile(string path)
        {
            List<int> list = new List<int>();
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
                foreach (var item in line.Split(new char[] { ',', ' ' }))
                list.Add(Convert.ToInt32(item));

            if (!Incorrect(list.ToArray()))
            {
                return new Game(list.ToArray());
            }
            else throw new InvalidDataException();
        }

        // Получение двумерного массива
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
        public int this[int x, int y]
        {
            get
            {
                return fieldMatrix[x, y];
            }
            set { }
        }

        // Метод позволяет определить, в какой ячейке находится переданное значение.
        private int[] GetLocation(int value)
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
        private void Shift(int value)
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

        public void Print()
        {
            for (int i = 0; i < (int)Math.Sqrt(fieldMatrix.Length); i++)
            {
                for (int j = 0; j < (int)Math.Sqrt(fieldMatrix.Length); j++)
                    Console.Write(fieldMatrix[i, j] + " ");
                Console.WriteLine();
            }
        }
    }
}
