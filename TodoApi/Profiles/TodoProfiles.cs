using AutoMapper;
using TodoApi.Dtos;
using TodoApi.Models;

namespace TodoApi.Profiles
{
    public class TodoProfiles : Profile
    {
        public TodoProfiles()
        {
            // Source -> Target
            CreateMap<Todo, TodoReadDto>();
            CreateMap<TodoCreateDto, Todo>();
            CreateMap<TodoUpdateDto, Todo>();
            CreateMap<Todo, TodoUpdateDto>();
        }
    }
}
