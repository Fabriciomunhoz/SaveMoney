using AutoMapper;
using SaveMoney.Application.DTOs;
using SaveMoney.Application.Features.FinancialTransactions.Commands;
using SaveMoney.Application.Features.Users.Commands;

namespace SaveMoney.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<UserDTO, UserCreateCommand>();
            CreateMap<UserDTO, UserUpdateCommand>();

            CreateMap<FinancialTransactionDTO, FinancialTransactionCreateCommand>();
            CreateMap<FinancialTransactionDTO, FinancialTransactionUpdateCommand>();
        }
    }
}
