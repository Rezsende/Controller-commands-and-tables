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
    public class AddressController : ControllerBase
    {
       private readonly TableComandContext _context;
       public AddressController(TableComandContext context)
       {
          _context = context;
       }

       [HttpPost]
       public IActionResult CadAndress(AnddressDTO andress)
       {

            var post = new Address {
                        city = andress.city,
                        neighborhood = andress.neighborhood,
                        road = andress.road,
                        number = andress.number,
                        complement = andress.complement,
                     
            };

            _context.Add(post);
            _context.SaveChanges();

            var response = new {
              Messager =  "Address registered successfully!",
              Result = post
            
            };
            
            return Ok(response);
             
       }
    }
}