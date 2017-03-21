using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The15Puzzle
{
    class GameFromFile
    {
        public static Game Read(string path)
        {
            List<int> list = new List<int>();
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
                foreach (var item in line.Split(new char[] { ',', ' ' }))
                    list.Add(Convert.ToInt32(item));

            if (!Game.IncorrectInput(list.ToArray()))
            {
                return new Game(list.ToArray());
            }
            else throw new InvalidDataException();
        }
    }
}
