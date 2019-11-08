using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genetic_algorithm
{
    class GenerationKeeper
    {
        private static Random _rnd = new Random();

        public Chromosomes Crossingover(Chromosomes x, Chromosomes y)
        {
           
            int index = _rnd.Next(8);

            Chromosomes z = new Chromosomes(0);


             for (int n = 0; n < index; n++ )
             {
                 z[n] = x[n];

             }

             for (int n = (y.ToString().Length) / 2; n < y.ToString().Length); n++)
             {
                 z[n] = x[n];
             }


            return z;
        }

        public void GetGens(int min, int max, Chromosomes x, Chromosomes z)
        {
            for (int n = min; n < max; n++)
            {
                z[n] = x[n];
            }
            
        }


    }
}
