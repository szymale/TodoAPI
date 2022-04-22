﻿using TodoApi.Models;

namespace TodoApi.Data
{
    public class MockTodoRepo : ITodoRepo
    {
        public Todo GetTodoById(int id)
        {
            return new Todo { Id = 0, Title = "Todo item", Description = "tesk description", ExpiryTime = DateTime.Now.AddDays(14), IsFinished = false, Overdue = false, Progress = 0 };
        }

        public IEnumerable<Todo> GetTodos()
        {
            var todos = new List<Todo>()
            {
                new Todo { Id = 0, Title = "Todo item 0", Description = "tesk description 1", ExpiryTime = DateTime.Now.AddDays(14), IsFinished = false, Overdue = false, Progress = 0 },
                new Todo { Id = 1, Title = "Todo item 1", Description = "tesk description 2", ExpiryTime = DateTime.Now.AddDays(10), IsFinished = false, Overdue = false, Progress = 0 },
                new Todo { Id = 2, Title = "Todo item 3", Description = "tesk description 3", ExpiryTime = DateTime.Now.AddDays(7), IsFinished = false, Overdue = false, Progress = 0 }
            };

            return todos;
        }
    }
}