using Store.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data
{
    class Fixtures
    {
        public static void Init_Fixtures(StoreContext context)
        {
            UsersData _UsersData = new UsersData(context);
            _UsersData.insertBulkData();

            context.SaveChanges();

            ProjectsData _ProjectsData = new ProjectsData(context);
            _ProjectsData.insertBulkData();

            context.SaveChanges();
        }
    }
}
