﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace genetic_algorithm
{
    /*class cv
    {
        public static int binary(string a)
        {
            
            int c = Convert.ToInt32(a, 2);

            return c;
        }

     
    }*/


    public class MinimumComparer : IComparer<Organism>
    {
        private Func<double, double> function;

        public MinimumComparer(Func<double, double> function)
        {
            this.function = function;
        }

        public static IComparer<Organism> Create(Func<double, double> function)
        {
            return new MinimumComparer(function);
        }

        public int Compare(Organism x, Organism y)
        {
            var value1 = function(x.Value);
            var value2 = function(y.Value);
            return value1 > value2 ? 1 : value2 > value1 ? -1 : 0;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine($"ArgMin((x + 1)^2) = {FindMinimum((x) => (x + 1) * (x + 1))}");

            Console.WriteLine($"ArgMin((x - 1)^2) = {FindMinimum((x) => (x - 1) * (x - 1))}");

            Console.WriteLine($"ArgMin(x^2) = {FindMinimum((x) => x * x)}");
        }


        static double FindMinimum(Func<double, double> func) {
            var comparer = new MinimumComparer(func);
            GenerationKeeper keeper = new GenerationKeeper();

            keeper.CreateNewPopulation(2);
            Console.WriteLine(keeper);

            for (var n = 0; n <= 100; n++)
            {
                keeper.Generation();
                keeper.Selection(comparer);
            }

            return keeper.population[0].Value;
        }
    }
}

