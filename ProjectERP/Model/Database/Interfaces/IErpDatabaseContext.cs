using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ProjectERP.Model.Enitites;

namespace ProjectERP.Model.Database.Interfaces
{
    public interface IErpDatabaseContext
    {
        DbSet<Counterparty> Counterparty { get; set; }
        DbSet<Address> Address { get; set; }

        DbEntityEntry Entry(object entity);
        int SaveChanges();
        System.Data.Entity.Database Database { get; }
    }
}