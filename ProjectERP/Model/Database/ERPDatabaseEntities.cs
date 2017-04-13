using ProjectERP.Model.Enitites;
using System.Data.Entity;
using ProjectERP.Model.Database.Interfaces;

namespace ProjectERP.Model.Database
{
    public class ErpDatabaseEntities : DbContext, IErpDatabaseContext
    {
        public DbSet<Counterparty> Counterparty { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}