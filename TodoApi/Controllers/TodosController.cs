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
        private readonly ITodoRepo _repository;

        public TodosController(ITodoRepo repository)
        {
            _repository = repository;
        }
        
        // GET: api/todos
        [HttpGet]
        public ActionResult<IEnumerable<Todo>> GetAllTodos()
        {
            var allTodos = _repository.GetTodos();

            return Ok(allTodos);
        }

        // GET api/todos/{id}
        [HttpGet("{id}")]
        public ActionResult<Todo> GetTodoById(int id)
        {
            var todoItem = _repository.GetTodoById(id);

            return Ok(todoItem);
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
