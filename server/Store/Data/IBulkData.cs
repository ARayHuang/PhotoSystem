using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data
{
    interface IBulkData<T>
    {
        void insertBulkData();

        List<T> generateData();
    }
}
