using System;
using System.Linq;
using Domain.Interfaces;
using Infra.Data.Context;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;


namespace Infra.Data.Repository
{
    public class Repository<TEntity, TID> : IRepository<TEntity, TID> where TEntity : class
    {
        protected readonly DbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DatabaseContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj) { 
            DbSet.Add(obj);
            SaveChanges();
        }


        public virtual TEntity GetById(TID id) => DbSet.Find(id);
        

        public virtual IQueryable<TEntity> GetAll() => DbSet;

        public virtual IQueryable<TEntity> GetPagination(
            Expression<Func<TEntity, bool>> filter,
            int page = 1,
            int quantity = 10) =>
            DbSet.Where(filter).Skip((page - 1) * quantity).Take(quantity);

        public virtual IQueryable<TEntity> GetPagination(
          Expression<Func<TEntity, bool>> filter,
          Expression<Func<TEntity, object>> orderBy,
          int page = 1,
          int quantity = 10
          ) =>
          DbSet.Where(filter).Skip((page - 1) * quantity).Take(quantity);

        public virtual IQueryable<TEntity> GetAutoComplete(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            int quantity = 10) =>
            DbSet.Where(filter).OrderBy(orderBy).Take(quantity);

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
            SaveChanges();
        }
        public virtual void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
            SaveChanges();
        }

            public int SaveChanges() =>
            Db.SaveChanges();


        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
