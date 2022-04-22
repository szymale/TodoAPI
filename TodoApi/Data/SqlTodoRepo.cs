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

        public void CreateTodo(Todo todo)
        {
            if(todo is null) 
            {
                throw new ArgumentNullException(nameof(todo));
            }

            _context.Todos.Add(todo);
        }

        public void UpdateTodo(Todo todo)
        {
            //Nothing
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);            
        }

    }
}
