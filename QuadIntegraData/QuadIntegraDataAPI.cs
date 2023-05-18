﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuadIntegraData
{
    internal class QuadIntegraDataAPI : QuadIntegraAbstractDataAPI
    {
        private string pathGL = "legendre.txt";
        private Func<double, double>[] functions =
        {
            new Func<double, double>((double x) => (3*x-5)),
            new Func<double, double>((double x) => Math.Abs(x)),
            new Func<double, double>((double x) => x*(x*(x+1)-2)-1),
            new Func<double, double>((double x) => Math.Cos(x)),
            new Func<double, double>((double x) => Math.Cos(2*x*x)*Math.Cos(2*x*x)-Math.Abs(Math.Sin(x*x))),
            new Func<double, double>((double x) => Math.Sin(Math.Abs(x+1))+Math.Abs(x)*(Math.Abs(x)*Math.Abs(x)-1))
        };
        public QuadIntegraDataAPI() : base() { }

        public override Func<double, double> GetFunction(int index)
        {
            return this.functions[index];
        }

        public override (double, double)[] GetGLQuadratureData(int quadratureNodesNumber, double a, double b)
        {
            if (quadratureNodesNumber < 2) throw new ArgumentException();
            (double, double)[] data = new (double, double)[quadratureNodesNumber];
            using (TextReader reader = File.OpenText(this.pathGL))
            {
                for(int i=2; i<quadratureNodesNumber; i++)
                {
                    for (int j = 0; j < i + 2; j++) reader.ReadLine();
                }
                reader.ReadLine();
                RegexOptions options = RegexOptions.None;
                Regex regex = new Regex("[ ]{2,}", options);
                for (int i=0; i<quadratureNodesNumber; i++)
                {
                    string? line = reader.ReadLine();
                    if (line == null) throw new NullReferenceException();
                    
                    line = regex.Replace(line, " ");
                    string[] lineParts = line.Split(' ');
                    char culprit = Convert.ToChar(0x2E);
                    //Debug.WriteLine($"{lineParts[0]} & {lineParts[2]}");
                    data[i] = (a+0.5*(Convert.ToDouble(lineParts[1].Replace(culprit,','))+1)*(b-a), Convert.ToDouble(lineParts[2].Replace(culprit,',')));
                }
            }
            return data;
        }
    }
}