using System;
using System.Linq.Expressions;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;

        public ReadRepository(ETicaretAPIDbContext context)
        {
            _context = context; 
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
            => Table;


        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
       =>  await Table.FirstOrDefaultAsync(method);


        public IQueryable<T> Getwhere(Expression<Func<T, bool>> method)
        => Table.Where(method);


        public async Task<T> GetByIdAsync(string id)
        //=> await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        => await Table.FindAsync(Guid.Parse(id));
       
    }
}

