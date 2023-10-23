using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TableandCommandControl.Context;
using TableandCommandControl.DTO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TableandCommandControl.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CommandaController : ControllerBase
    {
        private readonly TableComandContext _context;

        public CommandaController(TableComandContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getCommand()
        {
            var get = _context.Commands.ToList();
            return Ok(get);
        }
        [HttpPost]
        public IActionResult postCommand(CommandDTO command)
        {
            var  post = new Entity.Command
            {
                    description = command.description
            };
            _context.Add(post);
            _context.SaveChanges();
            return Ok("Command created successfully!");
        }
    }
}