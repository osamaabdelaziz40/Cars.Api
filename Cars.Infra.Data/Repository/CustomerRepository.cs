using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Cars.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;

namespace Cars.Infra.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly CarsContext Db;
        protected readonly DbSet<Customer> DbSet;

        public CustomerRepository(CarsContext context)
        {
            Db = context;
            DbSet = Db.Set<Customer>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Customer> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Customer> GetByEmail(string email)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task Add(Customer customer)
        {
            await DbSet.AddAsync(customer);
        }

        public void Update(Customer customer)
        {
            DbSet.Update(customer);
        }

        public void Remove(Customer customer)
        {
            DbSet.Remove(customer);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
