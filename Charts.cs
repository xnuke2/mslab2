using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
            int loc_x = 5;
            int loc_y = 5;
            for (int i = 0; i < x.Length; i++)
            {
                loc_x = 5;
                for (int j = 1; j < x[i][0].Length; j++)
                {
                    Chart chart1 = new Chart();
                    chart1.Series.Add("X"+j);
                    chart1.Size = new Size(300, 300);
                    chart1.Location = new Point(loc_x, loc_y);
                    chart1.ChartAreas.Add(new ChartArea(""));
                    chart1.Legends.Add("");
                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chart1.Titles.Add("X" + j + " при h = " + pg[i][0]);
                    switch (j)
                    {
                        case 1:
                            chart1.Series[0].Color = Color.Blue;
                            break;
                        case 2:
                            chart1.Series[0].Color = Color.Red;
                            break;
                        case 3:
                            chart1.Series[0].Color = Color.Orange;
                            break;
                        case 4:
                            chart1.Series[0].Color = Color.Green;
                            break;
                        case 5:
                            chart1.Series[0].Color = Color.Brown;
                            break;
                    }
                    
                    for (int k = 0; k < x[i].Length; k++)
                    {
                        chart1.Series[0].Points.AddXY(x[i][k][0]- pg[i][0], x[i][k][j]);
                    }
                    Controls.Add(chart1);
                    chart1.Visible = true;
                    loc_x += 305;
                }
                loc_y += 305;
            }
            loc_x = 5;
            Chart chart2 = new Chart();
            chart2.Series.Add("q");
            chart2.Size = new Size(300, 300);
            chart2.Location = new Point(loc_x, loc_y);
            chart2.ChartAreas.Add(new ChartArea(""));
            chart2.Legends.Add("");
            chart2.Series[0].IsXValueIndexed = true;
            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart2.Titles.Add("Относительная погрешность по сравнеию с преведущим щагом");
            loc_x += 305;
            Chart chart3 = new Chart();
            chart3.Series.Add("t");
            chart3.Size = new Size(300, 300);
            chart3.Location = new Point(loc_x, loc_y);
            chart3.ChartAreas.Add(new ChartArea(""));
            chart3.Legends.Add("");
            chart3.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart3.Series[0].IsXValueIndexed = true;
            chart3.Titles.Add("Время выполнения(в тиках) в зависимость от шага");
            chart3.Series[0].Points.AddXY(pg[0][0], pg[0][2]);
            for (int j = 1; j < pg.Length; j++)
            {
                chart2.Series[0].Points.AddXY(pg[j][0], pg[j][1]);
                chart3.Series[0].Points.AddXY(pg[j][0], pg[j][2]);
            }
            Controls.Add(chart2);
            chart2.Visible = true;
            Controls.Add(chart3);
            chart3.Visible = true;






        }

        //private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    chart1.Series.Clear();
        //    int i = listBox1.SelectedIndex;
        //    if (listBox2.SelectedIndex == -1) return;
        //    int k = listBox2.SelectedIndex;
        //    chart1.Series.Add("X" + (i + 1));
        //    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
        //    for (int j = 1; j < x[k].Length; j++)
        //    {
        //        chart1.Series[0].Points.AddXY(x[k][j][0], x[k][j][i+1]);
        //    }
        //}

        //private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    chart1.Series.Clear();
        //    if (listBox1.SelectedIndex == -1) return;
        //    int i = listBox1.SelectedIndex;
        //    int k = listBox2.SelectedIndex;
        //    chart1.Series.Add("X" + (i + 1));
        //    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
        //    for (int j = 1; j < x[k].Length; j++)
        //    {
        //        chart1.Series[0].Points.AddXY(x[k][j][0], x[k][j][i + 1]);
        //    }
        //}
    }
}

