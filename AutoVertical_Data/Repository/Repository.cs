using AutoVertical_Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Data.Repository
{
    public class Repository<T>:IRepository<T> where T : class
    {
        private readonly DbAccess _db;
        internal DbSet<T> dbSet;
        public Repository(DbAccess db)
        {
            _db=db;
            dbSet=_db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query;
            if(filter != null)
            {
                query = dbSet.Where(filter);
            }
            else{
                query = dbSet;
            }

            if(includeProperties != null){
                foreach(var property in includeProperties.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries))
                { 
                    query = query.Include(property);
                }
            }
            return query.ToList();
        }

        public T GetFirstOfDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            query = query.Where(filter);

            if(includeProperties != null){
                foreach(var property in includeProperties.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries))
                { 
                    query = query.Include(property);
                }
            }

            return query.FirstOrDefault();



        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
