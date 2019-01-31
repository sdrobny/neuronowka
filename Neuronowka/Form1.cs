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
        private int OutputsCount;
        private Network network;
        private List<List<Double>> data;
        private List<List<Double>> testData;

        
        


        public Form1()
        {
            InitializeComponent();
             
            //Inicjacja wartsoc inputow, etc.
            OutputsCount = 28;
            labelInputsCount.Text = "13";
            labelHiddenNeurons.Text = "13";
            labelOutputNeurons.Text = OutputsCount.ToString();

            //Stworzenie oraz inicjacja sieci
            network = new Network(labelRMSValue, chartRMS, neuronsValuesView);
            network.initNetwork(13, 13, OutputsCount);

            //Dane trenujace
            data = network.loadCSV("files/karty.csv");
            data = network.NormalizeData(data);

            network.updateTextBox();
            

            DrawNeurons(network, pictureBox1, Color.White, Color.Pink, Color.DarkMagenta);
            




        }

        private void DrawNeurons(Network n, PictureBox pictureBox, Color background, Color foreground, Color connections)
        {
            int TotalWidth = pictureBox.Width;
            int TotalHeight = pictureBox.Height;
            int yshift = 10;


            Bitmap canvas = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            Graphics g = Graphics.FromImage(canvas);

            int inputsCount = n.getInputsCount();
            int hiddenCount = n.Layers[0].Neurons.Count;
            int outputCount = n.Layers[1].Neurons.Count;

            Pen pen = new Pen(Color.Gray,0.25f);
            float ratio = 0;

            //Obliczenia
            //Wejscia
            ratio = TotalHeight / inputsCount;
            int inputWidth = (int)(ratio * 0.8f);
            List<Point> inputPoints = new List<Point>();
            for (int i = 0; i < inputsCount; i++)
            {
                float x = 25;
                float y = ratio*i+ratio*0.1f + yshift;
                Point p = new Point();
                p.X = (int) x;
                p.Y = (int) y;
                inputPoints.Add(p);
            }

            //Obliczenia
            //Ukryte
            ratio = TotalHeight / hiddenCount;
            int hiddenWidth = (int)(ratio * 0.8f);
            List<Point> hiddenPoints = new List<Point>();
            for (int i = 0; i < hiddenCount; i++)
            {
                float x = TotalWidth/2;
                float y = ratio * i + ratio * 0.1f + yshift;
                Point p = new Point();
                p.X = (int)x;
                p.Y = (int)y;
                hiddenPoints.Add(p);
            }


            //Obliczenia
            //Outputy
            //outputCount = 28;
            ratio = TotalHeight / outputCount;
            int outputWidth = (int)(ratio * 0.8f);
            List<Point> outputPoints = new List<Point>();
            for (int i = 0; i < outputCount; i++)
            {
                float x = TotalWidth-25-outputWidth;
                float y = ratio * i + ratio * 0.1f + yshift;
                Point p = new Point();
                p.X = (int)x;
                p.Y = (int)y;
                outputPoints.Add(p);
            }

            //Rysowanie polaczen
            foreach (Point i in inputPoints)
            {
                foreach (Point h in hiddenPoints)
                {
                    g.DrawLine(pen, i, h);
                }
            }

            foreach (Point h in hiddenPoints)
            {
                foreach (Point o in outputPoints)
                {
                    g.DrawLine(pen, h, o);
                }
            }

            //Rysowanie neuronow ukrytych
            pen = new Pen(Color.Red,1.4f);
            SolidBrush fill = new SolidBrush(foreground);
            foreach (Point h in hiddenPoints)
            {
                g.FillEllipse(fill, h.X - (hiddenWidth / 2), h.Y - (hiddenWidth / 2), hiddenWidth, hiddenWidth);
                g.DrawEllipse(pen, h.X - (hiddenWidth/2), h.Y - (hiddenWidth / 2), hiddenWidth, hiddenWidth);
                g.DrawString("H", new Font(new FontFamily("Verdana"), 10f), new SolidBrush(Color.Red), h.X - (hiddenWidth / 2)+5, h.Y - (hiddenWidth / 2)+5);
            }

            //Rysowanie wyjsc
            pen = new Pen(Color.DarkBlue, 1.4f);
            fill = new SolidBrush(Color.LightBlue);
            foreach (Point o in outputPoints)
            {
                g.FillEllipse(fill, o.X - (outputWidth / 2), o.Y - (outputWidth / 2), outputWidth, outputWidth);
                g.DrawEllipse(pen, o.X - (outputWidth / 2), o.Y - (outputWidth / 2), outputWidth, outputWidth);
                g.DrawString("O", new Font(new FontFamily("Verdana"), 6.3f), new SolidBrush(Color.DarkBlue), o.X - (outputWidth / 2)+1, o.Y - (outputWidth / 2)+1);
            }

            //Rysowanie wyjsc
            pen = new Pen(Color.DarkBlue, 1.4f);
            fill = new SolidBrush(Color.LightBlue);
            foreach (Point i in inputPoints)
            {
                g.FillEllipse(fill, i.X - (inputWidth / 2), i.Y - (inputWidth / 2), inputWidth, inputWidth);
                g.DrawEllipse(pen, i.X - (inputWidth / 2), i.Y - (inputWidth / 2), inputWidth, inputWidth);
                g.DrawString("I", new Font(new FontFamily("Verdana"), 10f), new SolidBrush(Color.DarkBlue), i.X - (outputWidth / 2), i.Y - (outputWidth / 2));
            }


            //Przypisanie wygenerowanej bitmapy do komponentu
            pictureBox.Image = canvas;
        }

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            network.TrainNetwork(data, (double)LRateInput.Value, (int)EpochsInput.Value, OutputsCount, testData);
            
        }
    }
}
