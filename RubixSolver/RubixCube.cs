using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubixSolver
{
    enum Colours{ WHITE, RED, YELLOW, ORANGE, GREEN, BLUE }
    enum Axis {X_AXIS, Y_AXIS, Z_AXIS }
    enum Direction {CW=1,CCW=-1 }
    class RubixCube
    {
  
        private Face[] cube = new Face[6];
        //private Colours[,][] FacesArray = { Face0, Face1, Face2, Face3, Face4, Face5 };
        public RubixCube(int dimensions) {
            cube[0] = new Face(dimensions, Colours.WHITE);
            cube[1] = new Face(dimensions, Colours.RED);
            cube[2] = new Face(dimensions, Colours.YELLOW);
            cube[3] = new Face(dimensions, Colours.ORANGE);
            cube[4] = new Face(dimensions, Colours.GREEN);
            cube[5] = new Face(dimensions, Colours.BLUE);

        }

        private void initializeFaces( Colours[,] face, Colours colour ){

            for (int column = 0; column < face.Length; ++column) {

                for (int row = 0; row <face.Length; ++row) {
                    face[column, row] = colour;
                }
            }
        }

        public void rotateSlice(Face face,Direction dir, Axis axis ) { }

        //Only used on edge cases of slice rotation
        private void rotateFace() { }
    }

    class Face {
        private Colours[,] face;
        private Colours colour;
        private int dimensions;

        public static void main(string[] args) {
            Face face = new RubixSolver.Face( 3, Colours.BLUE );
            face.printFace();



        }
        

        public Face(int dim, Colours colour) {
            this.dimensions = dim;
            this.face = new Colours[dim,dim];
            this.colour = colour;
            fillArray();
        }


        private void fillArray() {

            for (int column = 0; column < dimensions; ++column)
            {
                for (int row = 0; row < dimensions; ++row)
                {
                    face[row, column] = colour;
                }
            }
        }

        public void printFace() {

            for (int column = 0; column < dimensions; ++column)
            {
                Console.Write("[");
                for (int row = 0; row < dimensions; ++row)
                {
                    Console.Write("{0}",face[row, column]);
                    if (row !=dimensions -1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write("]");
            }

        }

    }
}
