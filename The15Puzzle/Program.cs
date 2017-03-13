using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The15Puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game(1, 2, 3, 4, 5, 6, 7, 8, 0);
            if (g.field != null)
            {
                g.Print();
            }
            else
                Console.WriteLine("Попробуйте еще раз");
            
            //Game game = Game.ReadFile("");
        }
    }
}
