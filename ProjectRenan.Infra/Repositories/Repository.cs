using Microsoft.EntityFrameworkCore;
using ProjectRenan.Data.Context;
using ProjectRenan.Domain.Interfaces;
using ProjectRenan.Domain.Models;
using System.Linq.Expressions;

namespace ProjectRenan.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ProjectRenanContext context;
        protected DbSet<TEntity> DbSet
        {
            get
            {
                return context.Set<TEntity>();
            }
        }
        public Repository(ProjectRenanContext context)
        {
            this.context = context;
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                return DbSet.Where(where).AsQueryable();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, object> includes)
        {
            try
            {
                IQueryable<TEntity> _query = DbSet;

                if (includes != null)
                    _query = includes(_query) as IQueryable<TEntity>;

                return _query.Where(where).AsQueryable();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TEntity Find(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                return DbSet.AsNoTracking().FirstOrDefault(where);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, object> includes)
        {
            try
            {
                IQueryable<TEntity> _query = DbSet;

                if (includes != null)
                    _query = includes(_query) as IQueryable<TEntity>;

                return _query.AsNoTracking().FirstOrDefault(predicate);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int FindSQL(string query)
        {
            try
            {

                return context.Database.ExecuteSqlInterpolated($"{query}");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TEntity Create(TEntity model)
        {
            try
            {
                DbSet.Add(model);
                Save();
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Save()
        {
            try
            {
                return context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(TEntity model)
        {
            try
            {
                var entry = context.Entry(model);

                DbSet.Attach(model);

                entry.State = EntityState.Modified;

                return Save() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(TEntity model)
        {
            try
            {
                if (model is Entity)
                {
                    (model as Entity).IsDeleted = true;
                    var _entry = context.Entry(model);

                    DbSet.Attach(model);

                    _entry.State = EntityState.Modified;
                }
                else
                {
                    var _entry = context.Entry(model);
                    DbSet.Attach(model);
                    _entry.State = EntityState.Deleted;
                }

                return Save() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            try
            {
                if (context != null)
                    context.Dispose();

                GC.SuppressFinalize(this);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}