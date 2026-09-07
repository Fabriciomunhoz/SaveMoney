using AutoMapper;
using SaveMoney.Application.DTOs;
using SaveMoney.Application.Users.Commands;

namespace SaveMoney.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<UserDTO, UserCreateCommand>();
            CreateMap<UserDTO, UserUpdateCommand>();
        }
    }
}
