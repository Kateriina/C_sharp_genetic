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
            //ya hochu vernut dve hromosomi - odna hrom x0y1, vtoraya y0x1

            Chromosomes x0y1 = new Chromosomes(x.X.GetRange(0, 4).Concat(y.X.GetRange(4, 4)).ToList());

            Chromosomes y0x1 = new Chromosomes(y.X.GetRange(0, 4).Concat(x.X.GetRange(4, 4)).ToList());

            return new List<Chromosomes>(){ x0y1, y0x1};
        }
        

    }
}
