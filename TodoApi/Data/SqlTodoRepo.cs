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

        public Todo? GetTodoById(int id)
        {
            return _context.Todos.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Todo> GetTodos()
        {
            return _context.Todos.OrderBy(todo => todo.Id).ToList();
        }

        public IEnumerable<Todo> GetUpcomingTodos(double days)
        {
            return _context.Todos.Where(t => t.ExpiryTime <= DateTime.UtcNow.AddDays(days)).ToList();
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

        public void DeleteTodo(Todo todo)
        {
            if (todo is null)
            {
                throw new ArgumentNullException(nameof(todo));
            }

            _context.Todos.Remove(todo);
        }

        public void CompleteTodo(Todo todo)
        {
            if (todo is null)
            {
                throw new ArgumentNullException(nameof(todo));
            }

            var todoToComplete = _context.Todos.FirstOrDefault(t => t.Id == todo.Id);
            if (todoToComplete != null)
            {
                todoToComplete.IsFinished = true;
            }
        }

        public void ProgressTodo(Todo todo, int progress)
        {
            if (todo is null)
            {
                throw new ArgumentNullException(nameof(todo));
            }

            var todoProgress = _context.Todos.FirstOrDefault(t => t.Id == todo.Id);
            if (todoProgress != null)
            {
                todoProgress.Progress = progress;
            }
        }
    }
}
