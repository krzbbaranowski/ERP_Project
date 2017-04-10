using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProjectERP.Model.Database;
using ProjectERP.Model.Enitites;
using ProjectERP.Model.Repository.Interfaces;

namespace ProjectERP.Model.Repository
{
    internal class CounterpartyRepository : ICounterpartyRepository, IDisposable
    {
        private readonly ERPDatabaseEntities _dbContext = new ERPDatabaseEntities();

        private bool _disposed;

        public IEnumerable<Counterparty> GetEntities()
        {
            return _dbContext.Counterparty.ToList();
        }

        public void Add(Counterparty entity)
        {
            _dbContext.Counterparty.Add(entity);
        }

        public void Remove(Counterparty entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Counterparty entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                _dbContext.Dispose();
            _disposed = true;
        }

        public Counterparty GetById(int id)
        {
            return _dbContext.Counterparty.Find(id);
        }
    }
}