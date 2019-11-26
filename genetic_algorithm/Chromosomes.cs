using System;
using System.Collections.Generic;

namespace genetic_algorithm
{
    public class Chromosomes
    {
        private static Random _rnd;  // dlya randomnogo vibora bita
        static Chromosomes()
        {
            _rnd = new Random();
        }
        private int size = 8;

        public List<int> X { get; set; }

        /* public Chromosomes(int x)
         {
             X = new List<int>();

             int size = 8;
             string s = Convert.ToString(x, 2);
             int length = s.Length;

             if (length < size)
             { 
                 for (int i = 0; i < (size - length); i++)
                 {
                     X.Add(0);
                 }
             }

             for (int i = 0; i < length; i++)
             {
                 X.Add(Convert.ToInt32(s[i].ToString()));
             }
         }

             */
        public void CreateChromosome()
        {
            for (int n = 0; n < size; n++)
            {
                X.Add(_rnd.Next(2));
            }
        }

        public Chromosomes()
        {
            X = new List<int>();
            CreateChromosome();
        }
     

        public Chromosomes(List<int> list)
        {
            this.X = list;
        }

        public void Mutation()      // metod mutacii
        {
            double probability = _rnd.NextDouble();

            if (probability > 0.99)
            {
                return;
            }

            int index = _rnd.Next(8);   //8 - tak kak 8 bit

            if (X[index] == 0)
            {
                X[index] = 1;
            }
            else
            {
                X[index] = 0;
            }
            
        }
        

        public override string ToString()
        {
            string s = "";
            foreach (int item in X)
            {
                s += item;
            }
            return s;
        }


        public double Value
        {
            get
            {
                double n = 0;

                for (int i = 0, j = X.Count - 1; i <  X.Count - 1 || j >= 0; i++, j--)
                {
                    n += X[i] * Math.Pow(2, j);
                }
                
                return n;
            }
        }
    }
}
