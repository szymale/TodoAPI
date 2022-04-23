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

namespace TodoApi.Tests
{
    public class ControllerTests
    {
        private readonly TodoProfiles profile = new TodoProfiles();
        [Fact]
        public void GetAllTodos_ValidData_Return_OkResult()
        {
            // Arrange
            
            // Act
            
            // Assert
            
        }
    }
}
