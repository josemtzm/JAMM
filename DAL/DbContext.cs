using JAMM.Data;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public partial class DbContext : DataContext
    {
        public DbContext() : base(Config.ConnectionString) { }
    }
}
