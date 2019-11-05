using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace OnlineExam.Core.DataAccess.EntityFramework
{
    class EFDbContextSingleton<TContext>
        where TContext : DbContext, new()
    {
        private static TContext _context;

        private EFDbContextSingleton()
        {

        }

        public static TContext Instance
        {
            get
            {
                if (_context == null)
                {
                    _context = new TContext();
                }
                return _context;
            }
        }
    }
}
