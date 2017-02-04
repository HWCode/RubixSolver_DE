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

            RubixCube cube = new RubixCube(3);
    


        }

        public static void customCube() {
            Console.WriteLine("You have selected custom cube, which face you want");
            int face = Convert.ToInt32(Console.ReadLine());
            RubixCube cube = new RubixCube(face);

        }

        public static void printAllFaces(RubixSolver.RubixCube myCube) {
            myCube.getFace(0).printFace();
            myCube.getFace(1).printFace();
            myCube.getFace(2).printFace();
            myCube.getFace(3).printFace();
            myCube.getFace(4).printFace();
            myCube.getFace(5).printFace();


        }
    }
}
