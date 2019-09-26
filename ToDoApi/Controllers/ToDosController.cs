using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Contexts;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : Controller
    {
        private readonly ToDoContext _context;

        public ToDosController(ToDoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetToDos()
        {
            return Ok(_context.ToDos);
        }


        [HttpGet("{id}")]
        public IActionResult GetToDo(int id)
        {
            var toDo = _context.ToDos.FirstOrDefault(x => x.Id == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return Ok(toDo);
        }

        [HttpPost]
        public IActionResult CreateToDo([FromBody] ToDo toDo)
        {

            _context.ToDos.Add(toDo);
            _context.SaveChanges();

            return Created("", toDo);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateToDo(int id, [FromBody] ToDo toDo)
        {
            var existing =  _context.ToDos.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (existing == null)
            {
                return NotFound();
            }
            
            _context.Update(toDo);
            _context.SaveChanges();

            return Ok(toDo);
        }

        [HttpPut("{id}/toggle")]
        public IActionResult ToggleComplete(int id)
        {
           var toDo =  _context.ToDos.FirstOrDefault(x => x.Id == id);

           if (toDo == null)
           {
               return NotFound();
           }
           
           toDo.IsDone = !toDo.IsDone;
           _context.Update(toDo);
           _context.SaveChanges();

           return Ok(toDo);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteToDo(int id)
        {
            var toDo = _context.ToDos.FirstOrDefault(x => x.Id == id);

            if (toDo == null)
            {
                return NotFound();
            }
            _context.Remove(toDo);
            _context.SaveChanges();

            return NoContent();
        }
        
        
    }
}