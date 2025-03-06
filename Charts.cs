using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mslab2
{
    public partial class Charts : Form
    {
        double[][][] x;
        double[][] pg;
        public Charts(double[][][] X, double[][] pogs)
        {
            InitializeComponent();
            x = X;
            pg = pogs;
        }

        private void Charts_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            for (int j = 1; j < x[0][0].Length; j++)
            {
                listBox1.Items.Add("X" + j);
            }
            listBox1.SelectedIndex = 0;
            listBox2.Items.Clear();

            for (int j = 0; j < pg.Length; j++)
            {
                listBox2.Items.Add(pg[j][0]);
            }
            listBox2.SelectedIndex = 0;

            chart2.Series.Add("q");
            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart2.Series[0].IsXValueIndexed = true;
            chart3.Series.Add("t");
            chart3.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart3.Series[0].IsXValueIndexed = true;
            chart3.Series[0].Points.AddXY(pg[0][0], pg[0][2]);
            for (int j = 1; j < pg.Length; j++)
            {
                chart2.Series[0].Points.AddXY(pg[j][0], pg[j][1]);
                chart3.Series[0].Points.AddXY(pg[j][0], pg[j][2]);
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            int i = listBox1.SelectedIndex;
            if (listBox2.SelectedIndex == -1) return;
            int k = listBox2.SelectedIndex;
            chart1.Series.Add("X" + (i + 1));
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            for (int j = 1; j < x[k].Length; j++)
            {
                chart1.Series[0].Points.AddXY(x[k][j][0], x[k][j][i+1]);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            if (listBox1.SelectedIndex == -1) return;
            int i = listBox1.SelectedIndex;
            int k = listBox2.SelectedIndex;
            chart1.Series.Add("X" + (i + 1));
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            for (int j = 1; j < x[k].Length; j++)
            {
                chart1.Series[0].Points.AddXY(x[k][j][0], x[k][j][i + 1]);
            }
        }
    }
}

