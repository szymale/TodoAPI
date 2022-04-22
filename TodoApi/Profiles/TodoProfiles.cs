using AutoMapper;
using TodoApi.Dtos;
using TodoApi.Models;

namespace TodoApi.Profiles
{
    public class TodoProfiles : Profile
    {
        public TodoProfiles()
        {
            CreateMap<Todo, TodoReadDto>();
        }
    }
}
