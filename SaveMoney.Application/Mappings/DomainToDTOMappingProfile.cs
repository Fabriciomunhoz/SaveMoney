using AutoMapper;
using SaveMoney.Application.DTOs;
using SaveMoney.Application.Users.Commands;
using SaveMoney.Domain.Entities;

namespace SaveMoney.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<UserDTO, UserCreateCommand>();
            CreateMap<UserDTO, UserUpdateCommand>();

            CreateMap<FinancialTransaction, FinancialTransactionDTO>().ReverseMap();
        }
    }
}
