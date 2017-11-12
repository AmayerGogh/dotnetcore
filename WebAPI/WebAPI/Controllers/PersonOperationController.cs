using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/PersonOperation")]
    public class PersonOperationController : Controller
    {
        private readonly DataContext _context;

        public PersonOperationController(DataContext context)
        {
            _context = context;

            if (_context.Persons.Count() == 0)
            {
                _context.Persons.Add(new Person { Id=new Guid(),Name="zhangsan",Age=18});
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Person> GetAll()
        {
            return _context.Persons.ToList();
        }

        [HttpGet("{id}", Name = "GetPerson")]
        public IActionResult GetById(Guid id)
        {
            var item = _context.Persons.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Persons.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetPerson", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Person item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var todo = _context.Persons.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Age = item.Age;
            todo.Name = item.Name;

            _context.Persons.Update(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var todo = _context.Persons.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}