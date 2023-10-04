using Microsoft.AspNetCore.Mvc;
using TableandCommandControl.Context;
using TableandCommandControl.DTO;
using TableandCommandControl.Entity;

namespace TableandCommandControl.Controller
{
    [Route("[controller]")]
    public class TableController : ControllerBase
    {
        private readonly TableComandContext _context;
        public TableController(TableComandContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IActionResult TableList(){
            
            var table = _context.TableCommands.ToList();
            return Ok(table);
        }
        [HttpPost]
        public IActionResult TableInsert([FromBody] TableDto tableDto)
        {
            if (tableDto == null)
            {
                return BadRequest("Invalid data for new table.");
            }

            var newTable = new TableCommand
            {
                description = tableDto.description,
                Status = tableDto.status,
            };

            var res = new{
                Messagem = "Table registered successfully!",
               
            };

            _context.TableCommands.Add(newTable);
            _context.SaveChanges();


            return Ok(res);
        }

    }


}