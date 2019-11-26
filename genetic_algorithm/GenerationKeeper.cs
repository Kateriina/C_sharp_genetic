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
        public List<Organism> Crossingover(Organism x, Organism y)
        {
            //dlya randomnoj tochki razriva
            int a = _rnd.Next(1, Organism.size - 1);
            int b = Organism.size - a;


            //ya hochu vernut dve hromosomi - odna hrom x0y1, vtoraya y0x1

            Organism x0y1 = new Organism(x.chromosome.GetRange(0, a).Concat(y.chromosome.GetRange(a, b)).ToList());

            Organism y0x1 = new Organism(y.chromosome.GetRange(0, a).Concat(x.chromosome.GetRange(a, b)).ToList());

            return new List<Organism>(){ x0y1, y0x1};
        }

        //mne nuzhno sdelat' populyaciyu

        
        public List<Organism> population { get; private set; }

        public void CreateNewPopulation(int initial_count)
        {
            population = new List<Organism>();
            for (int n = 0; n < initial_count; n++)
            {
                population.Add(new Organism());
            }
        }
        
        public void Generation()
        {
            var copy = population.ToArray<Organism>();

            for (int parent1_index = 0; parent1_index < copy.Length - 1; parent1_index++)
            {
                for (int parent2_index = parent1_index + 1 ; parent2_index < copy.Length; parent2_index++)
                {
                    var childs = Crossingover(copy[parent1_index], copy[parent2_index]);
                    
                    foreach (var child in childs)
                    {
                        child.Mutate();
                        population.Add(child);
                    }
                    
                }
            }
            
        }

        public void Selection(IComparer<Organism> comparer)
        {
            population.Sort(comparer);

            population = population.GetRange(0, population.Count / 2);
        }

        public override string ToString()
        {
            var ret = "";
            foreach(var organism in population)
            {
                ret += $"{organism} ";
            }

            return ret;
        }
    }
}
