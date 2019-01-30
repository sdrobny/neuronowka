﻿using System;
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
            
            Network n = new Network();
            */

            InitializeComponent();
            Network network = new Network();
            List<List<Double>> data = network.loadCSV("files/karty.csv");
            //data = network.NormalizeData(data);
            int Noutputs = 28;
            network.initNetwork(13, 5, Noutputs);
            network.TrainNetwork(data, 0.7, 200, Noutputs);




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
