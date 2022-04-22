using TodoApi.Models;

namespace TodoApi.Data
{
    public class SqlTodoRepo : ITodoRepo
    {
        private readonly TodoContext _context;
        public SqlTodoRepo(TodoContext context)
        {
            _context = context;
        }

        public Todo GetTodoById(int id)
        {
            return _context.Todos.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Todo> GetTodos()
        {
            return _context.Todos.ToList();
        }
    }
}
