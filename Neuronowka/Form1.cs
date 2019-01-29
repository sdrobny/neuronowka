using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neuronowka
{
    public partial  class Form1 : Form 
    {
        public Form1()
        {
            List<List<double>> inn = new List<List<double>>();
            List<List<double>> testError = new List<List<double>>();
            List<double> oo = new List<double>();
            InitializeComponent();
            Network n = new Network();
            n.initNetwork(2, 1, 2);
            n.printNetwork();
            inn.Add(new List<double> { 1, 0,1,1,0,1 });
            testError.Add(new List<double> { 0, 1 });
            oo = n.ForwardPropagation(inn[0]);
            Console.WriteLine(oo[0]);
            Console.WriteLine(oo[1]);
            n.BackwardPropagateError(testError[0]);

            foreach(Layer layer in n.Layers)
            {
                Console.WriteLine("Warstawa: ");
                foreach(Neuron neuron in layer.Neurons)
                {
                    Console.WriteLine("Neuron");
                    Console.WriteLine("Output: " + neuron.GetOutput());
                    Console.WriteLine("Delta: " +neuron.GetDelta());
                    foreach(double weigh in neuron.Weights)
                    {
                        Console.WriteLine("Waga: " + weigh);
                    }
                }
            }
        }
    }
}
