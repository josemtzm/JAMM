using JAMM.Data;

namespace JAMM.Model
{
    internal partial class DbContext : DataContext
    {
        public DbContext() : base(Config.ConnectionString)
        {
        }

    }
}
