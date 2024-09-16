using FirstDescendantMVC.Models;
using FirstDescendantMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FirstDescendantMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        public ProductsController(ApplicationDbContext context,IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        public IActionResult Index()
        {
            var products=context.Products.OrderByDescending(x=>x.Id).ToList();  
            return View(products);
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(ProductDto productDto)
        {
            if (productDto.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "The image file is required");
            }
            if (!ModelState.IsValid)
            {
                return View(productDto);
            }
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(productDto.ImageFile!.FileName);
            string imageFullPath = environment.WebRootPath + "/products/" + newFileName;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                productDto.ImageFile.CopyTo(stream);
            }
            var product = new Product()
            {
                Name = productDto.Name,
                Rarity = productDto.Rarity,
                Category = productDto.Category,
                Price = productDto.Price,
                Description = productDto.Description,
                ImageFileName = newFileName,
                CreatedAt = DateTime.Now,
            };
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index");

            }
            var productDto = new ProductDto()
            {
                Name = product.Name,
                Rarity = product.Rarity,
                Category = product.Category,
                Price = product.Price,
                Description = product.Description,


            };
            ViewData["ImageFileName"] = product.ImageFileName;
            ViewData["ProductId"] = product.Id;
            ViewData["CreatedAt"] = product.CreatedAt.ToString("MM/dd/yyyy");
            return View(productDto);
        }
    }
}
