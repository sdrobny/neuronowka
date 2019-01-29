using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuronowka
{
    class Neuron
    {
        public List<double> Weights = new List<double>();

        public Neuron(int weightsCount)
        {
            Random r = new Random();


            for (int i = 0; i < weightsCount; i++)
            {
                Weights.Add(r.NextDouble());
                System.Threading.Thread.Sleep(50);
            }

        }
    }
}
