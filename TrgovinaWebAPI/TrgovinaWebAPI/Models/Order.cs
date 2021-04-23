using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrgovinaWebAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        //navigation property
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}