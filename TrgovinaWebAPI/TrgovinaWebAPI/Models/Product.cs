using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrgovinaWebAPI.Models
{
    public class Product
    {
        [ScaffoldColumn(false)] // s tem postane ID identity
        //podamo spremenljivko ID, ker potem avtomatsko zazna to kot ključ
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal ActualCost { get; set; }
    }
}