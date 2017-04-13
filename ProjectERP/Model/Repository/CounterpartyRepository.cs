using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProjectERP.Model.Database;
using ProjectERP.Model.Database.Interfaces;
using ProjectERP.Model.Enitites;
using ProjectERP.Model.Repository.Interfaces;

namespace ProjectERP.Model.Repository
{
    internal class CounterpartyRepository : ICounterpartyRepository, IDisposable
    {
        private readonly IErpDatabaseContext _dbContext;

        private bool _disposed;

        public CounterpartyRepository(IErpDatabaseContext erpDatabaseContext)
        {
            _dbContext = erpDatabaseContext;
        }

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
            //if (!_disposed && disposing)
             //   _dbContext.Dispose();
          //  _disposed = true;
        }

        public Counterparty GetById(int id)
        {
            return _dbContext.Counterparty.Find(id);
        }
    }
}