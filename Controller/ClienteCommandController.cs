using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TableandCommandControl.Context;
using TableandCommandControl.DTO;
using TableandCommandControl.Entity;

namespace TableandCommandControl.Controller
{
    [Route("[controller]")]
    public class ClienteCommandController : ControllerBase
    {
        private readonly TableComandContext _context;

        public ClienteCommandController(TableComandContext context)


        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ListClient()
        {
            var clients = _context.Clients
                .Include(c => c.dependents)
                .ToList();

            var clientData = clients.Select(client => new
            {
                id = client.id,
                name = client.name,
                lastName = client.lastName,
                cpf = client.CPF,
                rg = client.RG,
                dependents = client.dependents.Select(dependent => new
                {
                    id = dependent.id,
                    dependentType = ((DependentType)dependent.dependentType).ToString(),
                    clientId = dependent.clientId
                }).ToList()
            }).ToList();

            return Ok(clientData);
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody]ClientDto clientDto){

            var cad = new Client{
                name = clientDto.name,
                lastName = clientDto.lastName,
                CPF = clientDto.CPF,
                RG = clientDto.RG

            };


            _context.Clients.Add(cad);
            _context.SaveChanges();

            var res = new {
               Menssage = "customer registered successfully!",
               ClietCad =  cad,
            };

            return Ok(res);
        }

    }
}