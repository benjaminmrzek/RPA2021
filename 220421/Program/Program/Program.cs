using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
            Console.ReadLine();

        }

        private static async Task RunAsync()
        {
            HttpClient klient = new HttpClient();
            klient.BaseAddress = new Uri("http://localhost:57926/");
            klient.DefaultRequestHeaders.Accept.Clear();
            klient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            HttpResponseMessage odgovor = await klient.GetAsync("api/Product");
            if (odgovor.IsSuccessStatusCode)
            {
                List<Product> pr = await odgovor.Content.ReadAsAsync<List<Product>>();
                foreach (var p in pr)
                {
                    Console.WriteLine(p.Ime + " " + p.Kategorija + " " + p.Cena);
                }
            }
            Console.ReadLine();
            
        }
    }
}
