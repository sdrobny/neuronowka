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
            InitializeComponent();
            Network n = new Network();
            n.initNetwork(2, 1, 2);
            n.printNetwork();


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
