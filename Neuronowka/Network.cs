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

        public List<Layer> Layers = new List<Layer>();
        //List<double> oo = new List<double>();


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


        public void BackwardPropagateError(List<double> Expected)
        {
            for (int i = Layers.Count - 1; i >= 0; i--)
            {
                Layer layer = Layers[i];
                List<double> Errors = new List<double>();
                if (i != Layers.Count - 1)
                {
                    for (int j = 0; j < layer.Neurons.Count; j++)
                    {
                        Double Error = 0.0;
                        foreach (Neuron neuron in Layers[i + 1].Neurons)
                        {
                            Error += (neuron.Weights[j] * neuron.GetDelta());
                        }
                        Errors.Add(Error);
                    }
                }
                else
                {
                    int j = 0;
                    foreach (Neuron neuron in layer.Neurons)
                    {
                        Errors.Add(Expected[j] - neuron.GetOutput());
                        j++;
                    }
                }

                for (int j = 0; j < layer.Neurons.Count; j++)
                {
                    layer.Neurons[j].SetDelta(Errors[j] * layer.Neurons[j].Derivative(layer.Neurons[j].GetOutput()));
                }

            }
        }

        //Funkcja liczaca max wartosc kolumny
        private double Max(int col, List<List<Double>> dataset)
        {
            double max = double.MinValue;

            for(int i = 0; i < dataset.Count; i++)
            {
                if (dataset[i][col] > max) max = dataset[i][col];
            }

            return max;
        }

        //Funkcja liczaca minimalna wartosc kolumny
        private double Min(int col, List<List<Double>> dataset)
        {
            double min = double.MaxValue;

            for (int i = 0; i < dataset.Count; i++)
            {
                if (dataset[i][col] < min) min = dataset[i][col];
            }

            return min;
        }

        //Przeskalowanie wartosci na zakres 0 - 1 (Funkcji sigmoidalnej)
        public List<List<Double>> NormalizeData(List<List<Double>> dataset)
        {
            //Wartosci min kolumn:
            List<Double> MinValues = new List<Double>();
            for (int i = 0; i < dataset[0].Count; i++) MinValues.Add(Min(i, dataset));

            //Wartosci min kolumn:
            List<Double> MaxValues = new List<Double>();
            for (int i = 0; i < dataset[0].Count; i++) MaxValues.Add(Max(i, dataset));


            foreach (List<Double> row in dataset)
            {
                for(int i =  0; i < row.Count; i++)
                {
                    row[i] = (row[i] - MinValues[i]) / (MaxValues[i] - MinValues[i]);
                }
            }

            return dataset;

        }
    }
}
