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
    public class DependentsController : ControllerBase
    {
        private readonly TableComandContext _context;
        public DependentsController(TableComandContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult CadDependents(DependentsDTO dependent)
        {
            try
            {
                var post = new Dependents
                {
                    dependentType = dependent.dependentType,
                    name = dependent.name,
                    lastName = dependent.lastName,
                    clientId = dependent.clientId
                };

                _context.Add(post);
                _context.SaveChanges();
                return Ok("Registration Complete!");
            }
            catch (Exception ex)
            {

                return BadRequest("An error occurred when registering the dependent.");
            }
        }

    }
}