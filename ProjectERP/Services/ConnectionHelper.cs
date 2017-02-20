using ProjectERP.Model.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectERP.Services
{
    public class ConnectionHelper
    {
        public static string metaData = "res://*/Model.Database.ModelDB.csdl|res://*/Model.Database.ModelDB.ssdl|res://*/Model.Database.ModelDB.msl";
        public static string dataSource = @"(localdb)\MSSQLLocalDB";
        public static string initialCatalog = "ERP_Database";


        //connectionString="metadata=;provider=System.Data.SqlClient;provider connection string=&quot;data source=DESKTOP-B44EI83;
        //       initial catalog=JadeDatabase;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;"

        //providerName="System.Data.EntityClient" />
        public static string CreateConnectionString(string metaData, string dataSource, string initialCatalog)
        {
            const string appName = "EntityFramework";
            const string providerName = "System.Data.SqlClient";

            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            sqlBuilder.DataSource = dataSource;
            sqlBuilder.InitialCatalog = initialCatalog;
            sqlBuilder.MultipleActiveResultSets = true;
            sqlBuilder.IntegratedSecurity = true;
            sqlBuilder.ApplicationName = appName;

            EntityConnectionStringBuilder efBuilder = new EntityConnectionStringBuilder();
            efBuilder.Metadata = metaData;
            efBuilder.Provider = providerName;
            efBuilder.ProviderConnectionString = sqlBuilder.ConnectionString;

            return efBuilder.ConnectionString;
        }

        public static ERPDatabaseEntities CreateConnection()
        {
            ERPDatabaseEntities db = new ERPDatabaseEntities(ConnectionHelper.CreateConnectionString(metaData, dataSource, initialCatalog));
            if (!db.Database.Exists())
            {
                db.Database.Create();
            }

            return db;
        }

        public static ERPDatabaseEntities CreateConnection(string metaData, string dataSource, string initialCatalog)
        {
            return new ERPDatabaseEntities(ConnectionHelper.CreateConnectionString(metaData, dataSource, initialCatalog));
        }
    }
}
