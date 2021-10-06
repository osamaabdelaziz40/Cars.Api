using Cars.Domain.Models;
using Cars.DomainHelper.Filter;
using Cars.DomainHelper.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Interfaces
{
    public interface ICarTypeRepository : IRepository<CarType>
    {
        Task<CarType> GetByIdAsyncAsTracking(long idN);
        Task<PaginatedResult<CarType>> GetPaginatedResultAsync(CarTypeFilter filter);
        Task<CarType> GetByIdAsync(long idN);
        Task<CarType> GetByNameAsync(string name);
        Task<CarType> GetByCodeAsync(string code);
        Task<IEnumerable<CarType>> GetAllAsync();
        Task<CarType> AddAsync(CarType CarType);
        void Update(CarType CarType);
        void Delete(CarType CarType);
    }
}