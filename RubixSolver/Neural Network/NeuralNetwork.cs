using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubixSolver.Neural_Network
{
    class NeuralNetwork
    {

        public NeuralNetwork() { }

        public static void feedForward() { }
        public static void saveNetwork() { }
        public static void loadNetwork() { }
    }

    class Neuron { }
    class Synapse {
        private Neuron front;
        private Neuron back;
        float weight;

        Synapse(Neuron front, Neuron back, float weight) {
            this.front = front;
            this.back = back;
            this.weight = weight;
        }


    }
}
