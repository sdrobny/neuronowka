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
            
            inn.Add(new List<double> { 2.7810836, 2.550537003,0 });
            inn.Add(new List<double> { 1.465489372, 2.362125076,0 });
            inn.Add(new List<double> { 3.396561688, 4.400293529,1 });

            int Noutputs = 3;

            n.initNetwork(2, 3, Noutputs);
            n.printNetwork();

            n.TrainNetwork(inn, 0.7, 200, Noutputs);

            /*
            testError.Add(new List<double> { 0, 1 });
            oo = n.ForwardPropagation(inn[0]);
            Console.WriteLine(oo[0]);
            Console.WriteLine(oo[1]);
            n.BackwardPropagateError(testError[0]);

            */
            foreach (Layer layer in n.Layers)
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
            

            Random r = new Random();
            List<List<Double>> data = new List<List<double>>();

            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                List<Double> tmp = new List<Double>();
                for(int j = 0; j < 5; j++)
                {
                    tmp.Add(Double.Parse(r.Next(0, 450).ToString()));
                }
                data.Add(tmp);
            }

            foreach(List<Double> row in data)
            {
                foreach (Double x in row) Console.Write(x.ToString() + " ");
                Console.WriteLine();
            }

            Console.WriteLine();

            data = n.NormalizeData(data);


            foreach (List<Double> row in data)
            {
                foreach (Double x in row) if (x.ToString().Length > 5) Console.Write(x.ToString().Substring(0,5) + " "); else Console.Write(x.ToString() + " ");
                Console.WriteLine();
            }


        }
    }
}
