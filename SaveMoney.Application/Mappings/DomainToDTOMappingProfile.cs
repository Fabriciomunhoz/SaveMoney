using AutoMapper;
using SaveMoney.Application.DTOs;
using SaveMoney.Domain.Entities;

namespace SaveMoney.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<FinancialTransaction, FinancialTransactionDTO>().ReverseMap();
        }
    }
}
