using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TableandCommandControl.Context;
using TableandCommandControl.DTO;

namespace TableandCommandControl.Controller
{
    [Route("[controller]")]
    public class CommandController : ControllerBase
    {
        private readonly TableComandContext _context;
        public CommandController(TableComandContext context)
        {
            _context = context;
        }

        [HttpGet("/ListCommand")]
        public IActionResult CompleteCommand()
        {
            var commands = _context.Commands
                .Include(c => c.client)
                 .Include(p => p.products).ThenInclude(a => a.ProductCommands)
                .Include(p => p.products)
                .Include(m => m.table)
                .ToList();

            var listProducts = commands.Select(p => new
            {
                Idcommand = p.id,
                command = p.description,
                client = p.client,
                listProductCommand = p.products.Select(product => new
                {
                    id = product.id,
                    description = product.ProductCommands.description,

                    qtd = product.ProductCommands.Qtd,
                    Value = product.ProductCommands.SaleValueCommand,
                    SubTotal = product.ProductCommands.Qtd * product.ProductCommands.SaleValueCommand,
                }
                ).ToList(),

                table = new TableDTO
                {
                    id = p.table.id,
                    description = p.table.description,
                    scheduling = p.table.scheduling

                },
                totalGrade = p.products.Sum(product => product.ProductCommands.Qtd * product.ProductCommands.SaleValueCommand)
            }).ToList();

            return Ok(listProducts);
        }
   
   
[HttpGet("/ListCommand/{idCommand}")]
public IActionResult SeachCommandId(int idCommand)
{
    var command = _context.Commands
        .Include(c => c.client)
        .Include(p => p.products).ThenInclude(a => a.ProductCommands)
        .Include(p => p.products)
        .Include(m => m.table)
        .FirstOrDefault(c => c.id == idCommand); 

    if (command == null)
    {
        return NotFound("This Command does not exist in our Database!"); 
    }

    var listProducts = new
    {
        Idcommand = command.id,
        command = command.description,
        client = command.client,
        listProductCommand = command.products.Select(product => new
        {
            id = product.id,
            description = product.ProductCommands.description,
            qtd = product.ProductCommands.Qtd,
            Value = product.ProductCommands.SaleValueCommand,
            SubTotal = product.ProductCommands.Qtd * product.ProductCommands.SaleValueCommand,
        }).ToList(),

        table = new TableDTO
        {
            id = command.table.id,
            description = command.table.description,
            scheduling = command.table.scheduling
        },
        totalGrade = command.products.Sum(product => product.ProductCommands.Qtd * product.ProductCommands.SaleValueCommand)
    };

    return Ok(listProducts);
}

   
   
   
   
    }
}