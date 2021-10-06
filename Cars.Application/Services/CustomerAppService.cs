using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cars.Application.EventSourcedNormalizers;
using Cars.Application.Interfaces;
using Cars.Application.ViewModels;
using Cars.Domain.Commands;
using Cars.Domain.Interfaces;
using FluentValidation.Results;
using NetDevPack.Mediator;
using Cars.Domain.Models;
using Cars.Domain.Commands.Customers;
using Cars.Application.ViewModels.Customer;

namespace Cars.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        //private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public CustomerAppService(IMapper mapper,
                                  ICustomerRepository customerRepository,
                                  IMediatorHandler mediator
            //,IEventStoreRepository eventStoreRepository
            )
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _mediator = mediator;
            //_eventStoreRepository = eventStoreRepository;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<CustomerViewModel>>(await _customerRepository.GetAll());
        }

        public async Task<CustomerViewModel> GetById(Guid id)
        {
            return _mapper.Map<CustomerViewModel>(await _customerRepository.GetById(id));
        }

        public async Task Register(CustomerViewModel customerViewModel)
        {
            //var registerCommand = _mapper.Map<RegisterNewCustomerCommand>(customerViewModel);
            //return await _mediator.SendCommand(registerCommand);

            var customer = _mapper.Map<Customer>(customerViewModel);
            await _customerRepository.Add(customer);
            await _customerRepository.UnitOfWork.Commit();
        }

        public async Task<ValidationResult> Update(CustomerViewModel customerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateCustomerCommand>(customerViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveCustomerCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public async Task<IList<CustomerHistoryData>> GetAllHistory(Guid id)
        {
            return null;
            //return CustomerHistory.ToJavaScriptCustomerHistory(await _eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
