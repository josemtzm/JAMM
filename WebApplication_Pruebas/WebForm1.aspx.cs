using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_Pruebas
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();
            DbContext ctx = new DbContext();

            return ctx.ExecuteDataTable("AsesorEmpleadoAdd", new[] {
            new SqlParameter("@userid", SqlDbType.UniqueIdentifier) { Value = userid },
            new SqlParameter("@XML", SqlDbType.Xml) { Value = table }
            });
        }
    }
}