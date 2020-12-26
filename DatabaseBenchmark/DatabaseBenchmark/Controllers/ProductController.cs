using DatabaseBenchmark.Domain.Entity;
using DatabaseBenchmark.Models;
using DatabaseBenchmark.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseBenchmark.Web.Controllers
{
    public class ProductController : Controller
    {

        public IList<Product> Products { get; set; }

        public IActionResult Index()
        {
            ProductModel productModel = new ProductModel();
            productModel.generateJsonData(10);
            return View(productModel);

            //ProductModel productModel = new ProductModel();
            //productModel.Products = Products;
            //return View(productModel);
        }

        public IActionResult Generate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Generate(ProductModel model)
        {
            Products = model.generateProduct();
            return View(model);
        }
    }
}
