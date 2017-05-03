using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProjectERP.Model.Database.Interfaces;
using ProjectERP.Model.Enitites;
using ProjectERP.Model.Repository.Interfaces;

namespace ProjectERP.Model.Repository
{
    internal class ArticleTypeRepository : IArticleTypeRepository, IDisposable
    {
        private readonly IErpDatabaseContext _dbContext;

        private bool _disposed;

        public ArticleTypeRepository(IErpDatabaseContext erpDatabaseContext)
        {
            _dbContext = erpDatabaseContext;
        }

        public IEnumerable<ArticleType> GetEntities()
        {
            return _dbContext.ArticleType.ToList();
        }

        public void Add(ArticleType entity)
        {
            _dbContext.ArticleType.Add(entity);
        }

        public void Remove(ArticleType entity)
        {
            _dbContext.ArticleType.Remove(entity);
        }

        public void Update(ArticleType entity)
        {
            var a = _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public ArticleType GetById(int id)
        {
            return _dbContext.ArticleType.Find(id);
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