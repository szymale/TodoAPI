using TodoApi.Models;

namespace TodoApi.Data
{
    public interface ITodoRepo
    {
        bool SaveChanges();
        IEnumerable<Todo> GetTodos();
        Todo GetTodoById(int id);
        void CreateTodo(Todo todo);
    }
}
