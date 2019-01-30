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
            /*
            List<List<double>> inn = new List<List<double>>();
            List<List<double>> testError = new List<List<double>>();
            List<double> oo = new List<double>();
            
<<<<<<< HEAD
            inn.Add(new List<double> { 0, 0, 1, 64, 1066, 625, 0, 11.2, 0, 0, 0, 0, 0, 0});
            inn.Add(new List<double> { 0, 0, 2, 64, 1066, 625, 1, 11, 1, 0, 0, 0, 1, 1});
            //inn.Add(new List<double> { 0.396561688, 0.400293529,0,5212,1 });
            //inn.Add(new List<double> { 0.396561688, 0.400293529,0.231256, 1 });
            //inn.Add(new List<double> { 0.396561688, 0.400293529,0.8412, 1 });
            //inn.Add(new List<double> { 0.396561688, 0.400293529,0.032121, 1 });

            int Noutputs = 4;

            n.initNetwork(13, 13, 2);
            n.printNetwork();

            n.TrainNetwork(inn, 0.7, 200, 2);
=======
            Network n = new Network();
            */

            InitializeComponent();
            Network network = new Network();
            List<List<Double>> data = network.loadCSV("files/karty.csv");
            //data = network.NormalizeData(data);
            int Noutputs = 28;
            network.initNetwork(13, 5, Noutputs);
            network.TrainNetwork(data, 0.7, 200, Noutputs);


>>>>>>> a4bd624eba1846c4c36a5755f66690ebdd5e6705


            foreach (Layer layer in network.Layers)
            {
                Console.WriteLine("Warstawa: ");
                foreach(Neuron neuron in layer.Neurons)
                {
                    Console.WriteLine("Neuron");
                    Console.WriteLine("Output: " + neuron.GetOutput());
                    Console.WriteLine("Delta: " +neuron.GetDelta());
                    foreach(double weight in neuron.Weights)
                    {
                        Console.WriteLine("Waga: " + weight);
                    }
                }
            }
            



        }
    }
}
