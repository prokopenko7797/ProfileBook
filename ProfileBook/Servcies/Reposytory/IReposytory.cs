using System;
using System.Collections.Generic;
using System.Text;
using ProfileBook.Models;

namespace ProfileBook.Servcies.Repository
{
    public interface IRepository<T> where T : IModel, new()
    {
        IEnumerable<T> GetAll();

        T FindWithQuery(string query);

        IEnumerable<T> Query(string query);
        T GetById(int id);
        int Delete(int id);
        int Insert(T item);
        int Update(T item);
    }
}
