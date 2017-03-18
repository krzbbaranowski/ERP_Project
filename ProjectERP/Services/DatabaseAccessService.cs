using System;
using System.Collections.Generic;
using System.Data.Entity;
using ProjectERP.Model.Database;

namespace ProjectERP.Services
{
    public class DatabaseAccessService
    {
        private readonly ERPDatabaseEntities _database = ConnectionHelper.CreateConnection();

        public DatabaseAccessService()
        {
            if (Current != null)
                throw new Exception($"Only one instance of {nameof(DatabaseAccessService)} can exists!");
            Current = this;
        }

        public static DatabaseAccessService Current { get; private set; }

        public List<T> GetEntities<T>() where T : class
        {
            var value = _database.GetType().GetProperty(typeof(T).Name).GetValue(_database, null);
            var obj = value as DbSet<T>;

            return new List<T>(obj);
        }

        public void AddEntities<T>(T entity) where T : class
        {
            var value = _database.GetType().GetProperty(typeof(T).Name).GetValue(_database, null);
            var obj = value as DbSet<T>;

           
        }

    }
}