using ProjectERP.Model.Enitites;
using System.Data.Entity;

namespace ProjectERP.Model.Database
{
    public class ERPDatabaseEntities : DbContext
    {
        public DbSet<Counterparty> Counterparty { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}