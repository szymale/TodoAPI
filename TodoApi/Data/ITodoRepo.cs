using TodoApi.Models;

namespace TodoApi.Data
{
    public interface ITodoRepo
    {
        IEnumerable<Todo> GetTodos();
        Todo GetTodoById(int id);
    }
}
