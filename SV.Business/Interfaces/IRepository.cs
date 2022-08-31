using SV.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SV.Business.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        T GetByID(int id);
        int Insert(T obj);

        void InsertMultiple(List<T> obj);
        Object GetPropertyValue(T obj, string propertyName);
        bool Update(T obj);
        bool Delete(int id);
    }
}
