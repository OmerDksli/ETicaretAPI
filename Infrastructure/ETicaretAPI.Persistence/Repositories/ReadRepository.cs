using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
        //tracking mekanizması default olarak true olarak ayarlandı 
        //eğer veri manipülasyonu(create update delete) olmayacaksa metod çağrılırken false olarak ayarlanmalı
        public IQueryable<T> GetAll(bool tracking = true)
            => !tracking ? Table.AsNoTracking() : Table;
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        => !tracking ? Table.Where(method).AsNoTracking(): Table.Where(method);


        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        => !tracking ? await Table.AsNoTracking().FirstOrDefaultAsync(method) : await Table.FirstOrDefaultAsync(method);

        

        public async Task<T> GetByIdAsync(string id, bool tracking = true)// => !tracking ? await Table.AsNoTracking().FirstOrDefaultAsync(data=>data.Id==Guid.Parse(id)) : await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        {//yukaru-ıdaki işlem ile aşağıdaki aynı işleve sahip sadece biri 
            var query =Table.AsQueryable();
            if(!tracking)
                query=Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data=>data.Id==Guid.Parse(id));
        }

    }
}
