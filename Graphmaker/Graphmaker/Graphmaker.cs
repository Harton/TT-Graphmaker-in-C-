using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace Graphmaker
{

    public partial class Graphmaker : Form
    {
         
        public Graphmaker()
        
        {
            InitializeComponent();
        }
   
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ArrayList bob = new ArrayList();
            string[] data = bob.ToArray(typeof(string)) as string[];
            
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName; //Åbner filen fra OpenDialog funktionen.
                string text = File.ReadAllText(file);
                data = text.Split(';');

                for (int y = 0; y < data.Length; y++)
                {   
                    chart1.Series["Pulse/time"].Points.AddXY
                               (y, data.GetValue(y));

                    chart1.ChartAreas["area"].AxisX.Maximum = data.Length;
                    chart1.Series["Pulse/time"].Color = Color.Red;
                    chart1.SaveImage("Graph of pulse.jpg", ChartImageFormat.Jpeg);

                }
                Application.Exit();      
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {   
            chart1.Hide();
            chart1.ChartAreas.Add("area");
            chart1.Series["Pulse/time"].ChartType = SeriesChartType.Line;
            chart1.ChartAreas["area"].AxisX.Minimum = 0;
            chart1.ChartAreas["area"].AxisX.Interval = 5;
            chart1.ChartAreas["area"].AxisY.Minimum = 0;
            chart1.ChartAreas["area"].AxisY.Maximum = 250;
            chart1.ChartAreas["area"].AxisY.Interval = 10;
        }

        private void chart1_Click_1(object sender, EventArgs e)
        {
        }

    }
}
