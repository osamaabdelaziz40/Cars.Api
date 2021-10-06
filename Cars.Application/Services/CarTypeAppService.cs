using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cars.Application.Interfaces;
using Cars.Domain.Interfaces;
using NetDevPack.Mediator;
using Cars.Domain.Models;
using Cars.Application.ViewModels.CarType;
using Cars.DomainHelper.Models;
using Cars.DomainHelper.Filter;
using Cars.DomainHelper.Interfaces;
using Cars.Application.ViewModels;

namespace Cars.Application.Services
{
    public class CarTypeAppService : ICarTypeAppService
    {
        private readonly IMapper _mapper;
        private readonly ICarTypeRepository _CarTypeRepository;
        private readonly ICSVManager _csvManager;
        private readonly IMediatorHandler _mediator;

        public CarTypeAppService(IMapper mapper,
                                  ICarTypeRepository CarTypeRepository,
                                  ICSVManager csvManager,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _CarTypeRepository = CarTypeRepository;
            _csvManager = csvManager;
            _mediator = mediator;
        }

        public async Task<IEnumerable<CarTypeViewModel>> GetAll()
        {
          return _mapper.Map<IEnumerable<CarTypeViewModel>>(await _CarTypeRepository.GetAllAsync());
        }

        public async Task<PaginatedResult<CarTypeViewModel>> GetAllPaged(CarTypeFilter filter)
   => _mapper.Map<PaginatedResult<CarTypeViewModel>>(await _CarTypeRepository.GetPaginatedResultAsync(filter).ConfigureAwait(false));

        public async Task<ExportViewModel> GetAllExported(CarTypeFilter filter)
        {
            filter.IsExport = true;
            var pagedResult = await _CarTypeRepository.GetPaginatedResultAsync(filter).ConfigureAwait(false);

            var exportedCSV = await _csvManager.Export(pagedResult.Records, "ExportedCarTypes");
            return _mapper.Map<ExportViewModel>(exportedCSV);
        }

        public async Task<CarTypeViewModel> GetById(long id)
        {
           return _mapper.Map<CarTypeViewModel>(await _CarTypeRepository.GetByIdAsync(id));
        }

        public async Task Add(CarTypeViewModel CarTypeViewModel)
        {
            //this will add for CarType and CarType configuration as the viewmodel holds both objects
            var CarType = _mapper.Map<CarType>(CarTypeViewModel);
            CarType.Id = Guid.NewGuid();
            await _CarTypeRepository.AddAsync(CarType);

            await _CarTypeRepository.UnitOfWork.Commit();
        }


        public async Task Update(CarTypeViewModel CarTypeViewModel)
        {
            var CarType = _mapper.Map<CarType>(CarTypeViewModel);
            _CarTypeRepository.Update(CarType);
            await _CarTypeRepository.UnitOfWork.Commit();
        }

        public async Task Remove(long id)
        {
            var existingCarType = await _CarTypeRepository.GetByIdAsyncAsTracking(id);

            if (existingCarType != null)
            {
                existingCarType.IsDeleted = true;
                await _CarTypeRepository.UnitOfWork.Commit();
            }
        }

        //public async Task<IList<CustomerHistoryData>> GetAllHistory(Guid id)
        //{
        //    return CustomerHistory.ToJavaScriptCustomerHistory(await _eventStoreRepository.All(id));
        //}

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
