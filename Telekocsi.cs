using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Telekocsi
{
    class Telekocsi
    {
        public static List<Igeny> igenyek = new List<Igeny>();
        public static List<Jarat> jaratok = new List<Jarat>();

        static void Main(string[] args)
        {

            Console.WriteLine("A program kezdődik...");

            Console.WriteLine("1. feladat: \n \t Beolvasás");
            Beolvas();

            Console.WriteLine($"2. feladat: \n \t" +jaratok.GroupBy(a => a.rendszam).Distinct().Count()+" autós hirdetett fuvart");

            int ferohely = jaratok.Where(x => x.indulas == "Budapest" && x.cel == "Miskolc").Select(x => x.ferohely).Sum();
            Console.WriteLine($"3. feladat:\n\tÖsszesen {ferohely} férőhelyet hirdettek az autósok Budapestről Miskolcra");

            var max = jaratok.OrderByDescending(a => a.ferohely).First();
            Console.WriteLine($"4. feladat: \n \t A legtöbb férőhelyet " + max.indulas + " - " + max.cel + " útvonalon kínálták " + max.ferohely + " hellyel");

            Dictionary<Igeny, Jarat> matches = new Dictionary<Igeny, Jarat>();
            foreach (var igeny in igenyek)
            {
                foreach (var jarat in jaratok)
                {
                    if (!(matches.ContainsKey(igeny)) &&
                        (igeny.cel == jarat.cel && igeny.indulas == jarat.indulas && igeny.szemlyek <= jarat.ferohely))
                    {
                        matches.Add(igeny, jarat);
                    }
                }
            }
            Console.WriteLine("5. feladat: \n \t");
            foreach (var item in matches)
            {
                Console.WriteLine("\t " + item.Key.azonosito + " ---> " + item.Value.rendszam);
            }
            Console.WriteLine("6. feladat: utasuzenetek.txt");
            using (StreamWriter sw = new StreamWriter("utasuzenetek.txt"))
            {
                foreach (var item in igenyek)
                {
                    if (matches.ContainsKey(item))
                    {
                        sw.WriteLine(item.azonosito + ": Rendszám: " + matches[item].rendszam + ", Telefonszám: " + matches[item].telszam);
                    }
                    else
                    {
                        sw.WriteLine(item.azonosito + ": Sajnos nem sikerült autót találni");
                    }
                }
            }



            Console.WriteLine("A program vége.");
            Console.ReadKey();
        }

        public static void Beolvas()
        {
            foreach (var item in File.ReadLines("autok.csv").Skip(1))
            {
                jaratok.Add(new Jarat(item));
            }
            foreach (var item in File.ReadLines("igenyek.csv").Skip(1))
            {
                igenyek.Add(new Igeny(item));
            }
        }


    }
}
