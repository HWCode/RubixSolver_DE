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
            
            RubixCube myCube = new RubixCube(3);
            /*
            myCube.getFace(4).rotateFace(Direction.CCW);
            Face newFace = new RubixSolver.Face(4);
            newFace.printFace();
            Console.WriteLine();
            //newFace.rotateFace(Direction.CCW);
            Colours[] arraytes = newFace.getSlice(1,Axis.HORIZONTAL_AXIS);
            newFace.replaceSlice(arraytes,0,Axis.VERTICAL_AXIS);

            newFace.printFace();

            Console.ReadLine();*/
            myCube.rotateSlice(Faces.FACE0,Direction.CW,Axis.HRZ_AXIS,2);
            myCube.rotateSlice(Faces.FACE0, Direction.CW, Axis.VERT_AXIS, 2);
            Console.WriteLine();
            //Colours[] array = myCube
            /*
            Colours[] array1 = myCube.getFace(0).getSlice(1,Axis.VERT_AXIS);//white string
            Colours[] array2 = myCube.getFace(0).getLink(Axis.VERT_AXIS, Direction.CCW).getSlice(1, Axis.VERT_AXIS);
            Colours[] array3 = myCube.getFace(0).getLink(Axis.VERT_AXIS, Direction.CCW).getLink(Axis.VERT_AXIS, Direction.CCW).getSlice(1, Axis.VERT_AXIS);
            Colours[] array4 = myCube.getFace(0).getLink(Axis.VERT_AXIS, Direction.CW).getSlice(1, Axis.VERT_AXIS);
            

            myCube.getFace(0).getLink(Axis.VERT_AXIS, Direction.CCW).replaceSlice(array1,1,Axis.VERT_AXIS);
            myCube.getFace(0).getLink(Axis.VERT_AXIS, Direction.CCW).getLink(Axis.VERT_AXIS, Direction.CCW).replaceSlice(array2, 1, Axis.VERT_AXIS);
            myCube.getFace(0).getLink(Axis.VERT_AXIS, Direction.CCW).getLink(Axis.VERT_AXIS, Direction.CCW).getLink(Axis.VERT_AXIS, Direction.CCW).replaceSlice(array3, 1, Axis.VERT_AXIS);
            myCube.getFace(0).getLink(Axis.VERT_AXIS, Direction.CCW).getLink(Axis.VERT_AXIS, Direction.CCW).getLink(Axis.VERT_AXIS, Direction.CCW).getLink(Axis.VERT_AXIS, Direction.CCW).replaceSlice(array3, 1, Axis.VERT_AXIS);
            */


            //myCube.getFace(0).getLink(Axis.VERT_AXIS,Direction.CCW).printFace();
            //myCube.getFace(0).getLink(Axis.VERT_AXIS, Direction.CCW).getLink(Axis.VERT_AXIS, Direction.CCW).printFace();
            //myCube.getFace(0).getLink(Axis.VERT_AXIS, Direction.CCW).getLink(Axis.VERT_AXIS, Direction.CCW).getLink(Axis.VERT_AXIS, Direction.CCW).printFace();
            //myCube.getFace(0).getLink(Axis.VERT_AXIS, Direction.CCW).getLink(Axis.VERT_AXIS, Direction.CCW).getLink(Axis.VERT_AXIS, Direction.CCW).getLink(Axis.VERT_AXIS, Direction.CCW).printFace();
            myCube.getFace(0).printFace();
            myCube.getFace(1).printFace();
            myCube.getFace(2).printFace();
            myCube.getFace(3).printFace();
            myCube.getFace(4).printFace();
            myCube.getFace(5).printFace();
            //myCube.getFace(1).printFace();
            //myCube.getFace(2).printFace();
            //myCube.getFace(3).printFace();

            Console.ReadLine();


        }
    }
}
