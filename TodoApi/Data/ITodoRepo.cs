using TodoApi.Models;

namespace TodoApi.Data
{
    public interface ITodoRepo
    {
        bool SaveChanges();
        IEnumerable<Todo> GetTodos();
        Todo GetTodoById(int id);
        IEnumerable<Todo> GetUpcomingTodos(double days);
        void CreateTodo(Todo todo);
        void UpdateTodo(Todo todo);
        void CompleteTodo(Todo todo);
        void ProgressTodo(Todo todo, int progress);
        void DeleteTodo(Todo todo);
    }
}
