using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuronowka
{
    class Layer
    {
        public List<Neuron> Neurons = new List<Neuron>();
        
        public Layer(int neuronsCount, int weightsCount)
        {
            for(int i = 0; i < neuronsCount; i++)
            {
                Neurons.Add(new Neuron(weightsCount));
            }
        }
    }
}
