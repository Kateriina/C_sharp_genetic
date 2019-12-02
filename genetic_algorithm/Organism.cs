using System;
using System.Collections.Generic;

namespace genetic_algorithm
{
    public class Organism
    {
        private static Random _rnd = new Random();  // dlya randomnogo vibora bita
        public const int size = 33;

        public Organism()
        {
            chromosome = new List<int>();
            CreateChromosome();
        }


        public Organism(List<int> list)
        {
            this.chromosome = list;
        }


        public List<int> chromosome { get; set; }
        
        public void CreateChromosome()
        {
            for (int n = 0; n < size; n++)
            {
                chromosome.Add(_rnd.Next(2));
            }
        }

        public void Mutate()      // metod mutacii
        {
            double probability = _rnd.NextDouble();

            if (probability > 0.99)
            {
                return;
            }

            int index = _rnd.Next(size);   //8 - tak kak 8 bit

            if (chromosome[index] == 0)
            {
                chromosome[index] = 1;
            }
            else
            {
                chromosome[index] = 0;
            }
            
        }
        

        public override string ToString()
        {
            string s = "";

            foreach (int item in chromosome)
            {
                s += item;
            }

            return $"{Value}[{s}]";
        }


        public double Value
        {
            get
            {
                double n = 0;

                for (int i = 0, j = size - 2; i < size - 2 || j >= 0; i++, j--)
                {
                    n += chromosome[i] * Math.Pow(2, j);
                }

                return n * (chromosome[size - 1] == 0 ? 1.0 : -1.0);
            }
        }
    }
}
