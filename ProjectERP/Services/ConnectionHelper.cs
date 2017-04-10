using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using ProjectERP.Model.Database;

namespace ProjectERP.Services
{
    public class ConnectionHelper
    {
        public static string MetaData =
            @"res://*/Model.Database.ModelDB.csdl|res://*/Model.Database.ModelDB.ssdl|
res://*/Model.Database.ModelDB.msl";

      // public static string DataSource = @"(localdb)\MSSQLLocalDB";
        //public static string InitialCatalog = "ERP_Database";


           public static string DataSource = @"DESKTOP-B44EI83";
         public static string InitialCatalog = "JadeDatabase";

        public static string CreateConnectionString(string metaData, string dataSource, string initialCatalog)
        {
            const string appName = "EntityFramework";
            const string providerName = "System.Data.SqlClient";

            var sqlBuilder = new SqlConnectionStringBuilder
            {
                DataSource = dataSource,
                InitialCatalog = initialCatalog,
                MultipleActiveResultSets = true,
                IntegratedSecurity = true,
                ApplicationName = appName
            };

            var efBuilder = new EntityConnectionStringBuilder
            {
                Metadata = metaData,
                Provider = providerName,
                ProviderConnectionString = sqlBuilder.ConnectionString
            };

            return efBuilder.ConnectionString;
        }

        public static ERPDatabaseEntities CreateConnection()
        {
            var a = CreateConnectionString(MetaData, DataSource, InitialCatalog);
            var db = new ERPDatabaseEntities();
                // ERPDatabaseEntities(CreateConnectionString(MetaData, DataSource, InitialCatalog));
            if (!db.Database.Exists())
                db.Database.Create();

            return db;
        }

        public static ERPDatabaseEntities CreateConnection(string metaData, string dataSource, string initialCatalog)
        {
            return new ERPDatabaseEntities(); //CreateConnectionString(metaData, dataSource, initialCatalog));
        }
    }
}