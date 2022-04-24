using TodoApi.Models;

namespace TodoApi.Data
{
    public class MockTodoRepo : ITodoRepo
    {
        public void CompleteTodo(Todo todo)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void ProgressTodo(Todo todo, int progress)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateTodo(Todo todo)
        {
            throw new NotImplementedException();
        }
    }
}
