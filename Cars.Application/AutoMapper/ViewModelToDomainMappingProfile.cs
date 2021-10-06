using AutoMapper;
using Cars.Application.ViewModels;
using Cars.Application.ViewModels.Customer;
using Cars.Domain.Commands;
using Cars.Domain.Commands.Customers;
//using Cars.Domain.Commands.Bank;
//using Cars.Application.ViewModels.Bank;
using Cars.Domain.Models;

namespace Cars.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
                .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));
            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));

            #region Bank
            //CreateMap<BankViewModel, Bank>()
            //    .ConstructUsing(c => new Bank(c.IdN, c.Id, c.Code, c.Name, c.IsActive, c.IsDeleted));

            //CreateMap<BankConfigurationViewModel, BankConfiguration>()
            //    .ConstructUsing(c => new BankConfiguration(c.BankId, c.IsPOS, c.IsPOS_ICS, c.IsPOS_OmanNet,
            //    c.IsEcommerce, c.IsEcommerce_ICS, c.IsEcommerce_OmanNet, c.IsDigQR, c.IsDeleted, c.Logo, c.MonoLogo));

            //CreateMap<BankViewModel, RegisterNewBankCommand>()
            //    .ConstructUsing(c => new RegisterNewBankCommand(c.Id, c.Code, c.Name, c.IsActive, c.IsDeleted));
            //CreateMap<BankViewModel, UpdateBankCommand>()
            //    .ConstructUsing(c => new UpdateBankCommand(c.IdN, c.Id, c.Code, c.Name, c.IsActive, c.IsDeleted));
            #endregion
        }
    }
}
