using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Cars.DomainHelper.Filter;
using Cars.DomainHelper.Models;
using Cars.DomainHelper.Services;
using Cars.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Infra.Data.Repository
{
    public class CarTypeRepository : ICarTypeRepository
    {
        protected readonly CarsContext Db;
        protected readonly DbSet<CarType> DbSet;

        public CarTypeRepository(CarsContext context)
        {
            Db = context;
            DbSet = Db.Set<CarType>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<CarType> GetByIdAsyncAsTracking(long idN)
        {
            return await DbSet.AsTracking().FirstOrDefaultAsync(s => s.IdN == idN);
        }



        public async Task<CarType> GetByIdAsync(long idN)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.IdN == idN);
        }

        public async Task<CarType> AddAsync(CarType CarType)
        {
            await DbSet.AddAsync(CarType);
            return CarType;
        }

        public void Update(CarType CarType)
        {
            DbSet.Update(CarType);
        }

        public void Delete(CarType CarType)
        {
            DbSet.Remove(CarType);
        }

        public async Task<IEnumerable<CarType>> GetAllAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }


        public async Task<PaginatedResult<CarType>> GetPaginatedResultAsync(CarTypeFilter filter)
        {
            IQueryable<CarType> query = null;
          
            query = DbSet.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(filter.Code))
                query = query.Where(x => x.Code.Contains(filter.Code));
            if (!string.IsNullOrWhiteSpace(filter.Name))
                query = query.Where(x => x.Name.Contains(filter.Name));
            if (filter.IsActive != null)
                query = query.Where(x => x.IsActive == filter.IsActive);
            if (filter.IsDeleted != null)
                query = query.Where(x => x.IsDeleted == filter.IsDeleted);

            var queryCount = await query.CountAsync().ConfigureAwait(false);
            if (!filter.IsExport)
            {
                return new PaginatedResult<CarType>
                {
                    Records = await query.OrderByDescending(x => x.Id).Skip(Pager.Skip(filter.CurrentPage, filter.PageSize)).Take(filter.PageSize).ToListAsync(),
                    Total = queryCount,
                    HasNext = Pager.HasMoreItems(queryCount, filter.CurrentPage, filter.PageSize)
                };
            }
            else
            {
                return new PaginatedResult<CarType>
                {
                    Records = await query.OrderByDescending(x => x.Id).ToListAsync(),
                    Total = queryCount,
                    HasNext = Pager.HasMoreItems(queryCount, filter.CurrentPage, filter.PageSize)
                };
            }
        }

        public async Task<CarType> GetByNameAsync(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Name.ToLower().Equals(name.ToLower()));
        }

        public async Task<CarType> GetByCodeAsync(string code)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Code.ToLower().Equals(code.ToLower()));
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
