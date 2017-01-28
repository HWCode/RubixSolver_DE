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
            Face face = new RubixSolver.Face(3, Colours.BLUE);
            face.printFace();

            Console.ReadLine();
        }
    }
}
