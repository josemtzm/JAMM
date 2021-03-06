using System;
//using BLL;
//using DAL;
using BLL_WCF;

public partial class AddEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnYES_Click(object sender, EventArgs e)
    {
        //Empleado emp = new Empleado();
        BLL_WCF.SrvEmpleado.Empleado emp = new BLL_WCF.SrvEmpleado.Empleado();

        emp.Apellido = txtApellido.Text;
        emp.Nombre = txtNombre.Text;
        emp.Direccion = txtDireccion.Text;
        emp.Ciudad = txtCiudad.Text;
        emp.Pais = txtPais.Text;
        emp.Region = txtRegion.Text;
        emp.CodigoPostal = txtCodigoPostal.Text;
        emp.Extension = txtExtension.Text;
        emp.Puesto = txtPuesto.Text;

        //EmpleadoHelper empHelper = new EmpleadoHelper();
        EmpleadoHelperWCF empHelper = new EmpleadoHelperWCF();

        if (empHelper.AgregarEmpleado(emp) == true)
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void btnNO_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
