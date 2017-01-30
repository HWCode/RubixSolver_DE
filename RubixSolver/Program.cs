﻿using System;
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
            RubixCube myCube = new RubixCube(2);

            myCube.getFace(4).rotateFace(Direction.CCW);
            Face newFace = new RubixSolver.Face(4);
            newFace.printFace();
            Console.WriteLine();
            newFace.rotateFace(Direction.CCW);
            newFace.printFace();

            Console.ReadLine();
        }
    }
}
