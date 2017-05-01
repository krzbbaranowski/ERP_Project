using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProjectERP.Model.Database.Interfaces;
using ProjectERP.Model.Enitites;
using ProjectERP.Model.Repository.Interfaces;

namespace ProjectERP.Model.Repository
{
    internal class TaxRepository : ITaxRepository, IDisposable
    {
        private readonly IErpDatabaseContext _dbContext;

        private bool _disposed;

        public TaxRepository(IErpDatabaseContext erpDatabaseContext)
        {
            _dbContext = erpDatabaseContext;
        }

        public IEnumerable<Tax> GetEntities()
        {
            return _dbContext.Tax.ToList();
        }

        public void Add(Tax entity)
        {
            _dbContext.Tax.Add(entity);
        }

        public void Remove(Tax entity)
        {
            _dbContext.Tax.Remove(entity);
        }

        public void Update(Tax entity)
        {
            var a = _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public Tax GetById(int id)
        {
            return _dbContext.Tax.Find(id);
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
    }
}