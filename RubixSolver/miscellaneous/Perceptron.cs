using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubixSolver.miscellaneous
{
    class Perceptron
    {

        float[] weights;

        public Perceptron(int n) {
            Random rnd = new Random();
            weights = new float[n];

            for (int index = 0; index < n; ++index) {
                
                weights[index] = (float)rnd.Next(-2,2);

            }
        }

        public  static int activate(float input) {
            if (input < 0) return 1;
            else return -1;
        }

        public int feedForward(float[] values) {
            float sum = 0;

            for (int indexer = 0;indexer < weights.Length;++indexer) {
                sum += (float)values[indexer] * weights[indexer];
            }
            return activate(sum);

        }

        public void Test() {
            Console.WriteLine("Hello Perceptron");
            Console.ReadLine();
        }

    }
}
