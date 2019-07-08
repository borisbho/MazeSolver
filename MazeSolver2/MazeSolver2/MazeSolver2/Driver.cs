using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver2
{

    public class Driver
    {
        public static void Main(string[] args)
        {
            Maze m = new Maze();
            m.BuildMaze(StoreAllInputs());
  
         }
        public static string StoreAllInputs()
        {
            Console.WriteLine("Please Enter a File Location: ");
            string file = "C:\\Users\\Boris Ho\\Documents\\WorkSpace\\MazeSolver\\MazeSolver\\input.txt";
            // string file = Console.ReadLine();
            return file;
        }

    }
}
