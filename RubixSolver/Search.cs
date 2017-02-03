using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubixSolver
{
    enum SearchName { BREADTH_FIRST, A_STAR }

    interface SearchInterface {
        void search(Searchable start, Searchable goal);
    }



    class BreadthFirst  : SearchInterface {
        public void search(Searchable start, Searchable goal) {
            Queue<Searchable> myQueue = new Queue<Searchable>();
            HashSet<Searchable> mySet = new HashSet<Searchable>();
            myQueue.Enqueue(goal);

            Searchable current;

            while (myQueue.Count != 0) {
                current = myQueue.Dequeue();
                if ( current.compare(goal) ) {
                    //return current.dequeue();
                }

                foreach (Searchable n in myQueue) {
                    if ( !mySet.Contains(n) ) {
                        mySet.Add(n);
                        //
                        myQueue.Enqueue(n);
                    }

                }


            }
 
            int i = 1;
            start.move(i);




        }
    }

    class AStarSearch   : SearchInterface {
        public void search(Searchable start, Searchable goal) {
            Console.WriteLine("AStarSearch");
        }
    }
}
