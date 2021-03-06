﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Neuronowka
{
    class Network
    {

        public List<Layer> Layers = new List<Layer>();
        //List<double> oo = new List<double>();
        private int inputsCount;
        private Label RMSLabel;

        //Dane do wykresu
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private List<Double> errors;

        // TextBox z wartosciami
        TextBox textBox;

        public int getInputsCount()
        {
            return inputsCount;
        }

        public Network(Label RMSLabel, System.Windows.Forms.DataVisualization.Charting.Chart chart, TextBox tb)
        {
            this.RMSLabel = RMSLabel;
            this.chart = chart;
            this.textBox = tb;
        }

        public void initNetwork(int inputs, int hidden, int outputs)
        {
            //Kazdy neuron warstwy ukrytej ma tyle wag ile jest wejsc + 1 (bias)
            Layers.Add(new Layer(hidden, inputs + 1));

            //Kazdy neuron warstwy wyjsc. ma tyle wag ile jest ukrytych + 1 (bias) 
            Layers.Add(new Layer(outputs, hidden + 1));

            this.inputsCount = inputs;


        }

        public void printNetwork()
        {
            foreach (Layer l in Layers)
            {
                Console.WriteLine("Layer: ");

                foreach (Neuron n in l.Neurons)
                {
                    Console.Write("      Neuron: ");
                    foreach (Double w in n.Weights) Console.Write(w + " ");
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
                        double tmp;
                        //Console.WriteLine(s);
                        if ( Double.TryParse(s,out tmp) )values_row.Add(Double.Parse(s));
                    }
                    values.Add(values_row);
                    //Console.Read();

                }

            }

            return values;
        }

        public List<Double> ForwardPropagation(List<Double> Inputs)
        {

            List<double> K = new List<double>();

            foreach (Layer layer in this.Layers)
            {
                List<Double> NewInputs = new List<Double>();
                foreach (Neuron neuron in layer.Neurons)
                {
                    double Activation = neuron.Activate(Inputs);
                    neuron.Transfer(Activation);
                    NewInputs.Add(neuron.GetOutput());
                }
                K = NewInputs;
            }
            return K;
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

        public void UpdateWeights(double LearningRate, List<double> InputRow)
        {

            for (int i=0; i<Layers.Count; i++)
            {
                List<double> Row = InputRow;
                Row.RemoveAt(Row.Count - 1);

                if (i != 0)
                {
                    Row.Clear();

                    foreach (Neuron neuron in Layers[i-1].Neurons)
                    {
                        Row.Add(neuron.GetOutput());
                    }
                }

                for (int z = 0; z < Layers[i].Neurons.Count; z++)
                {
                    for (int j=0; j<Row.Count; j++)
                    {
                        Layers[i].Neurons[z].Weights[j] += LearningRate * Layers[i].Neurons[z].GetDelta() * Row[j];
                    }
                    Layers[i].Neurons[z].Weights[Layers[i].Neurons[z].Weights.Count-1] += LearningRate * Layers[i].Neurons[z].GetDelta();
                }

            }

        }

        public void TrainNetwork(List<List<double>>InputData, double LearningRate, int Epoch, int ZeroForIterator, List<List<double>> test)
        {
            chart.Series[0].Points.Clear();

            for (int i=1; i <= Epoch; i++)
            {
                double SumError = 0;
                for (int r=0; r<InputData.Count;r++)
                {
                    
                    List<double> OutPuts = ForwardPropagation(InputData[r]);
                    List<double> Expected = new List<double>();

                    for (int z=0; z<ZeroForIterator; z++)
                    {
                        Expected.Add(0);
                    }

                    Expected[Expected.Count-1] = 1;

                    for (int x = 0; x<Expected.Count; x++)
                    {
                        SumError += Math.Pow(Expected[x] - OutPuts[x],2);
                    }
                    BackwardPropagateError(Expected);
                    UpdateWeights(LearningRate, InputData[r]);
                }

                //Console.WriteLine("Epoka:" +i + "Lrate" + LearningRate + "Error" + SumError);
                RMSLabel.Text = SumError.ToString() + "    (" + i + "/" + Epoch + ")";
                updateChart(SumError, Epoch);
                updateTextBox();
                Thread.Sleep(2);
                Application.DoEvents();
            }

            List<List<double>> TestCopy = new List<List<double>>(test);

        }

            //Funkcja liczaca max wartosc kolumny
            private double Max(int col, List<List<Double>> dataset)
            {
                double max = double.MinValue;

                for (int i = 0; i < dataset.Count; i++)
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
                    for (int i = 0; i < row.Count; i++)
                    {
                        row[i] = (row[i] - MinValues[i]) / (MaxValues[i] - MinValues[i]);
                    }
                }

                return dataset;

            }

            public void updateChart(double error, int Epoch)
            {
                chart.Series[0].Points.Add(error, Epoch);
            }

            public void updateTextBox()
            {
                textBox.Clear();
                String str = "";
                for(int i = 0; i < Layers.Count; i++)
                {
                    if (i == 0) str += "WARSTWA UKRYTA" + Environment.NewLine + Environment.NewLine;
                    else if (i == 1) str += "WARSTWA WYJSCIOWA" + Environment.NewLine;

                    foreach(Neuron n in Layers[i].Neurons)
                    {
                    str += ">>>" + "Neuron - Output: " + n.GetOutput() + " Delta: " + n.GetDelta() + Environment.NewLine;
                    str += "Wagi: [ ";
                    foreach (Double w in n.Weights) str += w.ToString() + " ";
                    str += " ] " + Environment.NewLine + Environment.NewLine;
                    }
                }
                textBox.Text = str;
            }

    }
}

