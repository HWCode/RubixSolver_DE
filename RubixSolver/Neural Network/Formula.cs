using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubixSolver
{
    class Formula
    {   
        //This is the first derivative of the tanh(x) function
        public static double activationFunc(float input) {
            double tanh = Math.Tanh(input);
            return 1-tanh*tanh;
        }
        public static int NeuralNetworkError() {
            
            return 0;
        }

        public static int SigmaK()
        {
            return 0;
        }

        public static int DeltaKJ()
        {
            return 0;
        }

        public static int SigmaJ()
        {
            return 0;
        }

        public static int DeltaJI()
        {
            return 0;
        }
    }
}
