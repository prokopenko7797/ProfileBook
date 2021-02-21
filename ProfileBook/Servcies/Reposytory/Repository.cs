using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using ProfileBook.Models;
using System.IO;

namespace ProfileBook.Servcies.Repository
{
    public class Repository<T> : IRepository<T> where T : IModel, new()
    {
        private readonly SQLiteConnection database;

        public Repository()
        {
            database = new SQLiteConnection(
                Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData), "sqlite.db"));
            database.CreateTable<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return database.Table<T>();
        }

        public IEnumerable<T> Query(string query)
        {
            return database.Query<T>(query);
        }

        public T GetById(int id)
        {
            return database.Get<T>(id);
        }

        public int Delete(int id)
        {
            return database.Delete<T>(id);
        }

        public int Insert(T item)
        {
            return database.Insert(item);
        }

        public int Update(T item)
        {
            return database.Update(item);
        }

        public T FindWithQuery(string query)
        {
            return database.FindWithQuery<T>(query);
        }
    }
}
