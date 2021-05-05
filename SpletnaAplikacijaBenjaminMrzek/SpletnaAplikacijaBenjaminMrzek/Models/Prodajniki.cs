namespace SpletnaAplikacijaBenjaminMrzek.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prodajniki")]
    public partial class Prodajniki
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Ime { get; set; }

        [StringLength(50)]
        public string Priimek { get; set; }
    }
}
