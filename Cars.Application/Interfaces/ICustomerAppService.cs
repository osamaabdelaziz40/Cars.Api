using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cars.Application.EventSourcedNormalizers;
using Cars.Application.ViewModels;
using Cars.Application.ViewModels.Customer;
using FluentValidation.Results;

namespace Cars.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        Task<IEnumerable<CustomerViewModel>> GetAll();
        Task<CustomerViewModel> GetById(Guid id);
        Task Register(CustomerViewModel customerViewModel);
        Task<ValidationResult> Update(CustomerViewModel customerViewModel);
        Task<ValidationResult> Remove(Guid id);
        Task<IList<CustomerHistoryData>> GetAllHistory(Guid id);
    }
}
