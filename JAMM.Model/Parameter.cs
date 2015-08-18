using System;
using System.Data;
using System.Data.SqlClient;
using JAMM.Data;
using JAMM.Model.Entities;

namespace JAMM.Model
{
    internal partial class DbContext
    {
        public static Parameter ParameterGet(string label)
        {
            DbContext ctx = new DbContext();
<<<<<<< HEAD

            return ctx.ExecuteEntity<Parameter>("ParameterGet", new[] { new SqlParameter("@Label", SqlDbType.VarChar) { Value = label } });
=======
            // TO DO: Implementar ExecuteEntity. 
            // Este regresa parametros de configuracion que se guardan en la DB
            ////return ctx.ExecuteEntity<Parameter>("ParameterGet", new[] { new SqlParameter("@Label", SqlDbType.VarChar) { Value = label } });
            return null;
            
>>>>>>> origin/master
        }

        public static Table<Parameter> ParameterGetAll()
        {
            DbContext ctx = new DbContext();

            //return ctx.ExecuteTable<Parameter>("ParameterGetAll");
            return null;
        }

        public static void ParameterSet(string label, string value, Guid userName)
        {
            DbContext ctx = new DbContext();

            //ctx.ExecuteNonQuery("ParameterSet", new[]
            //{
            //    new SqlParameter("@Label", SqlDbType.VarChar) { Value = label },
            //    new SqlParameter("@Value", SqlDbType.VarChar) { Value = value },
            //    new SqlParameter("@UserName", SqlDbType.UniqueIdentifier) { Value = userName }
            //});
        }
    }
}
