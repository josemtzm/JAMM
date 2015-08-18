using System.Configuration;

namespace DAL
{
    public static partial class Config
    {
        public static string ConnectionString
        {
            //get { return ConfigurationManager.ConnectionStrings["Oracle_WCF"].ConnectionString; }
            get { return ConfigurationManager.ConnectionStrings["Northwind_WCF"].ConnectionString; }
        }
    }
}
