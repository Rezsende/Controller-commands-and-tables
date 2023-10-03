using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TableandCommandControl.Context;
using TableandCommandControl.DTO;
using TableandCommandControl.Entity;

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
                client = p.client ?? new Client(), 
                listProductCommand = p.products.Select(product => new
                {
                    id = product.id,
                    description = product.ProductCommands.description,
                    qtd = product.ProductCommands.Qtd,
                    Value = product.ProductCommands.SaleValueCommand,
                    SubTotal = product.ProductCommands.Qtd * product.ProductCommands.SaleValueCommand,
                }).ToList(),

                table = p.table ?? new Table(), 
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
                return NotFound();
            }


            var client = command.client ?? new Client();
            var table = command.table ?? new Table();

            var listProducts = new
            {
                Idcommand = command.id,
                command = command.description,
                client = client,
                listProductCommand = command.products.Select(produto => new
                {
                    id = produto.id,
                    description = produto.ProductCommands.description,
                    qtd = produto.ProductCommands.Qtd,
                    Value = produto.ProductCommands.SaleValueCommand,
                    SubTotal = produto.ProductCommands.Qtd * produto.ProductCommands.SaleValueCommand,
                }).ToList(),

                table = table,
                totalGrade = command.products.Sum(produto => produto.ProductCommands.Qtd * produto.ProductCommands.SaleValueCommand)
            };

            return Ok(listProducts);
        }






    }
}