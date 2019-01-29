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

        }
    }
}
