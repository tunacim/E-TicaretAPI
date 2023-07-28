using System;
using System.Linq.Expressions;
using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Application.Repositories
{
	public interface IReadRepository<T>:IRepository<T> where T :BaseEntity
	{
		IQueryable<T> GetAll();
		IQueryable<T> Getwhere(Expression<Func<T,bool>>method);
		Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
		Task<T> GetByIdAsync(string id);
    }
}

