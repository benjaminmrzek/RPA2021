using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsinhroniTaski
{
    class Coffee { }
    class Bacon { }
    class Toast { }
    class Juice { }
    class Egg { }

    class Program
    {
        static void Main(string[] args)
        {
            Glavna().Wait();
        }
        static async Task Glavna()
        {
            //asinhrono izvajanje
            Coffee cup = SkuhajKavo();
            Task<Egg> jajca = CvriJajca(2);
            Task<Bacon> slanina = SpeciSlanino(3);
            Task<Toast> t = NarediToast(2);
            Juice sok = Stisni();
            Console.WriteLine("Sok je pripravljen");
            await Task.WhenAll(jajca, slanina, t);

            Console.WriteLine("Jajca so cvrta");
            Console.WriteLine("Slanina je cvrta");
            Console.WriteLine("Toasti so peceni");

            Console.WriteLine("Zajtrk je na mizi");
            Console.ReadLine();
        }
        
        private static Juice Stisni()
        {
            Console.WriteLine("Stiskanje pomarancnega soka");
            return new Juice();
        }
        private static async Task<Egg> CvriJajca(int kolicina)
        {
            Console.WriteLine("Segrevamo ponev...");
            await Task.Delay(3000);
            Console.WriteLine("Razbijanje " + kolicina + " jajc");
            await Task.Delay(3000);
            Console.WriteLine("Daj jajca na krožnik");
            return new Egg();
        }
        private static async Task<Toast> NarediToast(int kolicina)
        {
            for (int i = 0; i < kolicina; i++)
            {
                Console.WriteLine("Dajem peci toast");
                Console.WriteLine("Začenjam peči...");
                await Task.Delay(3000);
                Console.WriteLine("Vzemi iz toasterja");

            }
            return new Toast();
        }
        private static Coffee SkuhajKavo()
        {
            Console.WriteLine("Kuhanje kave...");
            return new Coffee();
        }
        private static async Task<Bacon> SpeciSlanino(int kolicina)
        {
            Console.WriteLine("Dodajanje " + kolicina + " kosov slanine v ponev");
            await Task.Delay(3000);
            for (int i = 0; i < kolicina; i++) {
                Console.WriteLine("Obracam kos slanine");
                Console.WriteLine("Pecem drugo stran");
            }
            await Task.Delay(3000);
            Console.WriteLine("Dajem slanino na kroznik");
            return new Bacon();
        }
    }
}
