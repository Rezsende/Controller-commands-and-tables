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
    public class ContactController : ControllerBase
    {
        private readonly TableComandContext _context;

        public ContactController(TableComandContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CadContact(ContactDTO contact)
        {
            var post = new Contact
            {
            phone = contact.phone,
            Email = contact.Email,
            Instagram = contact.Instagram,
            FaceBook = contact.FaceBook,
            // clientId = contact.clientId
            };

            _context.Add(post);
            _context.SaveChanges();


            return Ok(contact);
        }

    }
}