using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace genetic_algorithm
{
    class cv
    {
        public static int binary(string a)
        {
            
            int c = Convert.ToInt32(a, 2);

            return c;
        }

     
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(cv.binary("101010")); //trenirovka perevoda iz sistemi v sistemu schisleniya

            Chromosomes chroms = new Chromosomes(10);

            Console.WriteLine(chroms.ToString());   //proverka, kak rabotaet zapis v spisok

            Console.WriteLine(chroms.Value);    //vivod desyatichnogo chisla

            //mutaciya 10 genov
             for (int n = 0; n <= 10; n++)
             {
                 chroms.Mutation();
                 Console.WriteLine(chroms.ToString());
             }
             

        }
    }
}


