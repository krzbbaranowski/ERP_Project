using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using ProjectERP.Model.Database;

namespace ProjectERP.Services
{
    public class ConnectionHelper
    {
        public static string MetaData =
            "res://*/Model.Database.ModelDB.csdl|res://*/Model.Database.ModelDB.ssdl|res://*/Model.Database.ModelDB.msl";

        //public static string dataSource = @"(localdb)\MSSQLLocalDB";
        //public static string initialCatalog = "ERP_Database";


        public static string DataSource = @"DESKTOP-B44EI83";
        public static string InitialCatalog = "JadeDatabase";


        //Data Source=DESKTOP-B44EI83;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
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
            var db = new ERPDatabaseEntities(CreateConnectionString(MetaData, DataSource, InitialCatalog));
            if (!db.Database.Exists())
                db.Database.Create();

            return db;
        }

        public static ERPDatabaseEntities CreateConnection(string metaData, string dataSource, string initialCatalog)
        {
            return new ERPDatabaseEntities(CreateConnectionString(metaData, dataSource, initialCatalog));
        }
    }
}