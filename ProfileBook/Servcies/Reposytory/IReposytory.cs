using System;
using System.Collections.Generic;
using System.Text;
using ProfileBook.Models;

namespace ProfileBook.Servcies
{
    public interface IRepository<T> where T : IModel, new()
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> Query(string query);

        T Get(int id);
        int Delete(int id);
        int Insert(T item);
        int Update(T item);
    }
}
