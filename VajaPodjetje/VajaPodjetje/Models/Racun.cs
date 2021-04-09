using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VajaPodjetje.Models
{
    public class Racun
    {
        public int Id { get; set; }
        public decimal Vrednost { get; set; }
        public DateTime DatumIzdaje { get; set; }
        public int KupecId { get; set; }
        //navigation property
        public Kupec Kupec { get; set; }
    }
}