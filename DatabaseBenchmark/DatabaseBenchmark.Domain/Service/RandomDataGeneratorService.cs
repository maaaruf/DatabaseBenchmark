using DatabaseBenchmark.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DatabaseBenchmark.Domain.Service
{
    public class RandomDataGeneratorService
    {
        public IList<Product> Products { get; set; }

        public IList<Product> generateProducts(int productCount)
        {
            IList<Product> Products = new List<Product>();

            for(int i=0; i<productCount; i++)
            {
                Products.Add(
                    new Product
                    {
                        Id = DateTime.Now.Ticks,
                        Tittle = "Object" + i,
                        Brand = "Brand" + i,
                        Price = i
                    }) ;
            }

            return Products;
        }

        public IList<Product> generate50Products()
        {
            return generateProducts(50);
        }

    }




}
