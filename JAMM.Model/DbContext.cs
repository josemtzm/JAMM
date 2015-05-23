using JAMM.Data;
using System;
using System.Data;
using System.Data.SqlClient;

namespace JAMM.Model
{
    internal partial class DbContext : DataContext
    {
        public DbContext() : base(Config.ConnectionString)
        {
        }

    }
}
