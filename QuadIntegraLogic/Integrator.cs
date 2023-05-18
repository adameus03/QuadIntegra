using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadIntegraLogic
{
    public abstract class Integrator
    {
        protected double a;
        protected double b;
        protected double epsilon;
        protected Func<double, double> f;

        public Integrator(Func<double, double> f, double a, double b, double epsilon)
        {
            this.f = f;
            this.a = a;
            this.b = b;
            this.epsilon = epsilon;
        }
        protected abstract double Kernel(double a, double b);
        public double Integrate()
        {
            Debug.WriteLine("+++++++++++++++++++++++");
            double integral = Kernel(a, b);
            Debug.WriteLine($"Subintervals=1; sum={integral}");
            int subintervals = 1;
            double progress;
            do
            {
                subintervals *= 2;
                double sum = 0;
                double spacing = (this.b - this.a) / subintervals;
                Debug.WriteLine("***********************");
                Debug.WriteLine($"Divide into {subintervals} subregions");
                for (int i = 0; i < subintervals; i++)
                {
                    double contribution = Kernel(a + i * spacing, a + (i + 1) * spacing);
                    Debug.WriteLine($"[{a + i * spacing}; {a + (i + 1) * spacing}] ==> {contribution}");
                    sum += contribution;
                }
                Debug.WriteLine($"Subintervals={subintervals}; sum={sum}");
                progress = integral - sum;
                integral = sum;
            }
            while (progress > this.epsilon);
            Debug.WriteLine("--------------------------");
            return integral;
        }
    }
}
