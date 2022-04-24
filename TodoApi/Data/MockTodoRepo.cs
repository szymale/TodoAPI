using TodoApi.Models;

namespace TodoApi.Data
{
    public class MockTodoRepo : ITodoRepo
    {
        public void CompleteTodo(Todo todo)
        {
            if (todo is null)
            {
                throw new ArgumentNullException(nameof(todo));
            }
            var todoToComplete = GetTodoById(0);
            if (todoToComplete != null)
            {
                todoToComplete.IsFinished = true;
            }

        }

        public void CreateTodo(Todo todo)
        {
            if (todo is null)
            {
                throw new ArgumentNullException(nameof(todo));
            }

            Todo createTodo = new Todo();
            createTodo.Title = todo.Title;
            createTodo.Description = todo.Description;
            createTodo.ExpiryTime = todo.ExpiryTime;
            createTodo.Progress = todo.Progress;
            createTodo.IsFinished = todo.IsFinished;
            createTodo.Overdue = todo.Overdue;
        }

        public void DeleteTodo(Todo todo)
        {
            // nothing
        }

        public Todo? GetTodoById(int id)
        {
            if (id == 0)
            {
                return new Todo { Id = 0, Title = "Todo item", Description = "tesk description", ExpiryTime = DateTime.Now.AddDays(14), Progress = 10 };
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Todo> GetTodos()
        {
            var todos = new List<Todo>()
            {
                new Todo { Id = 0, Title = "Todo item 0", Description = "tesk description 1", ExpiryTime = DateTime.Now.AddDays(14) },
                new Todo { Id = 1, Title = "Todo item 1", Description = "tesk description 2", ExpiryTime = DateTime.Now.AddDays(10) },
                new Todo { Id = 2, Title = "Todo item 3", Description = "tesk description 3", ExpiryTime = DateTime.Now.AddDays(7) }
            };

            return todos;
        }

        public IEnumerable<Todo> GetUpcomingTodos(double days)
        {
            if (days != 0)
            {
                return GetTodos().Where(t => t.ExpiryTime <= DateTime.UtcNow.AddDays(days)).ToList();
            }

            throw new ArgumentException(nameof(days));
        }

        public void ProgressTodo(Todo todo, int progress)
        {
            if (todo is null)
            {
                throw new ArgumentNullException(nameof(todo));
            }

            var todoProgress = GetTodoById(0);
            if (todoProgress != null)
            {
                todoProgress.Progress = progress;
            }

        }

        public bool SaveChanges()
        {
            // nothing
            return true;
        }

        public void UpdateTodo(Todo todo)
        {
            // nothing
        }
    }
}
