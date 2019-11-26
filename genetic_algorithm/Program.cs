using System;
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

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(cv.binary("101010")); //trenirovka perevoda iz sistemi v sistemu schisleniya

            //create new chromosomes
            Chromosomes mother = new Chromosomes();
            Chromosomes father = new Chromosomes();

            Console.WriteLine("create new chromosomes: ");
            //mother.CreateChromosomes();
            //father.CreateChromosomes();

            Console.WriteLine($"mother: {mother}");
            Console.WriteLine($"father: {father}");
            Console.WriteLine("\n");

            // Console.WriteLine(mother.ToString());   //proverka, kak rabotaet zapis v spisok

            //  Console.WriteLine(mother.Value);    //vivod desyatichnogo chisla

            //mutaciya genov
            for (int n = 0; n <= 1; n++)
            {
                mother.Mutation();
                Console.WriteLine($"{n} mutation mother:{mother}\n");

                father.Mutation();
                Console.WriteLine($"{n} mutation father:{father}\n");
            }

            //skreschivanie
            for (int n = 0; n < 1; n++)
            {
                Console.WriteLine($"{n} crossingover:");
                GenerationKeeper utility = new GenerationKeeper();

                foreach (var element in utility.Crossingover(mother, father))
                {
                    Console.WriteLine(element);
                }
                Console.WriteLine("\n");
            }
        }
    }
}

