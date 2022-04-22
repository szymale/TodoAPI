using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepo _repository  = new MockTodoRepo();

        // GET: api/todos
        [HttpGet]
        public ActionResult <IEnumerable<Todo>> GetAllTodos()
        {
            var todos = _repository.GetTodos();

            return todos;
        }

        // GET api/todos/5
        [HttpGet("{id}")]
        public string GetTodoById(int id)
        {
            return _repository.GetTodoById(id);
        }








        // POST api/<TodosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TodosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
