using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cars.Application.EventSourcedNormalizers;
using Cars.Application.ViewModels;
using Cars.Application.ViewModels.CarType;
using Cars.DomainHelper.Filter;
using Cars.DomainHelper.Models;
using FluentValidation.Results;

namespace Cars.Application.Interfaces
{
    public interface ICarTypeAppService : IDisposable
    {
        Task<IEnumerable<CarTypeViewModel>> GetAll();
        Task<PaginatedResult<CarTypeViewModel>> GetAllPaged(CarTypeFilter filter);
        Task<ExportViewModel> GetAllExported(CarTypeFilter filter);
        Task<CarTypeViewModel> GetById(long id);
        Task Add(CarTypeViewModel CarTypeViewModel);
        Task Update(CarTypeViewModel CarTypeViewModel);
        Task Remove(long id);
    }
}
