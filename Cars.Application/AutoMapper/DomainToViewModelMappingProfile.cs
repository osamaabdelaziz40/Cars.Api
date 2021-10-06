using AutoMapper;
using Cars.Application.ViewModels;
using Cars.Application.ViewModels.CarType;
using Cars.Application.ViewModels.Customer;
using Cars.Domain.Models;
using Cars.DomainHelper.Models;

namespace Cars.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            //Map
            CreateMap<Customer, CustomerViewModel>().ReverseMap();

            CreateMap<PaginatedResult<CarType>, PaginatedResult<CarTypeViewModel>>().ReverseMap();
            CreateMap<CarType, CarTypeViewModel>().ReverseMap();

            CreateMap<ExportedCSVFile, ExportViewModel>().ReverseMap();
        }
    }
}
