using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubixSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Face face0 = new RubixSolver.Face(3, Colours.GREEN);
            Face face1 = new RubixSolver.Face(3, Colours.RED);
            face0.printFace();
            face1.printFace();

            Console.ReadLine();
        }
    }
}
