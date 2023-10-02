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

        [HttpGet]
        public IActionResult CompleteCommand()
        {
            var commands = _context.Commands
                .Include(c => c.client)
               .Include(p => p.products).ThenInclude(a => a.ProductCommands)
                .Include(m => m.table)
                .ToList();

            var listProducts = commands.Select(p => new
            {
                Idcommand = p.id,
                command = p.description,
                client = p.client,
                listProductCommand = p.products.Select(produto => new
                {
                    id = produto.id,
                    description = produto.description,
                    Value = produto.SaleValue,
                    qtd = produto.ProductCommands.Qtd,
                    SubTotal = produto.ProductCommands.Qtd * produto.SaleValue,
                }
                ).ToList(),
             
                table = new TableDTO{
                    id = p.table.id,
                   description = p.table.description,
                   scheduling = p.table.scheduling

                },
                totalGrade = p.products.Sum(produto=> produto.ProductCommands.Qtd * produto.SaleValue) 
            }).ToList();

            return Ok(listProducts);
        }
    }
}