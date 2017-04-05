using System;
using System.Collections;
using System.Collections.Generic;

namespace ProjectERP.Services
{
    public class DatabaseAccessServiceClient
    {
        public DatabaseAccessServiceClient()
        {
            if (Current != null)
                throw new Exception($"Only one instance of {nameof(DatabaseAccessServiceClient)} can exists!");

            Current = this;
        }

        public static DatabaseAccessServiceClient Current { get; private set; }

        public List<object> GetEntities(Type entityType)
        {
            var items = new List<object>();

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