using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuronowka
{
    class Network
    {

        List<Layer> Layers = new List<Layer>();


        public Network()
        {

        }

        public void initNetwork(int inputs, int hidden, int outputs)
        {
            //Kazdy neuron warstwy ukrytej ma tyle wag ile jest wejsc + 1 (bias)
            Layers.Add(new Layer(hidden, inputs + 1));

            //Kazdy neuron warstwy wyjsc. ma tyle wag ile jest ukrytych + 1 (bias) 
            Layers.Add(new Layer(outputs, hidden + 1));
        }

        public void printNetwork()
        {
            foreach (Layer l in Layers)
            {
                Console.WriteLine("Layer: ");

                foreach(Neuron n in l.Neurons)
                {
                    Console.Write("      Neuron: ");
                    foreach(Double w in n.Weights) Console.Write(w + " ");
                    Console.WriteLine();
                }

            }
        }

        public List<List<Double>> loadCSV(string filename)
        {
            List<List<Double>> values = new List<List<Double>>();

            using (var sr = File.OpenText(filename))
            {
                
                while (!sr.EndOfStream)
                {
                    String line = sr.ReadLine();
                    String[] split = line.Split(';');
                    List<Double> values_row = new List<Double>();
                    foreach (String s in split)
                    {
                        //Console.WriteLine(s);
                        values_row.Add(Double.Parse(s));
                    }
                    values.Add(values_row);
                    //Console.Read();

                }
                
            }

            return values;
        }

        public List<Double> ForwardPropagation(List<Double> Inputs)
        {
            List<Double> NewInputs = new List<Double>();
            foreach (Layer layer in this.Layers)
            {

                foreach(Neuron neuron in layer.Neurons)
                {
                    double Activation = neuron.Activate(Inputs);
                    neuron.Transfer(Activation);
                    NewInputs.Add(neuron.GetOutput());
                }

            }
            return NewInputs;
        }
    }
}
