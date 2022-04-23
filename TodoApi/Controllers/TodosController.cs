using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Data;
using AutoMapper;
using TodoApi.Dtos;
using Microsoft.AspNetCore.JsonPatch;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("[action]")]
    //[Route("api/todos")]
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

        // GET api/todos/{days}
        [HttpGet("{days}")]
        public ActionResult<IEnumerable<TodoReadDto>> GetUpcomingTodos(double days)
        {
            var upcomingTodos = _repository.GetUpcomingTodos(days);

            return Ok(_mapper.Map<IEnumerable<TodoReadDto>>(upcomingTodos));
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

        // PUT api/todos/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTodo(int id, TodoUpdateDto todoUpdateDto)
        {
            var todoFromRepo = _repository.GetTodoById(id);
            if (todoFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(todoUpdateDto, todoFromRepo);

            _repository.UpdateTodo(todoFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        // PUT api/todos/{id}
        [HttpPut("{id}")]
        public ActionResult CompleteTodo(int id)
        {
            var todoFromRepo = _repository.GetTodoById(id);
            if (todoFromRepo == null)
            {
                return NotFound();
            }

            _repository.CompleteTodo(todoFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        // PUT api/todos/{id}
        [HttpPut("{id}")]
        public ActionResult ProgressTodo(int id, int progress)
        {
            var todoFromRepo = _repository.GetTodoById(id);
            if (todoFromRepo == null)
            {
                return NotFound();
            }

            _repository.ProgressTodo(todoFromRepo, progress);
            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/todos/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialTodoUpdate(int id, JsonPatchDocument<TodoUpdateDto> patchDoc)
        {
            var todoFromRepo = _repository.GetTodoById(id);
            if (todoFromRepo == null)
            {
                return NotFound();
            }

            var todoToPatch = _mapper.Map<TodoUpdateDto>(todoFromRepo);
            patchDoc.ApplyTo(todoToPatch, ModelState);
            if(!TryValidateModel(todoToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(todoToPatch, todoFromRepo);

            _repository.UpdateTodo(todoFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/todos/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var todoFromRepo = _repository.GetTodoById(id);
            if (todoFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteTodo(todoFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
