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



        public void rotateSlice(Faces face, Direction dir, Axis axis, int level ) {

            Colours[] array1 = cube[(int)face].getSlice(level, axis);
            Colours[] array2 = cube[(int)face].getLink(axis, dir).getSlice(level, axis);
            Colours[] array3 = cube[(int)face].getLink(axis, dir).getLink(axis, dir).getSlice(level, axis);
            Colours[] array4 = cube[(int)face].getLink(axis, dir).getLink(axis, dir).getLink(axis, dir).getSlice(level, axis);

            cube[(int)face].getLink(axis, dir).replaceSlice(array1, level, axis);
            cube[(int)face].getLink(axis, dir).getLink(axis, dir).replaceSlice(array2, level, axis);
            cube[(int)face].getLink(axis, dir).getLink(axis, dir).getLink(axis, dir).replaceSlice(array3, level, axis);
            cube[(int)face].getLink(axis, dir).getLink(axis, dir).getLink(axis, dir).getLink(axis, dir).replaceSlice(array4, level, axis);

            if (axis == Axis.HRZ_AXIS)
            {
                if ((level == (cube[1].getDimensions() - 1)) || (level == 0))
                {
                    if (level == 0)
                        cube[(int)face].getLink(Axis.VERT_AXIS, Direction.CW).rotateFace(dir);
                    if (level == (cube[1].getDimensions() - 1))
                        cube[(int)face].getLink(Axis.VERT_AXIS, Direction.CCW).rotateFace(dir);
                }
            }
            else {
                if ((level == (cube[1].getDimensions() - 1)) || (level == 0))
                {
                    if (level == 0)
                        cube[(int)face].getLink(Axis.HRZ_AXIS, Direction.CW).rotateFace(dir);
                    if (level == (cube[1].getDimensions() - 1))
                        cube[(int)face].getLink(Axis.HRZ_AXIS, Direction.CCW).rotateFace(dir);
                }


            }

        }
 

        /* This simplefies movement along
         * 
         * 
         * 
             */
        public void move(int move) {
            Random rnd = new Random();
            int level = rnd.Next(0, this.getFace(1).getDimensions()-1);
            string encode = "";

            switch (move) {
                case 1: this.rotateSlice(Faces.FACE0, Direction.CW, Axis.HRZ_AXIS, level);
                    
                    break;
                //case 2;

            }
        }//move

        public bool isRubixSolved() {
            bool one, two, three, four, five, six;
            one     = this.cube[0].testFace();
            two     = this.cube[1].testFace();
            three   = this.cube[2].testFace();
            four    = this.cube[3].testFace();
            five    = this.cube[4].testFace();
            six     = this.cube[5].testFace();

            return one && two && three && four && five && six;
        }

        public bool compare(Searchable srch)
        {
            RubixCube n = (RubixCube)srch;
            bool compare = true;

            for (int sides = 0; 6>sides;++sides) {
                for (int row = 0; ;++row) {
                    for (int column = 0; ;++column) {

                        if (this.cube[sides].getSquareColour(column, row) != n.cube[sides].getSquareColour(column, row)  ) ;
                    }
                }

            }

            return compare;



            return false;
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

        /*
         * Checks to see if all squars in face match its starting colour
         */
        public bool testFace() {
            bool compare = true;

            for (int column = 0; column < dimensions; ++column)
            {
                for (int row = 0; row < dimensions; ++row)
                {
                    if (this.getSquareColour(column, row) != this.colour)
                    {
                        compare = false;
                        break;
                    }

                }
            }


            return compare;
        }

       
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
