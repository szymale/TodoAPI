using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Data;
using AutoMapper;
using TodoApi.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepo _repository;
        private readonly IMapper _mapper;

        public TodosController(ITodoRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        // GET: api/todos
        [HttpGet]
        public ActionResult<IEnumerable<TodoReadDto>> GetAllTodos()
        {
            var allTodos = _repository.GetTodos();

            return Ok(_mapper.Map<IEnumerable<TodoReadDto>>(allTodos));
        }

        // GET api/todos/{id}
        [HttpGet("{id}")]
        public ActionResult<TodoReadDto> GetTodoById(int id)
        {
            var todoItem = _repository.GetTodoById(id);
            if(todoItem != null)
            {
                return Ok(_mapper.Map<TodoReadDto>(todoItem));
            }

            return NotFound();
        }

        // POST api/todos
        [HttpPost]
        public ActionResult<TodoReadDto> CreateTodo(TodoCreateDto todoCreateDto)
        {
            if (todoCreateDto is null)
            {
                throw new ArgumentNullException(nameof(todoCreateDto));
            }

            var todoModel = _mapper.Map<Todo>(todoCreateDto);
            _repository.CreateTodo(todoModel);
            _repository.SaveChanges();

            var todoReadDto = _mapper.Map<TodoReadDto>(todoModel);

            return CreatedAtAction(nameof(GetTodoById), new {Id = todoReadDto.Id}, todoReadDto);
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
