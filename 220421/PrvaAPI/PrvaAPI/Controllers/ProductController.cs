using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PrvaAPI.Models;

namespace PrvaAPI.Controllers
{
    public class ProductController : ApiController
    {
        Product[] produkti = new Product[]
        {
            new Product{Id=1,Ime="Juha",Kategorija="Jestvina",Cena=1},
            new Product{Id=2,Ime="Žoga",Kategorija="Igrače",Cena=3.7m},
            new Product{Id=3,Ime="Kladivo",Kategorija="Orodja",Cena=16.99m},
        };

        public IEnumerable<Product> GetProDucts()
        {
            return produkti;
        }
        public IHttpActionResult GetProduct(int Id)
        {
            var p = produkti.Where(e => e.Id == Id).FirstOrDefault();
            if (p == null)
                return NotFound();
            return Ok(p);
           
        }

    }
}
