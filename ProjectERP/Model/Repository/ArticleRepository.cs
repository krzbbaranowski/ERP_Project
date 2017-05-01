using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProjectERP.Model.Database.Interfaces;
using ProjectERP.Model.Enitites;
using ProjectERP.Model.Repository.Interfaces;

namespace ProjectERP.Model.Repository
{
    internal class ArticleRepository : IArticleRepository, IDisposable
    {
        private readonly IErpDatabaseContext _dbContext;

        private bool _disposed;

        public ArticleRepository(IErpDatabaseContext erpDatabaseContext)
        {
            _dbContext = erpDatabaseContext;
        }

        public Article GetById(int id)
        {
            return _dbContext.Article.Find(id);
        }

        public IEnumerable<Article> GetEntities()
        {
            return _dbContext.Article.ToList();
        }

        public void Add(Article entity)
        {
            _dbContext.Article.Add(entity);
        }

        public void Remove(Article entity)
        {
            _dbContext.Article.Remove(entity);
        }

        public void Update(Article entity)
        {
            var a = _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}