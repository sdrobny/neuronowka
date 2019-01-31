namespace Neuronowka
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chartRMS = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxLearning = new System.Windows.Forms.GroupBox();
            this.LRateInput = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.labelRMSValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonTrain = new System.Windows.Forms.Button();
            this.EpochsInput = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelInputsCount = new System.Windows.Forms.Label();
            this.labelHiddenNeurons = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelOutputNeurons = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.neuronsValuesView = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRMS)).BeginInit();
            this.groupBoxLearning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LRateInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EpochsInput)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 480);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // chartRMS
            // 
            chartArea2.Name = "ChartArea1";
            this.chartRMS.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartRMS.Legends.Add(legend2);
            this.chartRMS.Location = new System.Drawing.Point(6, 47);
            this.chartRMS.Name = "chartRMS";
            this.chartRMS.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "RMS";
            this.chartRMS.Series.Add(series2);
            this.chartRMS.Size = new System.Drawing.Size(827, 144);
            this.chartRMS.TabIndex = 1;
            this.chartRMS.Text = "Wykres błędu RMS";
            // 
            // groupBoxLearning
            // 
            this.groupBoxLearning.Controls.Add(this.LRateInput);
            this.groupBoxLearning.Controls.Add(this.label6);
            this.groupBoxLearning.Controls.Add(this.labelRMSValue);
            this.groupBoxLearning.Controls.Add(this.label4);
            this.groupBoxLearning.Controls.Add(this.buttonTrain);
            this.groupBoxLearning.Controls.Add(this.EpochsInput);
            this.groupBoxLearning.Controls.Add(this.label2);
            this.groupBoxLearning.Controls.Add(this.chartRMS);
            this.groupBoxLearning.Location = new System.Drawing.Point(519, 7);
            this.groupBoxLearning.Name = "groupBoxLearning";
            this.groupBoxLearning.Size = new System.Drawing.Size(839, 233);
            this.groupBoxLearning.TabIndex = 2;
            this.groupBoxLearning.TabStop = false;
            this.groupBoxLearning.Text = "Uczenie sieci";
            // 
            // LRateInput
            // 
            this.LRateInput.DecimalPlaces = 1;
            this.LRateInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.LRateInput.Location = new System.Drawing.Point(270, 18);
            this.LRateInput.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LRateInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.LRateInput.Name = "LRateInput";
            this.LRateInput.Size = new System.Drawing.Size(67, 20);
            this.LRateInput.TabIndex = 8;
            this.LRateInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(150, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Częstotliwość uczenia:";
            // 
            // labelRMSValue
            // 
            this.labelRMSValue.AutoSize = true;
            this.labelRMSValue.Location = new System.Drawing.Point(83, 206);
            this.labelRMSValue.Name = "labelRMSValue";
            this.labelRMSValue.Size = new System.Drawing.Size(13, 13);
            this.labelRMSValue.TabIndex = 6;
            this.labelRMSValue.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(7, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Błąd RMS:";
            // 
            // buttonTrain
            // 
            this.buttonTrain.Location = new System.Drawing.Point(343, 15);
            this.buttonTrain.Name = "buttonTrain";
            this.buttonTrain.Size = new System.Drawing.Size(75, 23);
            this.buttonTrain.TabIndex = 4;
            this.buttonTrain.Text = "Uczenie";
            this.buttonTrain.UseVisualStyleBackColor = true;
            this.buttonTrain.Click += new System.EventHandler(this.buttonTrain_Click);
            // 
            // EpochsInput
            // 
            this.EpochsInput.Location = new System.Drawing.Point(77, 18);
            this.EpochsInput.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.EpochsInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.EpochsInput.Name = "EpochsInput";
            this.EpochsInput.Size = new System.Drawing.Size(67, 20);
            this.EpochsInput.TabIndex = 3;
            this.EpochsInput.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Liczba epok:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Liczba wejść:";
            // 
            // labelInputsCount
            // 
            this.labelInputsCount.AutoSize = true;
            this.labelInputsCount.Location = new System.Drawing.Point(93, 7);
            this.labelInputsCount.Name = "labelInputsCount";
            this.labelInputsCount.Size = new System.Drawing.Size(25, 13);
            this.labelInputsCount.TabIndex = 4;
            this.labelInputsCount.Text = "666";
            // 
            // labelHiddenNeurons
            // 
            this.labelHiddenNeurons.AutoSize = true;
            this.labelHiddenNeurons.Location = new System.Drawing.Point(269, 7);
            this.labelHiddenNeurons.Name = "labelHiddenNeurons";
            this.labelHiddenNeurons.Size = new System.Drawing.Size(25, 13);
            this.labelHiddenNeurons.TabIndex = 6;
            this.labelHiddenNeurons.Text = "666";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(124, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Neurony warstwy ukrytej:";
            // 
            // labelOutputNeurons
            // 
            this.labelOutputNeurons.AutoSize = true;
            this.labelOutputNeurons.Location = new System.Drawing.Point(449, 7);
            this.labelOutputNeurons.Name = "labelOutputNeurons";
            this.labelOutputNeurons.Size = new System.Drawing.Size(25, 13);
            this.labelOutputNeurons.TabIndex = 8;
            this.labelOutputNeurons.Text = "666";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(300, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Neurony warstwy wyjscia:";
            // 
            // neuronsValuesView
            // 
            this.neuronsValuesView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.neuronsValuesView.Location = new System.Drawing.Point(519, 247);
            this.neuronsValuesView.Multiline = true;
            this.neuronsValuesView.Name = "neuronsValuesView";
            this.neuronsValuesView.ReadOnly = true;
            this.neuronsValuesView.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.neuronsValuesView.Size = new System.Drawing.Size(837, 260);
            this.neuronsValuesView.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 519);
            this.Controls.Add(this.neuronsValuesView);
            this.Controls.Add(this.labelOutputNeurons);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelHiddenNeurons);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelInputsCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxLearning);
            this.Controls.Add(this.pictureBox1);
            this.MaximumSize = new System.Drawing.Size(1377, 558);
            this.MinimumSize = new System.Drawing.Size(1377, 558);
            this.Name = "Form1";
            this.Opacity = 0.95D;
            this.Text = "Siec Neuronowa Dwuwarstwowa Sigmoidalna z propagacją wsteczną - M. Bałek , S. Dro" +
    "bny";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRMS)).EndInit();
            this.groupBoxLearning.ResumeLayout(false);
            this.groupBoxLearning.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LRateInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EpochsInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRMS;
        private System.Windows.Forms.GroupBox groupBoxLearning;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelInputsCount;
        private System.Windows.Forms.Label labelHiddenNeurons;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelOutputNeurons;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelRMSValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonTrain;
        private System.Windows.Forms.NumericUpDown EpochsInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown LRateInput;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox neuronsValuesView;
    }
}

