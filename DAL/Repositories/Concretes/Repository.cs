using CORE.Models;
using DAL.Contexts;
using DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Concretes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        readonly AppDBContext _context;

        public Repository(AppDBContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task CreateAsync(T entity)
        {
            entity.CreatedAt = DateTime.UtcNow.AddHours(4);
            await Table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public async Task<ICollection<T>> GetAllAsync(params string[] includes)
        {
            IQueryable<T> query = Table;
            if (includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, params string[] includes)
        {
            IQueryable<T> query = Table;
            if (includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.SingleOrDefaultAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            entity.UpdatedAt= DateTime.UtcNow.AddHours(4);

            Table.Update(entity);

        }
    }
}
