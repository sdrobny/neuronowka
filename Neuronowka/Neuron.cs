﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuronowka
{
    class Neuron
    {
        public List<double> Weights = new List<double>();

        private double Output;
        private double Delta ;

        public double GetDelta()
        {
            return this.Delta;
        }

        public void SetDelta(double delta)
        {
            this.Delta = delta;
        }

        public double GetOutput()
        {
            return this.Output;
        }
        
        //Konstruktor neuronu, inicjacja wag losowymi wartościami
        public Neuron(int weightsCount)
        {
            this.Output = 0;

            Random r = new Random();

            for (int i = 0; i < weightsCount; i++)
            {
                Weights.Add(r.NextDouble());
                System.Threading.Thread.Sleep(10);
            }

        }

        //Obliczanie aktywacji
        public double Activate(List<Double> Inputs)
        {
            double activation = Weights[Weights.Count - 1];

            for (int i = 0; i < Weights.Count - 1; i++)
            {
                activation += Weights[i] * Inputs[i];
            }
            return activation;
        }

        //Funkcja transferu
        public void Transfer(Double Activation)
        {
            this.Output =  1.0 / (1.0 + Math.Exp((-Activation)));
        }

        //Pochodna z outputu neuronu
        public double Derivative(double output)
        {
            return output * (1.0 - output);
        }

    }
}
