using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TrgovinaWebAPI.Models;

namespace TrgovinaWebAPI.Data
{
    public class TrgovinaWebAPIContextInitializer:DropCreateDatabaseIfModelChanges<TrgovinaWebAPIContext>
    {
        protected override void Seed(TrgovinaWebAPIContext context)
        {
            var p = new List<Product>()
            {
                new Product(){Name="Juha",Price=1.39M,ActualCost=0.99m},
                new Product(){Name="Kladivo",Price=16.99M,ActualCost=10},
                new Product(){Name="Žoga",Price=6.99M,ActualCost=2.05m}
            };
            foreach (var x in p)
                context.Products.Add(x);
            // p.ForEach(x => context.Products.Add(x)); //enaka stvar
            context.SaveChanges();

            var order = new Order() { Customer = "Bob" };
            var od = new List<OrderDetail>()
            {
                new OrderDetail(){Product=p[0],Quantity=2,Order=order},
                new OrderDetail(){Product=p[1],Quantity=4,Order=order}
            };
            context.Orders.Add(order);
            od.ForEach(y => context.OrderDetails.Add(y));
            context.SaveChanges();
        }
    }
}