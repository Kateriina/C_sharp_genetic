using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genetic_algorithm
{
    public class GenerationKeeper
    {
        private static Random _rnd = new Random();

        //vozvrashaet potomkov list
        public List<Chromosomes> Crossingover(Chromosomes x, Chromosomes y)
        {
            //mutaciya hromosom x and y
            x.Mutation();
            y.Mutation();

            //dlya randomnoj tochki razriva
            int a = _rnd.Next(1, 7);
            int b = size - a;


            //ya hochu vernut dve hromosomi - odna hrom x0y1, vtoraya y0x1

            Chromosomes x0y1 = new Chromosomes(x.X.GetRange(0, a).Concat(y.X.GetRange(a, b)).ToList());

            Chromosomes y0x1 = new Chromosomes(y.X.GetRange(0, a).Concat(x.X.GetRange(a, b)).ToList());

            return new List<Chromosomes>(){ x0y1, y0x1};
        }

        //mne nuzhno sdelat' populyaciyu
        public List<int> Population { get; set; }
        public void CreateNewPopulation()
        {
            Population = new List<int>();

            Chromosomes chrom = new Chromosomes();
            Population.Add(chrom);

        }

    }
}
