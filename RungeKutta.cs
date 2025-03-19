using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mslab2
{
    public class RungeKutta

    {


        protected double t = 0.0;


        protected double[] Y;


        protected double[] kk, k1, k2, k3, k4;

        protected Func<double, double[], double>[] Funcs;

        public RungeKutta(double[] y, Func<double, double[], double>[] func)

        {
            Y = new double[y.Length];
            y.CopyTo(Y, 0);
            kk = new double[y.Length];
            Funcs = new Func<double, double[], double>[func.Length];
            func.CopyTo(Funcs, 0);
        }

        protected double[] F(double t, double[] Y, Func<double, double[], double>[] Funs)

        {
            double[] FVals = new double[Funs.Length];
            for (int i = 0; i < Funs.Length; i++)
            {
                FVals[i] = Funs[i](t, Y);
            }
            return FVals;
        }

        protected void NextStep(double dt)

        {
            // рассчитать k1

            k1 = F(t, Y, Funcs);
            //Y==k

            for (int i = 0; i < Y.Length; i++)

                kk[i] = Y[i] + dt * k1[i] / 2.0; //k2


            // рассчитать k2

            k2 = F(t + dt / 2.0, kk, Funcs);


            for (int i = 0; i < Y.Length; i++)

                kk[i] = Y[i] + dt/2.0 * k2[i]; //k3


            // рассчитать k3

            k3 = F(t + dt / 2.0, kk, Funcs);


            for (int i = 0; i < Y.Length; i++)

                kk[i] = Y[i] + dt*k3[i]; //k4


            // рассчитать k4

            k4 = F(t + dt, kk, Funcs);


            // рассчитать решение на новом шаге

            for (int i = 0; i < Y.Length; i++)
                Y[i] = Y[i] + dt / 6.0 * (k1[i] + 2 * k2[i] + 2 * k3[i] + k4[i]) ;//y[n+1]


            t = t + dt;

        }

        public List<double[]> Solve(double T, double n)

        {
            List<double[]> rez = new List<double[]>();
            double dt = n;
            while (t <= T)

            {

                NextStep(dt);
                double[] arr = new double[Y.Length+1];
                Y.CopyTo(arr, 1);
                arr[0] = t;
                rez.Add(arr);

            }


            //}

            return rez;

        }

    }
}
