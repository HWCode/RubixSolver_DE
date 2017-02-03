using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubixSolver
{
    interface Searchable
    {
        void move(int move);
        bool compare(Searchable srch);
    }
}
