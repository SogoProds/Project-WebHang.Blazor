using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    [Route("api/[todo]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (_context.TodoWords.Count() == 0)
            {
                // Create a new TodoWord if collection is empty,
                // which means you can't delete all TodoWords.
                _context.TodoWords.Add(new TodoWord { Word = "Word1" });
                _context.SaveChanges();
            }
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoWord>>> GetTodoWords()
        {
            return await _context.TodoWords.ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoWord>> GetTodoWord(int id)
        {
            var todoWord = await _context.TodoWords.FindAsync(id);

            if (todoWord == null)
            {
                return NotFound();
            }

            return todoWord;
        }
    }
}