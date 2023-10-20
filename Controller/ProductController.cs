using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TableandCommandControl.Context;
using TableandCommandControl.DTO;
using TableandCommandControl.Entity;

namespace TableandCommandControl.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController:ControllerBase
    {
       private readonly TableComandContext _context;
       public ProductController(TableComandContext context)
       {
        _context = context;
       }

       [HttpPost]
       public IActionResult CadProduct( ProductDTO p)
       {
               var product = new Product{
                description = p.description,
                purchaseValue = p.purchaseValue,
                SaleValue = p.SaleValue,
                stock = p.stock,
                ExpirationDate = p.ExpirationDate
               };
               _context.Add(product);
               _context.SaveChanges();

               return Ok(product);
       }

       [HttpGet]
       public IActionResult GetProduct()
       {
           var product = _context.Products.ToList();

           return Ok(product);
       }
    }

  
        
}