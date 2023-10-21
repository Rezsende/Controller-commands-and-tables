using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
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
        .Include(c => c.Andress) 
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
            name = dependent.name,
            clientId = dependent.clientId
        }).ToList(),
        Andress = client.Andress != null ? new AnddressDTO
        {
            city = client.Andress.city,
            neighborhood = client.Andress.neighborhood,
            road = client.Andress.road,
            number = client.Andress.number,
            complement = client.Andress.complement,
            clientId = client.Andress.clientId
        } : null
    }).ToList();

    return Ok(clientData);
}

        [HttpGet("{id}")]
        public IActionResult SeachClientId(int id)
        {
            var client = _context.Clients.Include(d => d.dependents).FirstOrDefault(c => c.id == id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }


        [HttpPost]
        public IActionResult CadCliente(ClientDto c)
        {
            var client = new Client
            {
                name = c.name,
                lastName = c.lastName,
                CPF = c.CPF,
                RG = c.RG
            };

            _context.Add(client);
            _context.SaveChanges();

            return Ok(c);

        }

    }
}