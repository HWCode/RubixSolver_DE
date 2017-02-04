using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubixSolver
{

    interface SearchInterface {
        void search(Searchable start, Searchable goal);
    }



    class BreadthFirst  : SearchInterface {
        public void search(Searchable start, Searchable goal) {
            //Contains what the algorithm is going to be searching
            Queue<Searchable> myQueue = new Queue<Searchable>();
            //The set keeps track of vertices that have been visited.
            HashSet<Searchable> mySet = new HashSet<Searchable>();

            Searchable parent = null;

            myQueue.Enqueue(goal);

            Searchable current;
                
                while (myQueue.Count != 0) {
                    current = myQueue.Dequeue();
                    if ( current.compare(goal) ) {
                    //return current;
                    break;

                    }
                
                    foreach (Searchable n in myQueue) {
                        if ( !mySet.Contains(n) ) {
                            mySet.Add(n);
                            parent = current;
                            myQueue.Enqueue(n);
                        }
                    }//foreach
                }
        }
        
    }//searchinterface

    class AStarSearch   : SearchInterface {
        public void search(Searchable start, Searchable goal) {
           // ArrayList st = new ArrayList();


        }

    }
}
