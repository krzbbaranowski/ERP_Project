using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProjectERP.Model.Database.Interfaces;
using ProjectERP.Model.Enitites;
using ProjectERP.Model.Repository.Interfaces;

namespace ProjectERP.Model.Repository
{
    internal class MeasureRepository : IMeasureRepository, IDisposable
    {
        private readonly IErpDatabaseContext _dbContext;

        private bool _disposed;

        public MeasureRepository(IErpDatabaseContext erpDatabaseContext)
        {
            _dbContext = erpDatabaseContext;
        }

        public IEnumerable<ArticleMeasure> GetEntities()
        {
            return _dbContext.ArticleMeasure.ToList();
        }

        public void Add(ArticleMeasure entity)
        {
            _dbContext.ArticleMeasure.Add(entity);
        }

        public void Remove(ArticleMeasure entity)
        {
            _dbContext.ArticleMeasure.Remove(entity);
        }

        public void Update(ArticleMeasure entity)
        {
            var a = _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public ArticleMeasure GetById(int id)
        {
            return _dbContext.ArticleMeasure.Find(id);
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