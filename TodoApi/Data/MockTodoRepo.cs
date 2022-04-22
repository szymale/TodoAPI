using TodoApi.Models;

namespace TodoApi.Data
{
    public class MockTodoRepo : ITodoRepo
    {
        public void CreateTodo(Todo todo)
        {
            throw new NotImplementedException();
        }

        public Todo GetTodoById(int id)
        {
            return new Todo { Id = 0, Title = "Todo item", Description = "tesk description", ExpiryTime = DateTime.Now.AddDays(14), Progress = 10 };
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
