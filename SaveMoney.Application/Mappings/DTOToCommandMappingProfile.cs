using AutoMapper;
using SaveMoney.Application.DTOs;
using SaveMoney.Application.Features.FinancialTransactions.Commands;

namespace SaveMoney.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<FinancialTransactionDTO, FinancialTransactionCreateCommand>();
            CreateMap<FinancialTransactionDTO, FinancialTransactionUpdateCommand>();
        }
    }
}
