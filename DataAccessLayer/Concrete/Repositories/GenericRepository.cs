﻿using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
   public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context context = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = context.Set<T>();
        }
        public void Delete(T parametre)
        {
            var deletedEntity = context.Entry(parametre);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(parametre);
            context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T parametre)
        {
            var addedEntity = context.Entry(parametre);
            addedEntity.State = EntityState.Added;
            //_object.Add(parametre);
            context.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T parametre)
        {
            var updatedEntity = context.Entry(parametre);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
