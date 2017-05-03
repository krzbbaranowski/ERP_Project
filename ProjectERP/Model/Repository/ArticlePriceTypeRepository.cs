using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProjectERP.Model.Database.Interfaces;
using ProjectERP.Model.Enitites;
using ProjectERP.Model.Repository.Interfaces;

namespace ProjectERP.Model.Repository
{
    internal class ArticlePriceTypeRepository : IArticlePriceTypeRepository, IDisposable
    {
        private readonly IErpDatabaseContext _dbContext;

        private bool _disposed;

        public ArticlePriceTypeRepository(IErpDatabaseContext erpDatabaseContext)
        {
            _dbContext = erpDatabaseContext;
        }

        public IEnumerable<ArticlePriceType> GetEntities()
        {
            return _dbContext.ArticlePriceType.ToList();
        }

        public void Add(ArticlePriceType entity)
        {
            _dbContext.ArticlePriceType.Add(entity);
        }

        public void Remove(ArticlePriceType entity)
        {
            _dbContext.ArticlePriceType.Remove(entity);
        }

        public void Update(ArticlePriceType entity)
        {
            var a = _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public ArticlePriceType GetById(int id)
        {
            return _dbContext.ArticlePriceType.Find(id);
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