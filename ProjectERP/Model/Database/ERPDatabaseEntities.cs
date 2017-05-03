using ProjectERP.Model.Enitites;
using System.Data.Entity;
using ProjectERP.Model.Database.Interfaces;

namespace ProjectERP.Model.Database
{
    public class ErpDatabaseEntities : DbContext, IErpDatabaseContext
    {
        public DbSet<Counterparty> Counterparty { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<ArticleGroup> ArticleGroup { get; set; }
        public DbSet<ArticleMeasure> ArticleMeasure { get; set; }
        public DbSet<ArticlePriceType> ArticlePriceType { get; set; }
        public DbSet<ArticlePrice> ArticlePrice { get; set; }
        public DbSet<ArticleType> ArticleType { get; set; }
        public DbSet<Tax> Tax { get; set; }
    }
}