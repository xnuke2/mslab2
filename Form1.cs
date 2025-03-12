using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mslab2
{
    public partial class Form1 : Form
    {
        int max = 12;
        static double a = 0.5;
        static int V = 600;
        static int k = 2;
        static int l = 7;
        static int m = 1;
        static int n = 7;
        static int kt =100 ;
        static int b = 30000;
        static int i1 = 20;
        static int i2 = 2;
        static int s = 200;
        static double[] Y = { 0.9, 0.9, 0, 0, 100 };
        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Maximum =Convert.ToDecimal((double)max - Math.Pow(10,-numericUpDown1.DecimalPlaces));
            numericUpDown1.Minimum = Convert.ToDecimal((double)Math.Pow(10, -numericUpDown1.DecimalPlaces));
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Func<double, double[], double>[] Funs =new Func<double, double[], double>[5];
            Funs[0] = Y1;
            Funs[1] = Y2;
            Funs[2] = Y3;
            Funs[3] = Y4;
            Funs[4] = Y5;
            RungeKutta rungeKutta = new RungeKutta(Y, Funs);
            double step = Convert.ToDouble(numericUpDown1.Value);
            rungeKutta = new RungeKutta(Y, Funs);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<double[]> el = rungeKutta.Solve(max, step);
            stopwatch.Stop();
            double pog;
            List<double[]> eLast;
            List<double[][]> rez =new List<double[][]>();
            List<double[]> pogs = new List<double[]>();
            pogs.Add(new double[] { step, Int32.MaxValue, stopwatch.ElapsedTicks });
            rez.Add(el.ToArray());
            do
            {
                eLast = new List<double[]>(el);
                step = step / 2;
                rungeKutta = new RungeKutta(Y, Funs);
                stopwatch.Start();
                el = rungeKutta.Solve(max, step);
                stopwatch.Stop();
                double dsd = eLast[eLast.Count - 1][5];
                double dsd2 = el[el.Count - 1][5];
                double tmp = (eLast[eLast.Count - 1][4] - el[el.Count - 1][4]);
                pog = Math.Abs((eLast[eLast.Count-1][3] - el[el.Count - 1][3]) / eLast[eLast.Count - 1][3]) * 100;
                pogs.Add(new double[]{step, pog ,stopwatch.ElapsedTicks});
                rez.Add(el.ToArray());
            } while (pog > 1);

            Charts ch =new Charts(rez.ToArray(), pogs.ToArray());
            ch.Show();
        }
        static double Y1(double t, double[] Y)
        {
            return k*Y[1]-k*Y[0];
        }
        static double Y2(double t, double[] Y)
        {
            return Y[2];
        }
        static double Y3(double t, double[] Y)
        {
            return l*Y[0]-l*Y[1]-m*Y[2]+n*Y[3];
        }
        static double Y4(double t, double[] Y)
        {
            double tmp = Math.Abs(Bq(t, Y));
            if (tmp <= a)
            {
                return Bq(t, Y);
            }
            
            return a * Math.Sign(Bq(t, Y));
        }
        static double Bq(double t, double[] Y)
        {
            return -kt * Y[3] - i1 * Y[1] - i2 * Y[2] + s * (O(t,Y) - Y[1]);
        }
        static double O(double t, double[] Y)
        {
            return (10000 - Y[4]) / (b - V*t);
        }
        static double Y5(double t, double[] Y)
        {
            return V*Math.Sin(Y[0]);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
