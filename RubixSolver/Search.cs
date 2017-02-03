using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubixSolver
{
    enum SearchName { BREADTH_FIRST, A_STAR }

    interface SearchInterface {
        void search(Object start, Object goal);
    }



    class BreadthFirst  : SearchInterface {
        public void search(Object start,Object goal) {
            Console.WriteLine("BreadthFirstSearch");
            /*
             *
             * 
             * 
             * 
             * 
             */




        }
    }

    class AStarSearch   : SearchInterface {
        public void search(Object start, Object goal) {
            Console.WriteLine("AStarSearch");
        }
    }
}
