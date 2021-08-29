using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todoist.Repository;
using Todoist.Model;
using Microsoft.EntityFrameworkCore;
using Todoist.DTO;

namespace Todoist.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private TodoistRepository TodoistRepository;

        public TodoController(TodoistRepository todoistRepository) => TodoistRepository = todoistRepository;

        [HttpGet]
        public async Task<List<Todo>> GetTodos()
        {
            var todos = await TodoistRepository.Todos.ToListAsync();
            return todos;
        }

        [HttpPost]
        public async Task<Todo> CreateTodo([FromBody] TodoDTO todoDTO)
        {
            var todo = Todo.CreateInstance(todoDTO);
            TodoistRepository.Add(todo);
            await TodoistRepository.SaveChangesAsync();
            return todo;
        }
    }
}
