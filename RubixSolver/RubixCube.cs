using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubixSolver
{
    enum Colours{ WHITE, RED, YELLOW, ORANGE, GREEN, BLUE, BLANK }
    enum Faces { FACE0, FACE1, FACE2, FACE3, FACE4, FACE5}
    enum Axis {HRZ_AXIS, VERT_AXIS }
    enum Direction {CW=1,CCW=-1 }
    //enum Slices { COLUMN, ROW}
    class RubixCube : Searchable
    {
        
         /*     [G/5]
         * [W/1][R/2][Y/3][O/4]
         *      [B/6]
        */
        private Face[] cube = new Face[6];
        
        public RubixCube(int dimensions) {
            cube[0] = new Face(dimensions, Colours.WHITE);
            cube[1] = new Face(dimensions, Colours.RED);
            cube[2] = new Face(dimensions, Colours.YELLOW);
            cube[3] = new Face(dimensions, Colours.ORANGE);
            cube[4] = new Face(dimensions, Colours.GREEN);
            cube[5] = new Face(dimensions, Colours.BLUE);

            cube[0].setLinks(cube[3],   cube[1], cube[5], cube[4]);//white
            cube[1].setLinks(cube[0],   cube[2], cube[4], cube[5]);//red
            cube[2].setLinks(cube[1],   cube[3], cube[4], cube[5]);//yellow
            cube[3].setLinks(cube[2],   cube[0], cube[4], cube[5]);//orange
            cube[4].setLinks(cube[2],   cube[1], cube[0], cube[2]);//green
            cube[5].setLinks(cube[1],   cube[2], cube[2], cube[0]);//blue
        }
        //TODO have input be an enum to restric use, or use switch
        public Face getFace(int face) {
            return this.cube[face%6];
        }

        private void initializeFaces( Colours[,] face, Colours colour ){

            for (int column = 0; column < face.Length; ++column) {

                for (int row = 0; row <face.Length; ++row) {
                    face[column, row] = colour;
                }
            }
        }


        /*
         * 
         * 
             */
        public void rotateSlice(Faces face, Direction dir, Axis axis, int level ) {

            Colours[] array1 = cube[(int)face].getSlice(level, axis);
            Colours[] array2 = cube[(int)face].getLink(axis, dir).getSlice(level, axis);
            Colours[] array3 = cube[(int)face].getLink(axis, dir).getLink(axis, dir).getSlice(level, axis);
            Colours[] array4 = cube[(int)face].getLink(axis, dir).getLink(axis, dir).getLink(axis, dir).getSlice(level, axis);

            cube[(int)face].getLink(axis, dir).replaceSlice(array1, level, axis);
            cube[(int)face].getLink(axis, dir).getLink(axis, dir).replaceSlice(array2, level, axis);
            cube[(int)face].getLink(axis, dir).getLink(axis, dir).getLink(axis, dir).replaceSlice(array3, level, axis);
            cube[(int)face].getLink(axis, dir).getLink(axis, dir).getLink(axis, dir).getLink(axis, dir).replaceSlice(array4, level, axis);

        }
        private void columnSlice(Direction direction, int level) { }
        private void rowSlice(Direction direction, int level) { }

        //Only used on edge cases of slice rotation
        private void rotateFace(Face face) {
            int dim = face.getDimensions();
            Face temp = new Face( dim, Colours.BLANK);


            for (int column = 0; column < dim; ++column)
            {

                for (int row = 0; row < dim; ++row)
                {
                    //Console.Write( temp[1, 2]); //= face.getFaceColour(row,dim);
                }
            }


        }
    }

    class Face {
        private Colours[,] face;
        private Colours colour;
        private int dimensions;

        private Face columnCCW, columnCW, rowCCW, rowCW;

        /*Constructor
         */
        public Face(int dim, Colours colour) {
            this.dimensions = dim;
            this.face = new Colours[dim, dim];
            this.colour = colour;
            fillArray();
        }

        public void setLinks(Face up, Face down, Face left, Face right) {
            this.columnCCW = up;
            this.columnCW = down;
            this.rowCCW = left;
            this.rowCW = right;
        }

        public Face getLink(Axis axis, Direction direction) {
            switch (axis) {
                case Axis.HRZ_AXIS:
                    if (direction == Direction.CW)
                        return rowCW;
                    else
                        return rowCCW; 

                case Axis.VERT_AXIS:
                    if (direction == Direction.CW)
                        return columnCW;
                    else
                        return columnCCW;
                default:return null;
            }
        }

        public void compareFaces() { }

       
        //Constructor for a random face of N dimensions
        public Face(int dim) {
            this.dimensions = dim;
            this.face = new Colours[dim,dim];
            Random rnd = new Random();

            for (int column = 0; column < dimensions; ++column)
            {
                for (int row = 0; row < dimensions; ++row)
                {
                    face[row, column] = (Colours)rnd.Next(0,5);
                }
            }


        }

        /**
         Fills 2D array with one colour
             */
        private void fillArray() {

            for (int column = 0; column < dimensions; ++column)
            {
                for (int row = 0; row < dimensions; ++row)
                {
                    face[row, column] = colour;
                }
            }
        }//end of fill array

        public int getDimensions() {
            return this.dimensions;
        }//end of getDeminsions

        public Colours getSquareColour(int x,int y) {
            return this.face[x, y];
        }

        public void printFace() {

            for (int column = 0; column < dimensions; ++column)
            {
                Console.Write("[");
                for (int row = 0; row < dimensions; ++row)
                {
                    Console.Write("{0}", face[column, row]);
                    if (row != dimensions - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write("]");
                Console.WriteLine();
            }

        }//end of print face

        /**/
        public void rotateFace(Direction direction) {
            int dim = this.dimensions;
            //Face temp = new Face(dim, Colours.BLANK);
            Colours[,] temp = new Colours[dim, dim];

            for (int column = 0; column < dim; ++column)
            {

                for (int row = 0; row < dim; ++row)
                {
                    if (direction == Direction.CW)
                        temp[column, row] = face[row, (dim - column - 1)];
                    else if (direction == Direction.CCW) {
                        temp[column, row] = face[(dim-row-1), column];
                    }
                
                }
            }
            this.face = temp;
        }

        /*Creates a random face then rotates it 4 times
         * 
         * Creates random face for testing
         * TODO-At each rotatition equality between rotation and original is check
         * TODO-Only the 4th oen has to pass.
         */
        public Colours[] getSlice(int level, Axis axis) {
            Colours[] slice = new Colours[this.dimensions];

            switch (axis) {
                case Axis.VERT_AXIS:
                    for (int column =0;column<this.dimensions;++column) {
                        slice[column] = face[column, level];
                    }
                    break;

               case Axis.HRZ_AXIS:
                    for (int row = 0; row < this.dimensions; ++row)
                    {
                        slice[row] = face[level, row];
                    }
                    break;
            }
            return slice;
        }//

        /**
          * 
          */
        public void replaceSlice(Colours[] insertSlice, int level, Axis axis) {
            switch (axis)
            {
                case Axis.VERT_AXIS:
                    for (int column = 0; column < this.dimensions; ++column)
                    {
                        face[column,level] = insertSlice[column];
                    }
                    break;

                case Axis.HRZ_AXIS:
                    for (int row = 0; row < this.dimensions; ++row)
                    {
                        face[level,row] = insertSlice[row];
                    }
                    break;
            }
        }

    }
}
