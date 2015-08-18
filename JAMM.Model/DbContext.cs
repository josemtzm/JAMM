using JAMM.Data;
<<<<<<< HEAD
using System;
using System.Data;
using System.Data.SqlClient;
=======
>>>>>>> origin/master

namespace JAMM.Model
{
    internal partial class DbContext : DataContext
    {
        public DbContext() : base(Config.ConnectionString)
        {
        }

    }
}
