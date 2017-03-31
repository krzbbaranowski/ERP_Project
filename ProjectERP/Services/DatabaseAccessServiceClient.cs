using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ProjectERP.Services
{
    public class DatabaseAccessServiceClient
    {
        public static DatabaseAccessServiceClient Current { get; private set; }

        public DatabaseAccessServiceClient()
        {
            if (Current != null)
                throw new Exception($"Only one instance of {nameof(DatabaseAccessServiceClient)} can exists!");

            Current = this;
        }

        public List<object> GetEntities(Type entityType)
        {
            List<object> items  = new List<object>();

            var ex = typeof(DatabaseAccessService);
            var mi = ex.GetMethod("GetEntities");
            var miConstructed = mi.MakeGenericMethod(entityType);
            var itemList = miConstructed.Invoke(DatabaseAccessService.Current, null) as IList;

            if (itemList != null)
                foreach (var o in itemList)
                    items.Add(o);

            return items;
        }
    }
}
