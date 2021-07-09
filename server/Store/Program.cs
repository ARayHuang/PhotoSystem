using System;
using Store.Context;
using Store.Data;

namespace Store
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var _context = new StoreContext())
            {
                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();

                Fixtures.Init_Fixtures(_context);
            }
        }
    }
}
