using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TodoApi.Models;
using TodoApi.Controllers;
using TodoApi.Data;
using AutoMapper;
using TodoApi.Dtos;
using TodoApi.Profiles;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TodoApi.Tests
{
    public class ApiTests
    {
        private readonly ITodoRepo _repository = new MockTodoRepo();
        private readonly IMapper _mapper;

        public ApiTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new TodoProfiles());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public void GetAllTodos_ValidData_Return_OkResult()
        {
            // Arrange
            var controller = new TodosController(_repository, _mapper);

            // Act
            var result = controller.GetAllTodos();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetTodoById_ValidData_Return_OkResult()
        {
            // Arrange
            var controller = new TodosController(_repository, _mapper);

            // Act
            var result = controller.GetTodoById(0);
            
            // Assert
            Assert.IsType<ActionResult<TodoReadDto>>(result);
        }
        [Fact]
        public void GetTodoById_InvalidData_Return_WrongResult()
        {
            // Arrange
            var controller = new TodosController(_repository, _mapper);

            // Act
            var result = controller.GetTodoById(100);

            // Assert
            Assert.Null(result.Value);
        }

        [Fact]
        public void CreateTodo_ValidData_Return_OkResult()
        {
            // Arrange
            var controller = new TodosController(_repository, _mapper);
            var createTodo = new TodoCreateDto { Title = "Todo item test", Description = "test description", ExpiryTime = DateTime.UtcNow.AddDays(14) };

            // Act
            var result = controller.CreateTodo(createTodo);

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }
    }
}
