using DatabaseBenchmark.Web.Models.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DatabaseBenchmark.Models
{
    public class RandomDataGenerator
    {
        public IList<Product> Products { get; set; }

        public IList<Product> generateProducts(int productCount)
        {
            IList<Product> Products = new List<Product>();

            for(int i=0; i<productCount; i++)
            {
                Products.Add(
                    new Web.Models.Entity.Product
                    {
                        Tittle = "Object" + i + Guid.NewGuid(),
                        Brand = "Brand" + i,
                        Price = i
                    });
            }

            return Products;
        }


        
    }




}
