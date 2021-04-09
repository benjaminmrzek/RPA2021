using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VajaPodjetje.Models
{
    public class Kupec
    {
        public int Id { get; set; }
        [DisplayName("Ime podjetja")]
        public string ImePodjetja { get; set; }
        [DisplayName("Kontaktna oseba")]
        [Required(ErrorMessage = "Kontaktna oseba je obvezen podatek")]
        public string Kontakt { get; set; }
        public string Telefon { get; set; }
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Vnesi veljaven e-mail naslov")]
        public string Mail { get; set; }
    }
}