using Microsoft.EntityFrameworkCore;
using SV.Business.Interfaces;
using SV.Data;
using SV.Models.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SV.Business.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SVDBContext context;

        public Repository(SVDBContext context)
        {
            this.context = context;
        }

        protected DbSet<T> DBSet
        {
            get
            {
                return context.Set<T>();
            }
        }

        public Task<List<T>> GetAll()
        {
            return DBSet.AsQueryable().ToListAsync();
        }

        public T GetByID(int id)
        {
            T obj = DBSet.Find(id);
            return obj;
        }

        public Object GetPropertyValue(T obj, string propertyName)
        {
            Type type = obj.GetType();
            PropertyInfo prop = type.GetProperty(propertyName);
            return prop.GetValue(obj);
        }

        public void InsertMultiple(List<T> obj)
        {
            try
            {
                DBSet.AddRange(obj);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int Insert(T obj)
        {
            try
            {
                DBSet.Add(obj);
                context.SaveChanges();
                int id = (int)GetPropertyValue(obj, "Id");
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public bool Update(T obj)
        {
            try
            {
                var entry = context.Entry(obj);
                entry.State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                T obj = DBSet.Find(id);
                DBSet.Remove(obj);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
