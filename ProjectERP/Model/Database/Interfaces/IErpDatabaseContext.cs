using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ProjectERP.Model.Enitites;

namespace ProjectERP.Model.Database.Interfaces
{
    public interface IErpDatabaseContext
    {
        DbSet<Counterparty> Counterparty { get; set; }
        DbSet<Address> Address { get; set; }
        DbSet<Article> Article { get; set; }
        DbSet<ArticleGroup> ArticleGroup { get; set; }
        DbSet<ArticleMeasure> ArticleMeasure { get; set; }
        DbSet<ArticlePrice> ArticlePrice { get; set; }
        DbSet<Tax> Tax { get; set; }


        System.Data.Entity.Database Database { get; }
        DbEntityEntry Entry(object entity);
        int SaveChanges();
    }
}